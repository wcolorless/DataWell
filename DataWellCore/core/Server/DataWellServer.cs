using System;
using System.Collections.Generic;
using System.Text;
using DataWellCore.core.Protocol;
using DataWellCore.core.Protocol.Answers;
using Newtonsoft.Json;

namespace DataWellCore.core.Server
{
    /// <summary>
    /// Handles commands from a client
    /// </summary>
    public class DataWellServer
    {
        public string Handle(string message)
        {
            try
            {
                var result = string.Empty;
                var baseCommand = JsonConvert.DeserializeObject<BaseCommand>(message);
                switch (baseCommand.CommandName)
                {
                    case Commands.AddNewCollection:
                        {
                            var addCommand = JsonConvert.DeserializeObject<AddNewCollectionCommand>(message);
                            var commandResult = DataEnvironment.MemStorage.AddCollection(addCommand.CollectionInfo);
                            return commandResult ? JsonConvert.SerializeObject(new OkAnswer()) : JsonConvert.SerializeObject(new ErrorAnswer());
                        }
                        break;
                    case Commands.AddNewDataItem:
                        {
                            var addItemCommand = JsonConvert.DeserializeObject<AddNewDataItemCommand>(message);
                            DataEnvironment.MemStorage.AddDataItem(addItemCommand.DataItem, addItemCommand.Collection);
                        }
                        break;
                    case Commands.AddNewDataItems:
                        {
                            var addItemsCommand = JsonConvert.DeserializeObject<AddNewDataItemsCommand>(message);
                            DataEnvironment.MemStorage.AddDataItems(addItemsCommand.DataItems, addItemsCommand.Collection);
                        }
                        break;
                    case Commands.GetItem:
                        {
                            var getItemCommand = JsonConvert.DeserializeObject<GetItemCommand>(message);
                            var dataItem = DataEnvironment.MemStorage.GetItem(getItemCommand.Collection, getItemCommand.DWID);
                            var answer = AnswerFactory.GetDataItemAnswer(dataItem);
                            result = JsonConvert.SerializeObject(answer);
                        }
                        break;
                    case Commands.GetAll:
                        {
                            var getAllCommand = JsonConvert.DeserializeObject<GetAllItemsCommand>(message);
                            var dataItems = DataEnvironment.MemStorage.GetAll(getAllCommand.Collection);
                            var answerList = AnswerFactory.GetDataItemsAnswer(dataItems);
                            result = JsonConvert.SerializeObject(answerList);
                        }
                        break;
                    case Commands.Filter:
                        {
                            var filterCommand = JsonConvert.DeserializeObject<FilterCommand>(message);
                            var dataFilteredItems = DataEnvironment.MemStorage.GetFilteredItems(filterCommand.Collection, filterCommand.FilterParameters);
                            var answerFilteredList = AnswerFactory.GetDataItemsAnswer(dataFilteredItems);
                            result = JsonConvert.SerializeObject(answerFilteredList);
                        }
                        break;
                    case Commands.RemoveItem:
                        {
                            var command = JsonConvert.DeserializeObject<RemoveItemCommand>(message);
                            DataEnvironment.MemStorage.RemoveItem(command.Collection, command.DWID);
                        }
                        break;
                    case Commands.UpdateItem:
                        {
                            var command = JsonConvert.DeserializeObject<UpdateItemCommand>(message);
                            DataEnvironment.MemStorage.UpdateItem(command.Collection, command.DataItem);
                        }
                        break;
                    case Commands.RemoveCollection:
                        {
                            var command = JsonConvert.DeserializeObject<RemoveCollectionCommand>(message);
                            DataEnvironment.MemStorage.RemoveCollection(command.Collection);
                        }
                        break;
                    case Commands.GetInfo:
                        {
                            var command = JsonConvert.DeserializeObject<GetInfoCommand>(message);
                            var obj = DataEnvironment.MemStorage.GetInfo();
                            var answerGetInfo = AnswerFactory.GetDataWellInfoAnswer(obj);
                            result = JsonConvert.SerializeObject(answerGetInfo);
                        }
                        break;
                    default: break;
                }

                return result;
            }
            catch (Exception e)
            {
                throw new Exception($"DataWellServer Handle Error: {e.Message}");
            }
        }
    }
}
