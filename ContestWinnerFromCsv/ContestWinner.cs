using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ContestWinnerFromCsv
{
    public class ContestWinner<T, TMap> where T: class, ICsvModel
        where TMap : ClassMap
    {
        private Settings Settings { get; }
        private CsvRepository<T, TMap> Repository { get; }
        private Random RNG { get; }

        public ContestWinner(string csvLocation)
        {
            if (!File.Exists(csvLocation))
            {
                throw new FileNotFoundException("File could not be found.", csvLocation);
            }

            var configuration = new Configuration();

            Settings = configuration.Settings;

            Repository = new CsvRepository<T, TMap>(csvLocation);

            RNG = new Random();
        }

        public ContestWinner(Settings settings, IEnumerable<T> testData)
        {
            var configuration = new Configuration(settings);

            Settings = configuration.Settings;

            Repository = new CsvRepository<T, TMap>(testData);

            RNG = new Random();
        }

        public IEnumerable<T> GetEntries()
        {
            var records = Repository.GetCsvData();

            if(records.Count() <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(records), "CSV is Empty.");
            }

            foreach (var item in records)
            {
                item.SetTimeStampAndValidate(Settings.StartDateTimeOfContest, Settings.EndDateTimeOfContest);
            }

            return (IEnumerable<T>)records
                .Where(x => x.IsValid == true)
                .Distinct();
        }

        public IEnumerable<T> PickWinners()
        {
            var entries = GetEntries();
            var winners = new List<T>();

            if (entries.Count() == 1)
            {
                winners.Add(entries.FirstOrDefault());

                return winners;
            }
            
            var numberOfWinners = Settings.NumberOfWinners;

            for (int i = 0; i < numberOfWinners; i++)
            {
                var winner = PickRandom(entries.ToList());
                winners.Add(winner);
            }

            return winners;
        }

        T PickRandom(List<T> list)
        {
            return list[RNG.Next(list.Count)];
        }
    }
}
