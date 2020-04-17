using System;
using System.Collections.Generic;
using System.Text;
using DataWellCore.core.Client;
using DataWellCore.core.Data.Collections.Reflection;
using DataWellCore.core.Protocol;
using DataWellCore.core.Protocol.Answers;
using Newtonsoft.Json;

namespace DataWellCore.core.Data.Filters
{

    /// <summary>
    /// Filters data by specified parameters
    /// </summary>
    public class Filter : IFilter
    {
        private string _collection;
        private readonly IDWClient _dwClient;
        private List<FilterParameter> _filterParameters = new List<FilterParameter>();
        public Filter(IDWClient dwClient, string collection)
        {
            _dwClient = dwClient;
            _collection = collection;
        }

        public IFilter Equal(string property, object value)
        {
            _filterParameters.Add(new FilterParameter()
            {
                Type = FilterType.Equal,
                Property = property,
                Value = value
            });
            return this;
        }

        public IFilter NotEqual(string property, object value)
        {
            _filterParameters.Add(new FilterParameter()
            {
                Type = FilterType.NotEqual,
                Property = property,
                Value = value
            });
            return this;
        }

        public IFilter Greater(string property, object value)
        {
            _filterParameters.Add(new FilterParameter()
            {
                Type = FilterType.Greater,
                Property = property,
                Value = value
            });
            return this;
        }

        public IFilter Less(string property, object value)
        {
            _filterParameters.Add(new FilterParameter()
            {
                Type = FilterType.Less,
                Property = property,
                Value = value
            });
            return this;
        }

        public IFilter GreaterOrEqual(string property, object value)
        {
            _filterParameters.Add(new FilterParameter()
            {
                Type = FilterType.GreaterOrEqual,
                Property = property,
                Value = value
            });
            return this;
        }

        public IFilter LessOrEqual(string property, object value)
        {
            _filterParameters.Add(new FilterParameter()
            {
                Type = FilterType.LessOrEqual,
                Property = property,
                Value = value
            });
            return this;
        }

        public List<T> Go<T>()
        {
            var result = new List<T>();
            try
            {
                var command = CommandFactory.GetCommand(Commands.Filter, _collection, _filterParameters);
                var answer = _dwClient.SendCommand(command);
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
                throw new Exception($"Filter Go Error: {e.Message}");
            }
        }
    }

    public class FilterParameter
    {
        public FilterType Type { get; set; }
        public string Property { get; set; }
        public object Value { get; set; }
    }

    public enum FilterType
    {
        Equal,
        NotEqual,
        Greater,
        Less,
        GreaterOrEqual,
        LessOrEqual
    }
}
