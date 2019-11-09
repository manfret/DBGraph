using System.Collections.Generic;
using System.Linq;
using MyGraph.Field;
using MyGraph.SqlBlocks.Factory;

namespace MyGraph.Graph.GraphData
{
    public abstract class GraphData
    {
        public List<IGraphTablesGroup> Groups { get; protected set; }

        protected ISqlBlocksFactory Fact; 

        //после создания вершин и связей можно связать граф
        //для этого вызываем метод CreateOneConnection передавая в качестве параметра начальную и конечную таблицу для связей
        //idConnectForTable - имя того id по которому производится приравненивание таблиц. Это не ключ44
        protected void CreateConnection(IGraphTable table1, string idConnectForTable1, IGraphTable table2, string idConnectForTable2)
        {
            //создаем двунаправленную связь
            IGraphConnection connection = new GraphConnection(idConnectForTable1, idConnectForTable2, table2);
            table1.AddConnection(connection);
            IGraphConnection connectionBack = new GraphConnection(idConnectForTable2, idConnectForTable1, table1);
            table2.AddConnection(connectionBack);
        }

        public IField FindField(string fieldTable)
        {
            return (from treeGroup in this.Groups
                    from table in treeGroup.GraphTables
                    from field in table.Fields
                    select field)
                    .SingleOrDefault(a => a.WhereKey.GetSql() == fieldTable);
        }

        public IGraphTable FindTable(string tableIdName)
        {
            return (from treeGroup in this.Groups
                    from table in treeGroup.GraphTables
                    select table)
                    .SingleOrDefault(a => a.PrimaryKey.GetSql() == tableIdName);
        }
    }
}
