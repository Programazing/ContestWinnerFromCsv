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
        private string CsvLocation { get; }
        private Random RNG { get; }

        public ContestWinner(string csvLocation, Settings settings = null, List<T> testData = null)
        {
            if (File.Exists(csvLocation))
            {
                CsvLocation = csvLocation;
            }
            else
            {
                throw new FileNotFoundException("File could not be found.", csvLocation);
            }

            Configuration.Initialize(settings);
            CsvRepository<T, TMap>.Initialize(testData);

            RNG = new Random();
        }

        public List<T> GetEntries()
        {
            var records = CsvRepository<T, TMap>.GetCsvData(CsvLocation);

            return records.Where(x => x.IsValid == true).Distinct().ToList();
        }

        public List<T> PickWinners()
        {
            var entries = GetEntries();
            var numberOfWinners = Configuration.Settings.NumberOfWinners;
            var winners = new List<T>();

            for (int i = 0; i < numberOfWinners; i++)
            {
                var winner = PickRandom(entries);
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
