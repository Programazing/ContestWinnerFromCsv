using System.Collections.Generic;

namespace ContestWinnerFromCsv
{
    public interface ICsvRepository<T, TMap>
    {
        public IEnumerable<T> GetCsvData();

    }
}