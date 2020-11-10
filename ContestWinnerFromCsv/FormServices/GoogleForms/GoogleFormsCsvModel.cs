using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace ContestWinnerFromCsv.FormServices
{
    public class GoogleFormsCsvModel : ICsvModel
    {
        public DateTime TimeStamp { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string TwitterName { get; set; }
        public bool IsValid { get; set; } = false;
        public string TimeStampInput { get; set; }

        public GoogleFormsCsvModel()
        {

        }

        public void SetTimeStampAndValidate(DateTime contestStart, DateTime contestEnd)
        {
            TimeStamp = Convert.ToDateTime(TimeStampInput.Remove(TimeStampInput.Length - 4));

            if(TimeStamp >= contestStart && TimeStamp < contestEnd)
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
