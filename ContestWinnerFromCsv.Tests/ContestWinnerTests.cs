using ContestWinnerFromCsv;
using FluentAssertions;
using FluentAssertions.Common;
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
        private ContestWinner ContestWinner { get; set; }

        public ContestWinnerTests()
        {
            CsvLocation = Path.Combine(Environment.CurrentDirectory, "Contact Information.csv");
            Settings = TestSettings();
            ContestWinner = new ContestWinner(CsvLocation, Settings);
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
            Action act = () => new ContestWinner(CsvLocation + "test");

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
        public void GetEntries_ReturnsOnlyEntries_ThatAreNotDuplicates()
        {
            var sut = ContestWinner.GetEntries();

            sut.Count().Should().Be(3);
        }

        [Test]
        public void PickWinners_Returns_CorrectNumber_OfWinners()
        {
            var sut = ContestWinner.PickWinners();

            sut.Count().Should().Be(2);
        }

        private Settings TestSettings()
        {
            return new Settings
            {
                StartDateTimeOfContest = new DateTime(2020, 10, 20),
                EndDateTimeOfContest = new DateTime(2020, 11, 20, 08,30, 00, DateTimeKind.Local),
                NumberOfWinners = 2
            };
        }
    }
}
