using System;
using System.Collections.Generic;
using System.Text;
using DataWell;
using DataWellCore.core.Data.Collections;

namespace DataWellCore.core
{
    public class DataEnvironment
    {
        public static MemStorage MemStorage { get; set; }
        public static DataWellSettings DataWellSettings { get; set; }
    }
}
