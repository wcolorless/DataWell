using System;
using System.Collections.Generic;
using System.Text;

namespace DataWellCore.core.Protocol.Answers
{
    public class ErrorAnswer : BaseAnswer
    {
        public ErrorAnswer()
        {
            Type = AnswerTypes.Error;
        }
    }
}
