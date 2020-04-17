using System;
using System.Collections.Generic;
using System.Text;
using DataWellCore.core.Data.Collections;

namespace DataWellCore.core.Protocol.Answers
{
    public class DataItemsAnswer : BaseAnswer
    {
        public List<DataItem> DataItems { get; set; }
        public DataItemsAnswer(List<DataItem> dataItems)
        {
            DataItems = dataItems;
            Type = AnswerTypes.DataItems;
        }
    }
}
