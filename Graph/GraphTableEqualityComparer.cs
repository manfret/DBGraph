using System.Collections.Generic;

namespace MyGraph.Graph
{
    public class GraphTableEqualityComparer:IEqualityComparer<IGraphTable>
    {
        public bool Equals(IGraphTable x, IGraphTable y)
        {
            return x.PrimaryKey.Equals(y.PrimaryKey);
        }

        public int GetHashCode(IGraphTable obj)
        {
            unchecked
            {
                return obj.PrimaryKey.GetHashCode();
            }
        }
    }
}
