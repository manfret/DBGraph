using System.Collections.Generic;
using MyGraph.SqlBlocks;

namespace MyGraph.SqlManager
{
    public interface ISqlManager
    {
        string CreateSql(ISqlBlocks sqlBlocks, out List<IAgregateSql> agregateGroup, out List<IAgregateSql> agregateAll);
    }
}