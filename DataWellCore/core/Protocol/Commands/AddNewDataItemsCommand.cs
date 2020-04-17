using System;
using System.Collections.Generic;
using System.Text;
using DataWellCore.core.Data.Collections;

namespace DataWellCore.core.Protocol
{
    public class AddNewDataItemsCommand : BaseCommand
    {
        public string Collection { get; set; }
        public List<DataItem> DataItems { get; set; }
        public AddNewDataItemsCommand(List<DataItem> dataItems, string collection)
        {
            CommandName = Commands.AddNewDataItems;
            DataItems = dataItems;
            Collection = collection;
        }
    }
}
