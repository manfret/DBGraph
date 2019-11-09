using System.Collections.Generic;
using MyGraph.Graph.GraphData;
using MyGraph.Graph.PathFinder;
using MyGraph.SqlBlocks;
using Util;
using Util.Ninject;
using Ninject;

namespace MyGraph.SqlManager
{
    //т.к. этот класс достаточно прост - в нем мало ветвлений
    //и содержит много статики, то не будем его тестировать
    //весь основной функционал тестируется в ParserSqlBlocks
    //здесь же идет в основном только сборка
    public class SqlManager : ISqlManager
    {
        private readonly GraphData _graphData;

        public SqlManager(GraphData graphData)
        {
            this._graphData = graphData;
        }

        //where_block - все IWhere со скобками и т.д.
        //fields_where - те которые выбраны пользователем в условиях для полей 
        public string CreateSql(ISqlBlocks sqlBlocks, out List<IAgregateSql> agregateGroup, out List<IAgregateSql> agregateAll)
        {
            agregateAll = new List<IAgregateSql>();
            agregateGroup = new List<IAgregateSql>();

            string sqlSelect = "SELECT DISTINCT ";
            string sqlFrom = "FROM ";
            string sqlWhere = "WHERE ";
            string sqlOrder = "";

            sqlSelect += ParserSqlBlocks.GetSelect(sqlBlocks) + " ";
            string sqlFromForOut;
            string sqlWhereForOut;
            IWavePathFinderPFO pathFinder = NinjectKernel.Kernel.Get<IWavePathFinderPFO>();
            ParserSqlBlocks.GetFromWhere(pathFinder, _graphData.Groups, sqlBlocks, out sqlFromForOut, out sqlWhereForOut);
            sqlFrom += sqlFromForOut + " ";
            sqlWhere += sqlWhereForOut + " ";
            string sql = sqlSelect + sqlFrom;

            if (sqlBlocks.Argerates.IsAny()) ParserSqlBlocks.ParseAgregates(sqlBlocks, sqlFrom + sqlWhere, ref agregateGroup, ref agregateAll);
            if (sqlWhere.Length > "WHERE ".Length) sql += sqlWhere;

            if (sqlBlocks.Order != null || sqlBlocks.GroupBy!= null) sqlOrder = ParserSqlBlocks.GetOrder(sqlBlocks);
            sql += " " + sqlOrder;

            sql = sql.Replace("  ", " ");
            sql = sql.Replace("  ", " ");

            return sql;
        }
    }
}
