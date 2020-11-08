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
    public static class CsvRepository
    {
        public static List<T> GetCsvData<T, TMap>(string csvLocation) where T : class
            where TMap : ClassMap
        {
            using var reader = new StreamReader(csvLocation);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            csv.Configuration.RegisterClassMap<TMap>();
            var records = csv.GetRecords<T>();

            return records.ToList();
        }
    }
}
