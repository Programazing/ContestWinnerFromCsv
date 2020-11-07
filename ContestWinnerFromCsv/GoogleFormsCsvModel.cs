using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace ContestWinnerFromCsv
{
    public class GoogleFormsCsvModel
    {
        public DateTime TimeStamp { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string TwitterName { get; set; }

        private string time;

        public string TimeStampInput
        {
            get { return time; }
            set
            {
                SetTimeStampFromTimeStampInput(value);
                time = value;
            }
        }

        private void SetTimeStampFromTimeStampInput(string timeStampInput)
        {
            TimeStamp = Convert.ToDateTime(timeStampInput.Remove(timeStampInput.Length - 4));
        }
    }
}
