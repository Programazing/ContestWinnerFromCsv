using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace ContestWinnerFromCsv.FormServices
{
    public class TypeFormCsvModel : ICsvModel
    {
        public DateTime TimeStamp { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string TwitterName { get; set; }
        public bool IsValid { get; set; } = false;

        public void SetTimeStampAndValidate(DateTime contestStart, DateTime contestEnd)
        {
            if (TimeStamp >= contestStart && TimeStamp < contestEnd)
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
            return Equals(obj as TypeFormCsvModel);
        }

        public bool Equals([AllowNull] TypeFormCsvModel other)
        {
            if (Email == other.Email && TwitterName == other.TwitterName)
            {
                return true;
            }

            return false;
        }
    }
}
