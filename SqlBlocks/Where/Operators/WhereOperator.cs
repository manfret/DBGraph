namespace MyGraph.SqlBlocks.Where.Operators
{
    public abstract class WhereOperator : ISql
    {
        protected string Operator;

        public string GetSql()
        {
            return " " + this.Operator + " ";
        }
    }
}