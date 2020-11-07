using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContestWinnerFromCsv
{
    public class GoogleFormsCsvMap : ClassMap<GoogleFormsCsvModel>
    {
        public GoogleFormsCsvMap()
        {
            Map(m => m.TimeStampInput).Name("Timestamp");
            Map(m => m.Email).Name("Username");
            Map(m => m.Name);
            Map(m => m.TwitterName).Name("Twitter Name");
        }
    }
}
