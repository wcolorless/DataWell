using System;
using System.Collections.Generic;
using System.Text;
using DataWellCore.core.Data;

namespace DataWellCore.core.Protocol.Answers
{
    public class DataWellInfoAnswer : BaseAnswer
    {
        public DataWellInfo DataWellInfo { get; set; }
        public DataWellInfoAnswer(DataWellInfo dataWellInfo)
        {
            DataWellInfo = dataWellInfo;
            Type = AnswerTypes.Info;
        }
    }
}
