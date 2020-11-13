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
        private ICsvRepository<T, TMap> Repository { get; }
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

        public ContestWinner(Settings settings, ICsvRepository<T, TMap> testRepository)
        {
            var configuration = new Configuration(settings);

            Settings = configuration.Settings;

            Repository = testRepository;

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

            return records
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
                var winner = PickRandom(entries);
                winners.Add(winner);
            }

            return winners;
        }

        T PickRandom(IEnumerable<T> list)
        {
            var next = RNG.Next(list.Count());
            return list.ElementAtOrDefault<T>(next);
        }
    }
}
