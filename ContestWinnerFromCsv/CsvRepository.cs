using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace ContestWinnerFromCsv
{
    internal static class CsvRepository<T, TMap> where T : class
            where TMap : ClassMap
    {
        private static List<T> TestData { get; set; }

        internal static void Initialize(List<T> testData = null)
        {
            TestData = testData;
        }

        internal static List<T> GetCsvData(string csvLocation)
        {
            if(TestData == null)
            {
                using var reader = new StreamReader(csvLocation);
                using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
                csv.Configuration.RegisterClassMap<TMap>();
                var records = csv.GetRecords<T>();

                return records.ToList(); ;
            }
            else
            {
                return TestData;
            }
        }
    }
}
