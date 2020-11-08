using System;
using System.Diagnostics.CodeAnalysis;

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

        public override int GetHashCode()
        {
            return TwitterName.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as GoogleFormsCsvModel);
        }

        public bool Equals([AllowNull] GoogleFormsCsvModel other)
        {
            if (Email == other.Email && TwitterName == other.TwitterName)
            {
                return true;
            }

            return false;
        }
    }
}
