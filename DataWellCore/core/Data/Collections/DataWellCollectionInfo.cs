using System;
using System.Collections.Generic;
using System.Text;

namespace DataWellCore.core.Data.Collections
{
    public class DataWellCollectionInfo
    {
        public string Name { get; set; }
        public List<Property> Properties { get; set; } = new List<Property>();
        public long ByteSize { get; set; }
        public long Size { get; set; }
    }
}
