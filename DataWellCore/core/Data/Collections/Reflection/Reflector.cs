using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataWellCore.core.Data.Collections.Reflection
{
    /// <summary>
    /// Converts data to a data well format
    /// </summary>
    public class Reflector
    {
        public static CollectionInfo GetCollectionInfo(string collectionName, object inputType)
        {
            try
            {
                var result = new CollectionInfo()
                {
                    Name = collectionName
                };
                var type = inputType.GetType();
                var properties = type.GetProperties();
                foreach (var property in properties)
                {
                    if (!result.Properties.Exists(x => x.Name == property.Name))
                    {
                        result.Properties.Add(new Property()
                        {
                            Name = property.Name,
                            Type = property.PropertyType.FullName
                        });
                    }
                }
                return result;
            }
            catch (Exception e)
            {
                throw new Exception($"Reflector GetCollectionInfo Error: {e.Message}");
            }
        }

        public static DataItem GetData(object inputData)
        {
            try
            {
                var result = new DataItem();
                var itemType = result.GetType();
                var itemTypeProperties = itemType.GetProperties().ToList();
                var type = inputData.GetType();
                var properties = type.GetProperties();
                var idDWProperty = itemTypeProperties.FirstOrDefault(x => x.Name == "DWID");
                var idProperty = properties.FirstOrDefault(x => x.Name == "DWID");
                if(idProperty == null) throw new Exception($"Reflector GetData Error: Not found DWID property in input object");
                foreach (var property in properties)
                {
                    if (property.Name == "DWID")
                    {
                        idDWProperty.SetValue(result, property.GetValue(inputData));
                    }
                    else
                    {
                        result.Rows.Add(property.Name, property.GetValue(inputData));
                    }
                }
                return result;
            }
            catch (Exception e)
            {
                throw new Exception($"Reflector GetData Error: {e.Message}");
            }
        }

        public static T SetData<T>(DataItem inputData)
        {
            try
            {
                var itemType = typeof(T);
                var itemTypeProperties = itemType.GetProperties();
                var obj =  Activator.CreateInstance<T>();
                foreach (var property in itemTypeProperties)
                {
                    var propType = property.PropertyType;
                    var objProp = Convert.ChangeType(property.Name != "DWID" ? inputData.Rows[property.Name] : inputData.DWID, propType);
                    property.SetValue(obj, property.Name != "DWID" ? objProp : inputData.DWID);
                }
                return obj;
            }
            catch (Exception e)
            {
                throw new Exception($"Reflector SetData Error: {e.Message}");
            }
        }
    }
}
