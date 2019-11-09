using System.Collections.Generic;

namespace MyGraph.Graph
{
    public class GraphTablesGroup : IGraphTablesGroup
    {
        public string ReadableName { get; private set; }
        public List<IGraphTable> GraphTables { get; private set; }

        public GraphTablesGroup(string readableName)
        {
            this.GraphTables = new List<IGraphTable>();
            this.ReadableName = readableName;
        }

        public void AddTable(IGraphTable graphTable)
        {
            this.GraphTables.Add(graphTable);
        }
    }
}
