using System;
using Util.MyGeneral;

namespace MyGraph.Graph.GraphData.Enums
{
    public static class EnumsConcatToSql
    {
        public static string GetStr(Enum table, Enum field)
        {
            return StringEnum.GetStringValue(table) + "." + StringEnum.GetStringValue(field);
        }
    }
}