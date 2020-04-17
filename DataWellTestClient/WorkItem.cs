using System;
using System.Collections.Generic;
using System.Text;
using DataWellCore.core.Data;

namespace DataWellTestClient
{
    public class WorkItem : DataWellBaseEntity
    {
        public string Name { get; set; }
        public DateTime Time { get; set; }
        public int Num { get; set; }
    }
}
