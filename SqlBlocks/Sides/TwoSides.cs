using System.Collections.Generic;

namespace MyGraph.SqlBlocks.Sides
{
    //для создания "Table1.Field1=Table2.Field2"
    public class TwoSides : ITwoSides
    {
        public IOneSide Side1 { get; private set; }
        public IOneSide Side2 { get; private set; }

        public TwoSides(IOneSide side1, IOneSide side2)
        {
            this.Side1 = side1;
            this.Side2 = side2;
        }

        public string GetSql()
        {
            return this.Side1.GetSql() + "=" + this.Side2.GetSql();
        }

        public List<string> GetFrom()
        {
            List<string> tables = new List<string> {this.Side1.Table, this.Side2.Table};
            return tables;
        }
    }
}