using System;
using System.Collections.Generic;
using System.Text;

namespace DataWellCore.core.Protocol
{
    public class GetItemCommand : BaseCommand
    {
        public string DWID { get; set; }
        public string Collection { get; set; }
        public GetItemCommand(string dwid, string collection)
        {
            CommandName = Commands.GetItem;
            DWID = dwid;
            Collection = collection;
        }
    }
}
