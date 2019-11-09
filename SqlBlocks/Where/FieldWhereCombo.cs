using MyGraph.Field;

namespace MyGraph.SqlBlocks.Where
{
    public class FieldWhereCombo : FieldWhere
    {
        public FieldWhereCombo(IField field)
        {
            this.Field = field;
        }

        public override string GetSql()
        {
            string sql = this.Field.WhereKey.GetSql() + this.Operator + "'" + Value.ToString() + "'";
            return sql;
        }

        public override object Clone()
        {
            FieldWhereCombo newField = new FieldWhereCombo(this.Field)
            {
                Operator = this.Operator,
                Value = this.Value
            };
            return newField;
        }
    }
}