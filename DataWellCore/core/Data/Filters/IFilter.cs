using System;
using System.Collections.Generic;
using System.Text;

namespace DataWellCore.core.Data.Filters
{
    public interface IFilter
    {
        IFilter Equal(string property, object value);
        IFilter NotEqual(string property, object value);
        IFilter Greater(string property, object value);
        IFilter Less(string property, object value);
        IFilter GreaterOrEqual(string property, object value);
        IFilter LessOrEqual(string property, object value);
        List<T> Go<T>();
    }
}
