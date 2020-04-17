using System;
using System.Collections.Generic;
using System.Text;
using DataWellCore.core.Data.Collections;

namespace DataWellCore.core.Protocol
{
    public class AddNewCollectionCommand : BaseCommand
    {
        public CollectionInfo CollectionInfo { get; set; }
        public AddNewCollectionCommand(CollectionInfo collectionInfo)
        {
            CommandName = Commands.AddNewCollection;
            CollectionInfo = collectionInfo;
        }
    }
}
