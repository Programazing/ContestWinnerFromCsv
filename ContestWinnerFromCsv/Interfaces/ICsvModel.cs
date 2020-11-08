using System;

namespace ContestWinnerFromCsv
{
    public interface ICsvModel
    {
        public DateTime TimeStamp { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string TwitterName { get; set; }
        public bool IsValid { get; set; }
    }
}