using ContestWinnerFromCsv;
using ContestWinnerFromCsv.FormServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContestWinnerFromCsvTests
{
    public static class TypeFormTestData
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

        public static List<TypeFormCsvModel> TestData()
        {
            var contestStart = TestSettings().StartDateTimeOfContest;
            var contestEnd = TestSettings().EndDateTimeOfContest;

            var list = new List<TypeFormCsvModel>()
            {
                new TypeFormCsvModel { Name = "Anna", Email = "Anna@email.com", TwitterName = "Anna", TimeStamp=  new DateTime(2020,11,05,8,33,43) },
                new TypeFormCsvModel { Name = "Bob", Email = "Bob@email.copm", TwitterName = "Bob", TimeStamp= new DateTime(2020,11,05,8,33,43) },
                new TypeFormCsvModel { Name = "Chris", Email = "Chris@email", TwitterName = "Chris", TimeStamp= new DateTime(2020, 11, 05, 8, 33, 43) },
                new TypeFormCsvModel { Name = "Derrick", Email = "Derrick@email", TwitterName = "Derrick", TimeStamp= new DateTime(2020, 11, 20, 8, 33, 43) },
                new TypeFormCsvModel { Name = "Ed", Email = "Ed@email", TwitterName = "Ed", TimeStamp= new DateTime(2020,11,05,8,33,43) },
                new TypeFormCsvModel { Name = "Frank", Email = "Frank@email", TwitterName = "Frank", TimeStamp= new DateTime(2020,11,21,8,33,43) },
                new TypeFormCsvModel { Name = "Gary", Email = "Gary@email", TwitterName = "Gary", TimeStamp= new DateTime(2020,11,05,8,33,43) },
                new TypeFormCsvModel { Name = "Heather", Email = "Heather@email", TwitterName = "Heather", TimeStamp= new DateTime(2020,11,23,8,33,43) },
                new TypeFormCsvModel { Name = "Isabelle", Email = "Isabelle@email", TwitterName = "Isabelle", TimeStamp= new DateTime(2020,11,05,8,33,43) },
                new TypeFormCsvModel { Name = "Jackie", Email = "Jackie@email", TwitterName = "Jackie", TimeStamp= new DateTime(2020,11,05,8,33,43) },
                new TypeFormCsvModel { Name = "Isabelle", Email = "Isabelle@email", TwitterName = "Isabelle", TimeStamp= new DateTime(2020,11,05,8,33,43) },
                new TypeFormCsvModel { Name = "Jackie", Email = "Jackie@email", TwitterName = "Jackie", TimeStamp= new DateTime(2020,11,05,8,33,43) }
            };

            foreach (var item in list)
            {
                item.SetTimeStampAndValidate(contestStart, contestEnd);
            }

            return list;
        }

    }
}
