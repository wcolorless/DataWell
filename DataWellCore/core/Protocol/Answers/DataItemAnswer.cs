using System;
using System.Collections.Generic;
using System.Text;
using DataWellCore.core.Data.Collections;

namespace DataWellCore.core.Protocol.Answers
{
    public class DataItemAnswer : BaseAnswer
    {
        public DataItem DataItem { get; set; }
        public DataItemAnswer(DataItem dataItem)
        {
            DataItem = dataItem;
            Type = AnswerTypes.DataItem;
        }
    }
}
