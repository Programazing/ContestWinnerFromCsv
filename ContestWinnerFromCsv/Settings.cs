using System;
using System.Collections.Generic;
using System.Text;

namespace ContestWinnerFromCsv
{
    public class Settings
    {
        public string CsvLocation { get; set; }
        public int NumberOfWinners { get; set; }
        public DateTime StartDateTimeOfContest { get; set; }
        public DateTime EndDateTimeOfContest { get; set; }
    }
}
