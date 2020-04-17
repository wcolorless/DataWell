using System;
using System.IO;
using DataWellCore.core;
using DataWellCore.core.Client;
using DataWellCore.core.Protocol;
using Microsoft.Extensions.Configuration;

namespace DataWell
{
    class Program
    {
        private static DataWellSettings _settings;
        static void Main(string[] args)
        {
            Console.WriteLine("Start DataWell");
            Init();
            var well = Well.GetWell(_settings, TransportTypes.WebSocket);
            for (;;);
        }

        private static void Init()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();
            var settingsSection = configuration.GetSection("DataWellSettings");
            _settings = new DataWellSettings()
            {
                Host = settingsSection["Host"],
                Port = settingsSection["Port"],
                MaxCollectionBinarySize = settingsSection["MaxCollectionBinarySize"],
                MaxCollectionSize = settingsSection["MaxCollectionSize"]
            };
        }
    }
}
