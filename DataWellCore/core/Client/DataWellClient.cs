using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataWellCore.core.Data;
using DataWellCore.core.Data.Collections;
using DataWellCore.core.Data.Collections.Reflection;
using DataWellCore.core.Data.Filters;
using DataWellCore.core.Protocol;
using DataWellCore.core.Protocol.Answers;
using Newtonsoft.Json;

namespace DataWellCore.core.Client
{
    public interface IDWClient
    {
        void Save(string collection, object item);
        void SavePack(string collection, List<object> items);
        Task<T> GetItem<T>(string collection, string dwId);
        Task<List<T>> GetAll<T>(string collection);
        IFilter Filter(string collection);
        void Update(string collection, object item);
        void Remove(string collection, string dwId);
        bool AddCollection(string name, object type);
        void RemoveCollection(string name);
        DataWellInfo GetInfo();
        string SendCommand(string command);
    }

    /// <summary>
    /// Client for interacting with a data well
    /// </summary>
    public class DataWellClient : IDWClient
    {
        private IClientTransport _transport;
        public DataWellClient(string Host, string Port, TransportTypes transportType)
        {
            switch (transportType)
            {
                case TransportTypes.WebSocket:
                    _transport = new WSClientTransport(Host, Port);
                    break;
                case TransportTypes.Http:
                    throw new NotImplementedException();
                    break;
                default: throw new Exception("This type of transport is not supported");
            }
        }

        public void Save(string collection, object item)
        {
            try
            {
                var data = Reflector.GetData(item);
                var command = CommandFactory.GetCommand(Commands.AddNewDataItem, data, collection);
                _transport.SendMessage(command);
            }
            catch (Exception e)
            {
                throw new Exception($"DataWellClient Save Error: {e.Message}");
            }
        }

        public void SavePack(string collection, List<object> items)
        {
            var dataList = new List<DataItem>();
            try
            {
                dataList.AddRange(items.Select(Reflector.GetData));
                var command = CommandFactory.GetCommand(Commands.AddNewDataItems, dataList, collection);
                _transport.SendMessage(command);
            }
            catch (Exception e)
            {
                throw new Exception($"DataWellClient SavePack Error: {e.Message}");
            }
        }

        public bool AddCollection(string name, object type)
        {
            try
            {
                var info = Reflector.GetCollectionInfo(name, type);
                var command = CommandFactory.GetCommand(Commands.AddNewCollection, info, name);
                _transport.SendMessage(command);
                var answer = _transport.GetAnswer();
                return AnswerFactory.IsOk(answer);
            }
            catch (Exception e)
            {
                throw new Exception($"DataWellClient AddCollection Error: {e.Message}");
            }
        }

        public void RemoveCollection(string name)
        {
            try
            {
                var command = CommandFactory.GetCommand(Commands.RemoveCollection, name);
                _transport.SendMessage(command);
                var answer = _transport.GetAnswer();
            }
            catch (Exception e)
            {
                throw new Exception($"DataWellClient RemoveCollection Error: {e.Message}");
            }
        }

        public string SendCommand(string command)
        {
            try
            {
                _transport.SendMessage(command);
                var answer = _transport.GetAnswer();
                return answer;
            }
            catch (Exception e)
            {
                throw new Exception($"DataWellClient SendCommand Error: {e.Message}");
            }
        }

        public DataWellInfo GetInfo()
        {
            try
            {
                var command = CommandFactory.GetCommand(Commands.GetInfo);
                _transport.SendMessage(command);
                var answer = _transport.GetAnswer();
                if (AnswerFactory.CheckAnswerType(AnswerTypes.Info, answer))
                {
                    var objAnswer = JsonConvert.DeserializeObject<DataWellInfoAnswer>(answer);
                    var result = objAnswer.DataWellInfo;
                    return result;
                }
                else
                {
                    throw new Exception($"Answer Type Error");
                }
            }
            catch (Exception e)
            {
                throw new Exception($"DataWellClient GetInfo Error: {e.Message}");
            }
        }

        public async Task<T> GetItem<T>(string collection, string dwId)
        {
            try
            {
                var command = CommandFactory.GetCommand(Commands.GetItem, dwId, collection);
                _transport.SendMessage(command);
                var answer = _transport.GetAnswer();
                var objAnswer = JsonConvert.DeserializeObject<DataItemAnswer>(answer);
                var obj = Reflector.SetData<T>(objAnswer.DataItem);
                return obj;
            }
            catch (Exception e)
            {
                throw new Exception($"DataWellClient GetItem Error: {e.Message}");
            }
        }

        public async Task<List<T>> GetAll<T>(string collection)
        {
            var result = new List<T>();
            try
            {
                var command = CommandFactory.GetCommand(Commands.GetAll, collection);
                _transport.SendMessage(command);
                var answer = _transport.GetAnswer();
                var objAnswer = JsonConvert.DeserializeObject<DataItemsAnswer>(answer);
                foreach (var item in objAnswer.DataItems)
                {
                    var obj = Reflector.SetData<T>(item);
                    result.Add(obj);
                }
                return result;
            }
            catch (Exception e)
            {
                throw new Exception($"DataWellClient GetAll Error: {e.Message}");
            }
        }

        public IFilter Filter(string collection)
        {
            try
            {
                var filter = new Filter(this, collection);
                return filter;
            }
            catch (Exception e)
            {
                throw new Exception($"DataWellClient Filter Error: {e.Message}");
            }
        }

        public void Update(string collection, object item)
        {
            try
            {
                var data = Reflector.GetData(item);
                var command = CommandFactory.GetCommand(Commands.UpdateItem, collection, data);
                _transport.SendMessage(command);
            }
            catch (Exception e)
            {
                throw new Exception($"DataWellClient Remove Error: {e.Message}");
            }
        }

        public void Remove(string collection, string dwId)
        {
            try
            {
                var command = CommandFactory.GetCommand(Commands.RemoveItem, collection, dwId);
                _transport.SendMessage(command);
            }
            catch (Exception e)
            {
                throw new Exception($"DataWellClient Remove Error: {e.Message}");
            }
        }
    }
}
