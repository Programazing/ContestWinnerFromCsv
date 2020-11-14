using ContestWinnerFromCsv;
using ContestWinnerFromCsv.FormServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContestWinnerFromCsvTests
{
    public class StubCsvRepository<T, TMap>: ICsvRepository<T, TMap>
        where T : class, ICsvModel
        where TMap : CsvHelper.Configuration.ClassMap
    {
        public IEnumerable<T> Data { get; set; }
        public StubCsvRepository(IEnumerable<T> data) => Data = data;
        public IEnumerable<T> GetCsvData() => Data;

    }
}
