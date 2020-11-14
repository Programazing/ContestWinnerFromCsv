using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContestWinnerFromCsv.FormServices
{
    public class TypeFormCsvMap : ClassMap<TypeFormCsvModel>
    {
        public TypeFormCsvMap()
        {
            Map(m => m.TimeStamp).Name("Submit Date (UTC)");
            Map(m => m.Email);
            Map(m => m.Name);
            Map(m => m.TwitterName).Name("Twitter Name");
        }
    }
}
