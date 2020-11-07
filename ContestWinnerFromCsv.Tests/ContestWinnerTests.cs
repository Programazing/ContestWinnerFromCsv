﻿using ContestWinnerFromCsv;
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
        public string CsvLocation { get; set; }

        public ContestWinnerTests()
        {
            CsvLocation = Path.Combine(Environment.CurrentDirectory, "Contact Information.csv");
        }

        [Test]
        public void ContestWinner_Reads_FormattedCsvFile()
        {
            var sut = new ContestWinner(CsvLocation).GetEntries();

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
            var sut = new ContestWinner(CsvLocation).GetEntries();

            sut.Where(x => x.IsValid == false).Count().Should().Be(0);
            
        }

        [Test]
        public void PickWinners_Returns_CorrectNumber_OfWinners()
        {
            var sut = new ContestWinner(CsvLocation).PickWinners();

            sut.Count().Should().Be(2); 
            
        }
    }
}
