using System;
using System.Collections.Generic;
using System.Text;
using DataWellCore.core.Data;
using DataWellCore.core.Data.Collections;
using Newtonsoft.Json;

namespace DataWellCore.core.Protocol.Answers
{
    /// <summary>
    /// Creates instance response objects for data transport
    /// </summary>
    public class AnswerFactory
    {
        public static bool IsOk(string answer)
        {
            try
            {
                if (string.IsNullOrEmpty(answer)) return false;
                var obj = JsonConvert.DeserializeObject<BaseAnswer>(answer);
                return obj.Type == AnswerTypes.Ok;
            }
            catch (Exception e)
            {
                throw new Exception($"AnswerFactory IsOk Error: {e.Message}");
            }
        }

        public static DataItemAnswer GetDataItemAnswer(DataItem dataItem)
        {
            try
            {
                var result = new DataItemAnswer(dataItem);
                return result;
            }
            catch (Exception e)
            {
                throw new Exception($"AnswerFactory GetDataItemAnswer Error: {e.Message}");
            }
        }

        public static DataItemsAnswer GetDataItemsAnswer(List<DataItem> dataItems)
        {
            try
            {
                var result = new DataItemsAnswer(dataItems);
                return result;
            }
            catch (Exception e)
            {
                throw new Exception($"AnswerFactory GetDataItemsAnswer Error: {e.Message}");
            }
        }

        public static DataWellInfoAnswer GetDataWellInfoAnswer(DataWellInfo dataWellInfo)
        {
            try
            {
                var result = new DataWellInfoAnswer(dataWellInfo);
                return result;
            }
            catch (Exception e)
            {
                throw new Exception($"AnswerFactory GetDataWellInfoAnswer Error: {e.Message}");
            }
        }

        public static bool CheckAnswerType(AnswerTypes expectedType, string answer)
        {
            try
            {
                var baseObj = JsonConvert.DeserializeObject<BaseAnswer>(answer);
                return baseObj.Type == expectedType;
            }
            catch (Exception e)
            {
                throw new Exception($"AnswerFactory CheckAnswerType Error: {e.Message}");
            }
        }
    }
}
