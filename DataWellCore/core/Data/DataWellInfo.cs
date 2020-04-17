using System;
using System.Collections.Generic;
using System.Text;
using DataWellCore.core.Data.Collections;

namespace DataWellCore.core.Data
{
    public class DataWellInfo
    {
        public List<DataWellCollectionInfo> CollectionsInfo { get; set; }

        public DataWellInfo()
        {
            CollectionsInfo = new List<DataWellCollectionInfo>();
        }
    }
}
