using CsvHelper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace ContestWinnerFromCsv
{
    public class ContestWinner
    {
        public string CsvLocation { get; set; }
        private Random RNG;


        public ContestWinner(string csvLocation)
        {
            if (File.Exists(csvLocation))
            {
                CsvLocation = csvLocation;
            }
            else
            {
                throw new FileNotFoundException("File could not be found.", csvLocation);
            }

            Configuration.Initialize();
            RNG = new Random();
        }

        public List<GoogleFormsCsvModel> GetEntries()
        {
            using var reader = new StreamReader(CsvLocation);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            csv.Configuration.RegisterClassMap<GoogleFormsCsvMap>();
            var records = csv.GetRecords<GoogleFormsCsvModel>();

            return records.Where(x => x.IsValid == true).ToList();
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
