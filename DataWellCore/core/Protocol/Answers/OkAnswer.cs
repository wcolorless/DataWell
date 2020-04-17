using System;
using System.Collections.Generic;
using System.Text;

namespace DataWellCore.core.Protocol.Answers
{
    public class OkAnswer : BaseAnswer
    {
        public OkAnswer()
        {
            Type = AnswerTypes.Ok;
        }
    }
}
