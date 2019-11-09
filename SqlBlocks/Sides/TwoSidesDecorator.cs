using System.Collections.Generic;
using System.Linq;

namespace MyGraph.SqlBlocks.Sides
{
    //в данный момент не используется в программе
    //декорирует IWhere дополняя AND-ами для создания sql-запроса
    public class TwoSidesDecorator : ITwoSides
    {
        private readonly ITwoSides _wrappedTwoSides;
        public IOneSide Side1 { get; private set; }
        public IOneSide Side2 { get; private set; }

        public TwoSidesDecorator(ITwoSides wrappedTwoSides, IOneSide side1, IOneSide side2)
        {
            this._wrappedTwoSides = wrappedTwoSides;
            this.Side1 = side1;
            this.Side2 = side2;
        }

        public string GetSql()
        {
            return _wrappedTwoSides.GetSql() + " AND " + this.Side1.GetSql() + "=" + this.Side2.GetSql();
        }

        public List<string> GetFrom()
        {
            List<string> tables = _wrappedTwoSides.GetFrom();
            tables.Add(this.Side1.Table);
            tables.Add(this.Side2.Table);
            tables = tables.Distinct().ToList();
            return tables;
        }
    }
}
