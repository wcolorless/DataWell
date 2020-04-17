using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace DataWellCore.core.Data.Collections
{
    public class Options
    {
        public static long GetStorageSize(object collections)
        {
            try
            {
                long size = 0;
                using (Stream s = new MemoryStream())
                {
                    var formatter = new BinaryFormatter();
                    formatter.Serialize(s, collections);
                    size = s.Length;
                }
                return size;
            }
            catch (Exception e)
            {
                throw new Exception($"Options GetStorageSize Error: {e.Message}");
            }
        }
    }
}
