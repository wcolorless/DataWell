using System;
using System.Collections.Generic;
using System.Text;

namespace DataWellCore.core.Protocol
{
    public class GetAllItemsCommand : BaseCommand
    {
        public string Collection { get; set; }
        public GetAllItemsCommand(string collection)
        {
            Collection = collection;
            CommandName = Commands.GetAll;
        }
    }
}
