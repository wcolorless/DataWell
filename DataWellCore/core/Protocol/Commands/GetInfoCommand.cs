using System;
using System.Collections.Generic;
using System.Text;

namespace DataWellCore.core.Protocol
{
    public class GetInfoCommand : BaseCommand
    {
        public GetInfoCommand()
        {
            CommandName = Commands.GetInfo;
        }
    }
}
