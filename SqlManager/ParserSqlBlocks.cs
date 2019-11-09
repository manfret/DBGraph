using System;
using System.Collections.Generic;
using System.Linq;
using MyGraph.Field;
using MyGraph.Graph;
using MyGraph.Graph.PathFinder;
using MyGraph.SqlBlocks;
using MyGraph.SqlBlocks.Agregate;
using MyGraph.SqlBlocks.Sides;
using MyGraph.SqlBlocks.Sides.Comparers;
using MyGraph.SqlBlocks.Where;

namespace MyGraph.SqlManager
{
    public static class ParserSqlBlocks
    {
        public static string GetSelect(ISqlBlocks sqlBlocks)
        {
            string select = "";
            //собираем select
            foreach (IField fieldSelect in sqlBlocks.Selects)
            {
                select += fieldSelect.SelectKey.GetSql() + " as " + fieldSelect.SelectAs + ", ";
            }
            select = select.Substring(0, select.Length - 2);
            return select;
        }

        public static void GetFromWhere(IWavePathFinderPFO pathFinder, List<IGraphTablesGroup> groups, ISqlBlocks sqlBlocks, out string @from, out string @where)
        {
            from = "";
            where = "";

            List<string> lstFrom = new List<string>();
            //для приравнивания таблиц work_list.id_e = employee.id_e
            List<ITwoSides> lstWhereEquation = new List<ITwoSides>();

            //в sqlBlocks.Selects содержатся данные и для from и для where
            for (int i = 0; i < sqlBlocks.Selects.Count; i++)
            {
                IField fieldSelect = sqlBlocks.Selects[i];
                lstFrom.Add(fieldSelect.SelectKey.Table);

                if (sqlBlocks.Selects.Count >= 2 && i <= sqlBlocks.Selects.Count - 2)
                {
                    //по путям между таблицами дополняем from и lstWhereEquation
                    pathFinder.GetWhereFromByPath(sqlBlocks.Selects[i], sqlBlocks.Selects[i + 1], groups, ref lstFrom, ref lstWhereEquation);
                }
            }
            //избавляемся от дубликатов
            if (lstWhereEquation.Count>1) lstWhereEquation = lstWhereEquation.Distinct(new TwoSideComparer()).ToList();

            string sqlWhereValues = "";
            IFieldWhere previous = null;
            foreach (ISql oneSql in sqlBlocks.Wheres)
            {
                sqlWhereValues += oneSql.GetSql();

                if (oneSql.GetType().IsSubclassOf(typeof(FieldWhere)))
                {
                    if (previous == null) previous = oneSql as IFieldWhere;
                    else pathFinder.GetWhereFromByPath((oneSql as IFieldWhere).Field, previous.Field, groups, ref lstFrom, ref lstWhereEquation);
                }
            }

            string sqlWhereEquation = "";
            foreach (ITwoSides itemWhere in lstWhereEquation)
            {
                sqlWhereEquation += itemWhere.GetSql() + " AND ";
            }

            if (!String.IsNullOrEmpty(sqlWhereValues))
            {
                if (!String.IsNullOrEmpty(where)) where += " AND ";
                where += " ( " + sqlWhereValues + " ) ";
            }
            if (!String.IsNullOrEmpty(sqlWhereEquation))
            {
                sqlWhereEquation = sqlWhereEquation.Substring(0, sqlWhereEquation.Length - " AND ".Length);
                if (!String.IsNullOrEmpty(where)) where += " AND ";
                where += " ( " + sqlWhereEquation + " ) ";
            }
            
            //избавляемся от дубликатов
            if (lstFrom.Count>1) lstFrom = lstFrom.Distinct().ToList();
            foreach (string itemFrom in lstFrom)
            {
                from += itemFrom + ", ";
            }
            if (!String.IsNullOrEmpty(from)) from = from.Substring(0, from.Length - ", ".Length);
        }

        public static string GetOrder(ISqlBlocks sqlBlocks)
        {
            string sqlOrder = "";

            if (sqlBlocks.GroupBy != null) sqlOrder += sqlBlocks.GroupBy.SelectKey.GetSql() + ", ";
            if (sqlBlocks.Order != null) sqlOrder += sqlBlocks.Order.Field.SelectKey.GetSql() + " " + sqlBlocks.Order.Sort + ", ";

            if (!String.IsNullOrEmpty(sqlOrder)) sqlOrder = sqlOrder.Substring(0, sqlOrder.Length - ", ".Length);

            return " ORDER BY " + sqlOrder;
        }

        public static void ParseAgregates(ISqlBlocks sqlBlocks, string sqlFromWhere, ref List<IAgregateSql> agregateGroup, ref List<IAgregateSql> agregateAll)
        {
            foreach (IAgregateForFields func in sqlBlocks.Argerates)
            {
                string oneSql = "SELECT " + func.GetSql() + " " + sqlFromWhere;

//                IAgregateSql one = new AgregateSql(oneSql, func.GetFieldsNames(), func.AgregateType);
                IAgregateSql one = new AgregateSql(oneSql, func.Fields.Select(a => a.SelectAs).ToList(), func.AgregateType);
                agregateAll.Add(one);
                if (sqlBlocks.GroupCount)
                {
                    string oneSqlForGroup = oneSql + " GROUP BY " + sqlBlocks.GroupBy.SelectKey.GetSql();
                    IAgregateSql oneForGroup = one.Clone() as IAgregateSql;
                    oneForGroup.Sql = oneSqlForGroup;
                    agregateGroup.Add(oneForGroup);
                }
            }
        }
    }
}
