using System.Collections.Generic;

namespace MyGraph.Graph
{
    public interface IGraphTablesGroup
    {
        string ReadableName { get; }
        List<IGraphTable> GraphTables { get; }

        void AddTable(IGraphTable graphTable);
    }
}