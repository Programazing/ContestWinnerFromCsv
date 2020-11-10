using ContestWinnerFromCsv.FormServices;
using CsvHelper;
//using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace ContestWinnerFromCsv
{
    internal class CsvRepository<T, TMap> where T : class, ICsvModel
            where TMap : CsvHelper.Configuration.ClassMap
    {
        private string CsvLocation { get; set; }
        private IEnumerable<T> TestData { get; set; }

        internal CsvRepository(string csvLocation)
        {
            CsvLocation = csvLocation;
        }

        internal CsvRepository(IEnumerable<T> testData = null)
        {
            TestData = testData;
        }

        internal IEnumerable<T> GetCsvData()
        {

            if (TestData == null)
            {
                using var reader = new StreamReader(CsvLocation);
                using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
                csv.Configuration.RegisterClassMap<TMap>();
                var records = csv.GetRecords<T>();

                return records.ToList();
            }
            else
            {
                return TestData;
            }
        }
    }
}
