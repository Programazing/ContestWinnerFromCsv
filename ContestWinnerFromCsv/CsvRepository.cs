using CsvHelper;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Globalization;
using System.IO;
using System.Text;

namespace ContestWinnerFromCsv
{
    internal class CsvRepository<T, TMap> : ICsvRepository<T, TMap>
        where T : class, ICsvModel
        where TMap : CsvHelper.Configuration.ClassMap
    {
        private string CsvLocation { get; set; }

        internal CsvRepository(string csvLocation)
        {
            CsvLocation = csvLocation;
        }

        public IEnumerable<T> GetCsvData()
        {
            using var reader = new StreamReader(CsvLocation);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            csv.Configuration.RegisterClassMap<TMap>();
            var records = csv.GetRecords<T>();

            return records.ToImmutableList();
        }
    }
}
