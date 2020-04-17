using System;
using System.Collections.Generic;
using System.Text;

namespace DataWellCore.core.Data.Collections
{
    public class CollectionInfo
    {
        public string Name { get; set; }
        public List<Property> Properties { get; set; } = new List<Property>();
    }
}
