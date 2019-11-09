using System.Collections.Generic;
using Util.Structs;

namespace MyGraph.SqlManager
{
    public class AgregateSql : IAgregateSql
    {
        public string Sql { get; set; }
        //"employee_name" - для чтения ридерами
        public List<string> FieldsNamesAs { get; private set; }
        public AgregateType AgregateType { get; private set; }

        public AgregateSql(string sql, List<string> fieldsNameAs, AgregateType agregateType)
        {
            Sql = sql;
            FieldsNamesAs = fieldsNameAs;
            AgregateType = agregateType;
        }

        public IAgregateSql Clone()
        {
            return new AgregateSql(this.Sql, this.FieldsNamesAs, this.AgregateType);        
        }
    }
}