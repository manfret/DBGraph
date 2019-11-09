using System.Collections.Generic;
using MyGraph.Field;
using MyGraph.SqlBlocks.Sides;

namespace MyGraph.Graph
{
    public interface IGraphTable
    {
        IOneSide PrimaryKey { get; }
        List<IField> Fields { get; }
        void AddField(IField field);

        //для разметки 
        int Flag { get; set; }
        List<IGraphConnection> Connections { get; }
        void AddConnection(IGraphConnection connection);
    }
}