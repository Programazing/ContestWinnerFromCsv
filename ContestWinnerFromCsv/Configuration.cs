using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ContestWinnerFromCsv
{
    internal static class Configuration
    {
        internal static Settings Settings { get; set; }

        internal static void Initialize()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            Settings = builder
                .GetSection("Settings")
                .Get<Settings>();
        }
    }
}
