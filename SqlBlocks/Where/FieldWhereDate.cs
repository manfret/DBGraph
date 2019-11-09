using MyGraph.Field;

namespace MyGraph.SqlBlocks.Where
{
    public class FieldWhereDate : FieldWhere
    {
        public FieldWhereDate(IField field)
        {
            this.Field = field;
        }

        public override object Clone()
        {
            FieldWhereDate newField = new FieldWhereDate(this.Field)
            {
                Operator = this.Operator,
                Value = this.Value
            };
            return newField;
        }

        public override string GetSql()
        {
            string sql = this.Field.WhereKey.GetSql() + this.Operator + "'" + Value.Ticks.ToString() + "'";
            return sql;
        }
    }
}