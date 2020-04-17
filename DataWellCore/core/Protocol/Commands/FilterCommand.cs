using System;
using System.Collections.Generic;
using System.Text;
using DataWellCore.core.Data.Filters;

namespace DataWellCore.core.Protocol
{
    public class FilterCommand : BaseCommand
    {
        public string Collection { get; set; }
        public List<FilterParameter> FilterParameters { get; set; }
        public FilterCommand(string collection, List<FilterParameter> filterParameters)
        {
            FilterParameters = filterParameters;
            Collection = collection;
            CommandName = Commands.Filter;
        }
    }
}
