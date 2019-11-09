using System.Collections.Generic;

namespace MyGraph.SqlBlocks.Sides.Comparers
{
    class OneSideComparer : IEqualityComparer<IOneSide>
    {
        public bool Equals(IOneSide w1, IOneSide w2)
        {
            //проверяем по GetSQl т.к. это результирующая характеристика для полей
            return w1.Field == w2.Field && w1.Table == w2.Table;
        }

        public int GetHashCode(IOneSide w)
        {
            int hash = 1;
            hash *= w.Table.GetHashCode();
            hash *= w.Field.GetHashCode();

            return hash;
        }

    }
}