using System;
using System.Collections.Generic;
using System.Text;
using DataWellCore.core.Data.Collections;

namespace DataWellCore.core.Protocol
{
    public class UpdateItemCommand : BaseCommand
    {
        public string Collection { get; set; }
        public DataItem DataItem { get; set; }
        public UpdateItemCommand(string collection, DataItem dataItem)
        {
            CommandName = Commands.UpdateItem;
            DataItem = dataItem;
            Collection = collection;
        }
    }
}
