using ContestWinnerFromCsv;
using ContestWinnerFromCsv.FormServices;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


namespace ContestWinnerFromCsvTests
{
    [TestFixture]
    public class ContestWinnerTests
    {
        private string CsvLocation { get; }
        private Settings Settings { get; }
        private ContestWinner<GoogleFormsCsvModel, GoogleFormsCsvMap> ContestWinner { get; set; }
        public ICsvRepository<GoogleFormsCsvModel, GoogleFormsCsvMap> Repository { get; set; }

        public ContestWinnerTests()
        {
            Repository = new StubCsvRepository<GoogleFormsCsvModel, GoogleFormsCsvMap>
                (GoogleTestData.TestData());

            CsvLocation = Path.Combine(Environment.CurrentDirectory, "Contact Information.csv");
            Settings = GoogleTestData.TestSettings();
            ContestWinner = new ContestWinner<GoogleFormsCsvModel, GoogleFormsCsvMap>
                (Settings, Repository);
        }

        [Test]
        public void ContestWinner_Reads_FormattedCsvFile()
        {
            var sut = ContestWinner.GetEntries();

            sut.Count().Should().BeGreaterThan(0);
        }

        [Test]
        public void ContestWinner_Throws_FileNotFound_WhenGiven_ANonCsvFilePath()
        {
            Action act = () => new ContestWinner<GoogleFormsCsvModel, GoogleFormsCsvMap>
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
            var repository = new StubCsvRepository<GoogleFormsCsvModel, GoogleFormsCsvMap>
                (new List<GoogleFormsCsvModel>());

            Action act = () => new ContestWinner<GoogleFormsCsvModel, GoogleFormsCsvMap>
                (Settings, repository).PickWinners();

            act.Should().Throw<ArgumentOutOfRangeException>()
            .WithMessage("CSV is Empty. (Parameter 'records')");
        }

    }
}
