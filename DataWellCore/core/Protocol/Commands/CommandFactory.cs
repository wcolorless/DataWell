using System;
using System.Collections.Generic;
using System.Text;
using DataWellCore.core.Data.Collections;
using DataWellCore.core.Data.Filters;
using Newtonsoft.Json;

namespace DataWellCore.core.Protocol
{
    public enum Commands
    {
        AddNewCollection,
        RemoveCollection,
        AddNewDataItem,
        AddNewDataItems,
        UpdateItem,
        RemoveItem,
        GetItem,
        GetAll,
        GetInfo,
        Filter
    }

    /// <summary>
    /// Creates instances of command objects from the client for transport
    /// </summary>
    public class CommandFactory
    {
        public static string GetCommand(Commands command, object param1 = null, object param2 = null)
        {
            try
            {
                var result = string.Empty;
                switch (command)
                {
                    case Commands.AddNewCollection:
                        {
                            var cmd = new AddNewCollectionCommand((CollectionInfo)param1);
                            var json = JsonConvert.SerializeObject(cmd);
                            result = json;
                        }
                        break;
                    case Commands.AddNewDataItem:
                        {
                            var cmd = new AddNewDataItemCommand((DataItem)param1, (string)param2);
                            var json = JsonConvert.SerializeObject(cmd);
                            result = json;
                        }
                        break;
                    case Commands.AddNewDataItems:
                        {
                            var cmd = new AddNewDataItemsCommand((List<DataItem>)param1, (string)param2);
                            var json = JsonConvert.SerializeObject(cmd);
                            result = json;
                        }
                        break;
                    case Commands.GetItem:
                        {
                            var cmd = new GetItemCommand((string)param1, (string)param2);
                            var json = JsonConvert.SerializeObject(cmd);
                            result = json;
                        }
                        break;
                    case Commands.GetAll:
                        {
                            var cmd = new GetAllItemsCommand((string)param1);
                            var json = JsonConvert.SerializeObject(cmd);
                            result = json;
                        }
                        break;
                    case Commands.Filter:
                        {
                            var cmd = new FilterCommand((string)param1, (List<FilterParameter>)param2);
                            var json = JsonConvert.SerializeObject(cmd);
                            result = json;
                        }
                        break;
                    case Commands.RemoveItem:
                        {
                            var cmd = new RemoveItemCommand((string)param1, (string)param2);
                            var json = JsonConvert.SerializeObject(cmd);
                            result = json;
                        }
                        break;
                    case Commands.UpdateItem:
                        {
                            var cmd = new UpdateItemCommand((string)param1, (DataItem)param2);
                            var json = JsonConvert.SerializeObject(cmd);
                            result = json;
                        }
                        break;
                    case Commands.RemoveCollection:
                        {
                            var cmd = new RemoveCollectionCommand((string)param1);
                            var json = JsonConvert.SerializeObject(cmd);
                            result = json;
                        }
                        break;
                    case Commands.GetInfo:
                        {
                            var cmd = new GetInfoCommand();
                            var json = JsonConvert.SerializeObject(cmd);
                            result = json;
                        } break;
                    default: break;
                }

                return result;
            }
            catch (Exception e)
            {
                throw new Exception($"CommandFactory GetCommand Error: {e.Message}");
            }
        }
    }
}
