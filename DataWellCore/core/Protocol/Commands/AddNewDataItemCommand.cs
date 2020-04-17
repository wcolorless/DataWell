using System;
using System.Collections.Generic;
using System.Text;
using DataWellCore.core.Data.Collections;

namespace DataWellCore.core.Protocol
{
    public class AddNewDataItemCommand : BaseCommand
    {
        public string Collection { get; set; }
        public DataItem DataItem { get; set; }
        public AddNewDataItemCommand(DataItem dataItem, string collection)
        {
            CommandName = Commands.AddNewDataItem;
            DataItem = dataItem;
            Collection = collection;
        }
    }
}
