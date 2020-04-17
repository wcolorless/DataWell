using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataWellCore.core.Client
{
    public interface IClientTransport
    {
        void SendMessage(string message);
        string GetAnswer();
    }
}
