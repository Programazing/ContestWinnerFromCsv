using ContestWinnerFromCsv;
using ContestWinnerFromCsv.FormServices;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ContestWinnerFromCsvTests.TypeForm
{
    [TestFixture]
    public class ContestWinnerTestsTypeForm
    {
        private string CsvLocation { get; }
        private Settings Settings { get; }
        private ContestWinner<TypeFormCsvModel, TypeFormCsvMap> ContestWinner { get; set; }
        public ICsvRepository<TypeFormCsvModel, TypeFormCsvMap> Repository { get; set; }

        public ContestWinnerTestsTypeForm()
        {
            Repository = new StubCsvRepository<TypeFormCsvModel, TypeFormCsvMap>
                (TypeFormTestData.TestData());

            CsvLocation = Path.Combine(Environment.CurrentDirectory, "responses.csv");
            Settings = GoogleTestData.TestSettings();
            ContestWinner = new ContestWinner<TypeFormCsvModel, TypeFormCsvMap>
                (Settings, Repository);
        }

        [Test]
        public void ContestWinner_Reads_FormattedCsvFile()
        {
            var sut = ContestWinner.GetEntries().ToList();

            sut.Count().Should().BeGreaterThan(0);
        }

        [Test]
        public void ContestWinner_Throws_FileNotFound_WhenGiven_ANonCsvFilePath()
        {
            Action act = () => new ContestWinner<TypeFormCsvModel, TypeFormCsvMap>
                (CsvLocation + "test");

            act.Should().Throw<FileNotFoundException>()
            .WithMessage("File could not be found.");
        }

        [Test]
        public void GetEntries_ReturnsOnlyEntries_WithinTheValidDateTimeRange()
        {
            var sut = ContestWinner.GetEntries();

            sut.Where(x => x.IsValid == false).Count().Should().Be(0);
        }

        [Test]
        public void GetEntries_ReturnsOnlyEntries_ThatAreValid_AndNotDuplicates()
        {
            var sut = ContestWinner.GetEntries();

            sut.Count().Should().Be(7);
        }

        [Test]
        public void PickWinners_Returns_CorrectNumber_OfWinners()
        {
            var sut = ContestWinner.PickWinners();

            sut.Count().Should().Be(2);
        }

        [Test]
        public void PickWinners_Throws_ArgumentOutOfRangeException_WhenListIsEmpty()
        {
            var repository = new StubCsvRepository<TypeFormCsvModel, TypeFormCsvMap>
                (new List<TypeFormCsvModel>());

            Action act = () => new ContestWinner<TypeFormCsvModel, TypeFormCsvMap>
                (Settings, repository).PickWinners();

            act.Should().Throw<ArgumentOutOfRangeException>()
            .WithMessage("CSV is Empty. (Parameter 'records')");
        }
    }
}
