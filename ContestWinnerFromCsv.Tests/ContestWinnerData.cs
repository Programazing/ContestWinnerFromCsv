using ContestWinnerFromCsv;
using ContestWinnerFromCsv.FormServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContestWinnerFromCsvTests
{
    static public class ContestWinnerData
    {
        public static Settings TestSettings()
        {
            return new Settings
            {
                StartDateTimeOfContest = new DateTime(2020, 10, 20),
                EndDateTimeOfContest = new DateTime(2020, 11, 20, 08, 30, 00, DateTimeKind.Local),
                NumberOfWinners = 2
            };
        }

        public static List<GoogleFormsCsvModel> TestData()
        {
            var contestStart = TestSettings().StartDateTimeOfContest;
            var contestEnd = TestSettings().EndDateTimeOfContest;

            return new List<GoogleFormsCsvModel>()
            {
                new GoogleFormsCsvModel(contestStart, contestEnd) { Name = "Anna", Email = "Anna@email.com", TwitterName = "Anna", TimeStampInput= "2020/11/05 8:33:43 PM EST" },
                new GoogleFormsCsvModel(contestStart, contestEnd) { Name = "Bob", Email = "Bob@email.copm", TwitterName = "Bob", TimeStampInput= "2020/11/05 8:33:43 PM EST" },
                new GoogleFormsCsvModel(contestStart, contestEnd) { Name = "Chris", Email = "Chris@email", TwitterName = "Chris", TimeStampInput= "2020/11/05 8:33:43 PM EST" },
                new GoogleFormsCsvModel(contestStart, contestEnd) { Name = "Derrick", Email = "Derrick@email", TwitterName = "Derrick", TimeStampInput= "2020/11/20 8:33:43 PM EST" },
                new GoogleFormsCsvModel(contestStart, contestEnd) { Name = "Ed", Email = "Ed@email", TwitterName = "Ed", TimeStampInput= "2020/11/05 8:33:43 PM EST" },
                new GoogleFormsCsvModel(contestStart, contestEnd) { Name = "Frank", Email = "Frank@email", TwitterName = "Frank", TimeStampInput= "2020/11/21 8:33:43 PM EST" },
                new GoogleFormsCsvModel(contestStart, contestEnd) { Name = "Gary", Email = "Gary@email", TwitterName = "Gary", TimeStampInput= "2020/11/05 8:33:43 PM EST" },
                new GoogleFormsCsvModel(contestStart, contestEnd) { Name = "Heather", Email = "Heather@email", TwitterName = "Heather", TimeStampInput= "2020/11/23 8:33:43 PM EST" },
                new GoogleFormsCsvModel(contestStart, contestEnd) { Name = "Isabelle", Email = "Isabelle@email", TwitterName = "Isabelle", TimeStampInput= "2020/11/05 8:33:43 PM EST" },
                new GoogleFormsCsvModel(contestStart, contestEnd) { Name = "Jackie", Email = "Jackie@email", TwitterName = "Jackie", TimeStampInput= "2020/11/05 8:33:43 PM EST" },
                new GoogleFormsCsvModel(contestStart, contestEnd) { Name = "Isabelle", Email = "Isabelle@email", TwitterName = "Isabelle", TimeStampInput= "2020/11/05 8:33:43 PM EST" },
                new GoogleFormsCsvModel(contestStart, contestEnd) { Name = "Jackie", Email = "Jackie@email", TwitterName = "Jackie", TimeStampInput= "2020/11/05 8:33:43 PM EST" }
            };
        }
    }
}
