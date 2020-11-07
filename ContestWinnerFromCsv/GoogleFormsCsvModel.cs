using CsvHelper.Configuration.Attributes;
using Microsoft.Extensions.Configuration;
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
        public bool IsValid { get; set; } = false;

        public string TimeStampInput
        {
            get { return time; }
            set
            {
                SetTimeStampAndValidate(value);
                time = value;
            }
        }

        private void SetTimeStampAndValidate(string timeStampInput)
        {
            TimeStamp = Convert.ToDateTime(timeStampInput.Remove(timeStampInput.Length - 4));

            var start = Configuration.Settings.StartDateTimeOfContest;
            var end = Configuration.Settings.EndDateTimeOfContest;

            if(TimeStamp >= start && TimeStamp < end)
            {
                IsValid = true;
            }
        }
    }
}
