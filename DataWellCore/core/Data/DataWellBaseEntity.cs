using System;
using System.Collections.Generic;
using System.Text;

namespace DataWellCore.core.Data
{
    [Serializable]
    public class DataWellBaseEntity
    {
        public string DWID { get; set; }
        
        public DataWellBaseEntity()
        {
            DWID = Guid.NewGuid().ToString();
        }
    }
}
