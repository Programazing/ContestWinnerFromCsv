using System;
using System.Diagnostics.CodeAnalysis;

namespace ContestWinnerFromCsv.FormServices
{
    public class GoogleFormsCsvModel : ICsvModel
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

        private DateTime ContestStart { get; }
        private DateTime ContestEnd { get; }

        public GoogleFormsCsvModel(DateTime contestStart, DateTime contestEnd)
        {
            ContestStart = contestStart;
            ContestEnd = contestEnd;
        }

        public GoogleFormsCsvModel()
        {
            if (ContestStart == DateTime.MinValue && ContestEnd == DateTime.MinValue)
            {
                ContestStart = Configuration.Settings.StartDateTimeOfContest;
                ContestEnd = Configuration.Settings.EndDateTimeOfContest;
            }
        }

        private void SetTimeStampAndValidate(string timeStampInput)
        {
            TimeStamp = Convert.ToDateTime(timeStampInput.Remove(timeStampInput.Length - 4));

            if(TimeStamp >= ContestStart && TimeStamp < ContestEnd)
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
