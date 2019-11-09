using System.Collections.Generic;
using MyGraph.Field;
using Util;
using Util.Structs;

namespace MyGraph.SqlBlocks.Agregate
{
    public abstract class AgregateForFields : IAgregateForFields
    {
        public AgregateType AgregateType { get; protected set; }
        public List<IField> Fields { get; protected set; }

        protected AgregateForFields()
        {
            this.Fields = new List<IField>();
        }

        public string GetSql()
        {
            string sql = "";
            foreach (IField field in this.Fields)
            {
                sql += AgregateType + " ( DISTINCT " + field.SelectKey.GetSql() + " ) as " +field.SelectAs + ", ";        
            }
            sql = sql.Substring(0, sql.Length - 2);
            sql += " ";
            return sql;
        }

//        public List<string> GetFieldsNames()
//        {
//            List<string> selectAs = new List<string>();
//            foreach (IField field in this.Fields)
//            {
//                selectAs.Add(AgregateType + "_" + field.SelectAs);
//            }
//            return selectAs;
//        }


        public void AddField(IField field)
        {
           if (field!=null) this.Fields.Add(field);
        }

        public void RemoveField(IField field)
        {
            if (field == null || !this.Fields.IsAny()) return;
            this.Fields.RemoveAll(a => a.Equals(field));
        }
    }
}