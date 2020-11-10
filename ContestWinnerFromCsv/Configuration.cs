using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ContestWinnerFromCsv
{
    internal class Configuration
    {
        internal Settings Settings { get; set; }

        internal Configuration(Settings settings = null)
        {
            if (settings == null)
            {
                var builder = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                        .Build();

                Settings = builder
                    .GetSection("Settings")
                    .Get<Settings>(); 
            }
            else
            {
                Settings = settings;
            }
        }
    }
}
