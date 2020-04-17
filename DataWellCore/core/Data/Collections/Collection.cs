using System;
using System.Collections.Generic;
using System.Text;
using DataWellCore.core.Data.Collections;

namespace DataWellCore.core.Data.Collections
{
    [Serializable]
    public class Collection
    {
        public string Name { get; set; }
        public List<Property> Properties { get; set; } = new List<Property>();
        public List<DataItem> DataItems { get; set; } = new List<DataItem>();
    }
}
