using System.Collections.Generic;
using MyGraph.Field;
using MyGraph.SqlBlocks.Sides;

namespace MyGraph.Graph.PathFinder
{
    public interface IWavePathFinderPFO
    {
         IList<IGraphTable> GetPathTables(IGraphTable first, IGraphTable second);
         void GetWhereFromByPath(IField first, IField second, List<IGraphTablesGroup> groups, ref List<string> @from, ref List<ITwoSides> @where);
         void GetWhereFromByPath(IGraphTable first, IGraphTable second, ref List<string> @from, ref List<ITwoSides> @where);
    }
}