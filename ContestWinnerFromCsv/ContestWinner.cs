using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ContestWinnerFromCsv
{
    public class ContestWinner
    {
        private string CsvLocation { get; }
        private Random RNG { get; }

        public ContestWinner(string csvLocation, Settings settings = null)
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

            RNG = new Random();
        }

        public List<GoogleFormsCsvModel> GetEntries()
        {
            var records = CsvRepository.GetCsvData<GoogleFormsCsvModel, GoogleFormsCsvMap>(CsvLocation);

            return records.Where(x => x.IsValid == true).Distinct().ToList();
        }

        public List<GoogleFormsCsvModel> PickWinners()
        {
            var entries = GetEntries();
            var numberOfWinners = Configuration.Settings.NumberOfWinners;
            var winners = new List<GoogleFormsCsvModel>();

            for (int i = 0; i < numberOfWinners; i++)
            {
                var winner = PickRandom<GoogleFormsCsvModel>(entries);
                winners.Add(winner);
            }

            return winners;
        }

        T PickRandom<T>(List<T> list)
        {
            return list[RNG.Next(list.Count)];
        }
    }
}
