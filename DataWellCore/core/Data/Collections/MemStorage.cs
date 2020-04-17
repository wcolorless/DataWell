using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using DataWellCore.core.Data.Filters;

namespace DataWellCore.core.Data.Collections
{
    /// <summary>
    /// Data Warehouse (storage in RAM)
    /// </summary>
    public class MemStorage
    {
        private List<Collection> _collections = new List<Collection>();

        public MemStorage()
        {

        }

        public bool AddCollection(CollectionInfo collectionInfo)
        {
            try
            {
                if (!_collections.Exists(x => x.Name == collectionInfo.Name))
                {
                    _collections.Add(new Collection()
                    {
                        Name = collectionInfo.Name,
                        Properties = collectionInfo.Properties
                    });
                    return true;
                }

                return false;
            }
            catch (Exception e)
            {
                throw new Exception($"MemStorage AddCollection Error: {e.Message}");
            }
        }

        public void RemoveCollection(string collectionName)
        {
            try
            {
                if (_collections.Exists(x => x.Name == collectionName))
                {
                    _collections.RemoveAll(x => x.Name == collectionName);
                }
            }
            catch (Exception e)
            {
                throw new Exception($"MemStorage RemoveCollection Error: {e.Message}");
            }
        }

        public void AddDataItem(DataItem dataItem, string collectionName)
        {
            var canWrite = true;
            try
            {
                if (_collections.Exists(x => x.Name == collectionName))
                {
                    var collection = _collections.Find(x => x.Name == collectionName);
                    if (DataEnvironment.DataWellSettings != null)
                    {
                       var maxSize = int.Parse(DataEnvironment.DataWellSettings.MaxCollectionSize);
                       if (collection.DataItems.Count >= maxSize)
                       {
                           canWrite = false;
                       }
                    }
                    if(canWrite) collection.DataItems.Add(dataItem);
                }
            }
            catch (Exception e)
            {
                throw new Exception($"MemStorage AddDataItem Error: {e.Message}");
            }
        }

        public void AddDataItems(List<DataItem> dataItems, string collectionName)
        {
            var canWrite = true;
            try
            {
                if (_collections.Exists(x => x.Name == collectionName))
                {
                    var collection = _collections.Find(x => x.Name == collectionName);
                    if (DataEnvironment.DataWellSettings != null)
                    {
                        var maxSize = int.Parse(DataEnvironment.DataWellSettings.MaxCollectionSize);
                        if (collection.DataItems.Count >= maxSize)
                        {
                            canWrite = false;
                        }

                        if ((collection.DataItems.Count + dataItems.Count) >= maxSize)
                        {
                            canWrite = false;
                        }
                    }
                    if (canWrite) collection.DataItems.AddRange(dataItems);
                }
            }
            catch (Exception e)
            {
                throw new Exception($"MemStorage AddDataItem Error: {e.Message}");
            }
        }

        public DataItem GetItem(string collectionName, string dwid)
        {
            try
            {
                DataItem result = null;
                if (_collections.Exists(x => x.Name == collectionName))
                {
                    var collection = _collections.Find(x => x.Name == collectionName);
                    result = collection.DataItems.FirstOrDefault(x => x.DWID == dwid);
                }
                return result;
            }
            catch (Exception e)
            {
                throw new Exception($"MemStorage GetItem Error: {e.Message}");
            }
        }

        public List<DataItem> GetAll(string collectionName)
        {
            var result = new List<DataItem>();
            try
            {
                if (_collections.Exists(x => x.Name == collectionName))
                {
                    var collection = _collections.Find(x => x.Name == collectionName);
                    result.AddRange(collection.DataItems);
                }
            }
            catch (Exception e)
            {
                throw new Exception($"MemStorage GetAll Error: {e.Message}");
            }

            return result;
        }

        public List<DataItem> GetFilteredItems(string collectionName, List<FilterParameter> filterParameters)
        {
            var result = new List<DataItem>();
            try
            {
                if (_collections.Exists(x => x.Name == collectionName))
                {
                    var collection = _collections.Find(x => x.Name == collectionName);
                    foreach (var filterParameter in filterParameters)
                    {
                        var preResult = Filter(collection, filterParameter);
                        collection = new Collection()
                        {
                            Name = collection.Name,
                            Properties = collection.Properties,
                            DataItems = preResult
                        };
                    }
                    result.AddRange(collection.DataItems);
                }
            }
            catch (Exception e)
            {
                throw new Exception($"MemStorage GetFilteredItems Error: {e.Message}");
            }

            return result;
        }

        private List<DataItem> Filter(Collection collection, FilterParameter parameter)
        {
            try
            {
                var result = new List<DataItem>();
                var propertyName = parameter.Property;
                var value = parameter.Value;
                var items = collection.DataItems;
                if (!propertyName.Contains("."))
                {
                    if (parameter.Type == FilterType.Equal && propertyName == "DWID")
                    {
                        var preResult = collection.DataItems.Where(x => x.DWID == (string)value).ToList();
                        result.AddRange(preResult);
                    }
                    else if (parameter.Type == FilterType.NotEqual && propertyName == "DWID")
                    {
                        var preResult = collection.DataItems.Where(x => x.DWID != (string)value).ToList();
                        result.AddRange(preResult);
                    }
                    else
                    {
                        var property = collection.Properties.Find(x => x.Name == propertyName);
                        for (var i = 0; i < items.Count; i++)
                        {
                            if (FilterActor.Check(parameter.Type, items[i].Rows[propertyName], value, property.Type))
                            {
                                result.Add(items[i]);
                            }
                        }
                    }
                }
                else { }
                return result;
            }
            catch (Exception e)
            {
                throw new Exception($"MemStorage Filter Error: {e.Message}");
            }
        }

        public void UpdateItem(string collectionName, DataItem item)
        {
            try
            {
                if (_collections.Exists(x => x.Name == collectionName))
                {
                    var collection = _collections.Find(x => x.Name == collectionName);
                    if (collection.DataItems.Exists(x => x.DWID == item.DWID))
                    {
                        collection.DataItems.RemoveAll(x => x.DWID == item.DWID);
                        collection.DataItems.Add(item);
                    }
                    else
                    {
                        collection.DataItems.Add(item);
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception($"MemStorage UpdateItem Error: {e.Message}");
            }
        }

        public void RemoveItem(string collectionName, string dwId)
        {
            try
            {
                if (_collections.Exists(x => x.Name == collectionName))
                {
                    var collection = _collections.Find(x => x.Name == collectionName);
                    if (collection.DataItems.Exists(x => x.DWID == dwId))
                    {
                        collection.DataItems.RemoveAll(x => x.DWID == dwId);
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception($"MemStorage RemoveItem Error: {e.Message}");
            }
        }

        public DataWellInfo GetInfo()
        {
            try
            {
                var result = new DataWellInfo();
                foreach (var collection in _collections)
                {
                    result.CollectionsInfo.Add(new DataWellCollectionInfo()
                    {
                        Name = collection.Name,
                        Properties = collection.Properties,
                        Size = collection.DataItems.Count,
                        ByteSize = Options.GetStorageSize(collection)
                    });
                }
                return result;
            }
            catch (Exception e)
            {
                throw new Exception($"MemStorage GetInfo Error: {e.Message}");
            }
        }

    }
}
