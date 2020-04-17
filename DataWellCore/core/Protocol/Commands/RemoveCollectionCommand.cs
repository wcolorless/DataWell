using System;
using System.Collections.Generic;
using System.Text;

namespace DataWellCore.core.Protocol
{
    public class RemoveCollectionCommand : BaseCommand
    {
        public string Collection { get; set; }
        public RemoveCollectionCommand(string collection)
        {
            Collection = collection;
            CommandName = Commands.RemoveCollection;
        }
    }
}
