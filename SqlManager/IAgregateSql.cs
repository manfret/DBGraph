using System.Collections.Generic;
using Util.Structs;

namespace MyGraph.SqlManager
{
    public interface IAgregateSql
    {
        string Sql { get; set; }
        List<string> FieldsNamesAs { get; }
        AgregateType AgregateType { get; }

        IAgregateSql Clone();
    }
}