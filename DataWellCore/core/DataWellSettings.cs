using System;
using System.Collections.Generic;
using System.Text;

namespace DataWell
{
    /// <summary>
    /// Server Application Settings
    /// </summary>
    public class DataWellSettings
    {
        public string Host { get; set; }
        public string Port { get; set; }
        public string MaxCollectionBinarySize { get; set; }
        public string MaxCollectionSize { get; set; }
    }
}
