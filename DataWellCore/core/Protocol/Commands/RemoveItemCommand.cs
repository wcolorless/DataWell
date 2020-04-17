using System;
using System.Collections.Generic;
using System.Text;

namespace DataWellCore.core.Protocol
{
    public class RemoveItemCommand : BaseCommand
    {
        public string Collection { get; set; }
        public string DWID { get; set; }
        public RemoveItemCommand(string collection, string dwId)
        {
            DWID = dwId;
            Collection = collection;
            CommandName = Commands.RemoveItem;
        }
    }
}
