using System.Collections.Generic;

namespace MyGraph.SqlBlocks.Sides.Comparers
{
    public class TwoSideComparer : IEqualityComparer<ITwoSides>
    {
        public bool Equals(ITwoSides w1, ITwoSides w2)
        {
            return (w1.Side1.Equals(w2.Side1) && w1.Side2.Equals(w2.Side2)) || (w1.Side1.Equals(w2.Side2) && w1.Side2.Equals(w2.Side1));
        }

        public int GetHashCode(ITwoSides w)
        {
            int hash = 1;
            hash *= w.Side1.Table.GetHashCode();
            hash *= w.Side1.Field.GetHashCode();
            hash *= w.Side2.Table.GetHashCode();
            hash *= w.Side2.Field.GetHashCode();

            return hash;
        }

    }
}