using System;
using System.Collections.Generic;
using System.Text;

namespace DataWellCore.core.Data.Collections
{
    [Serializable]
    public class DataItem : DataWellBaseEntity
    {
        public Dictionary<string, object> Rows = new Dictionary<string, object>();
    }
}
