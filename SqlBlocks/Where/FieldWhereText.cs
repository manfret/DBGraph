using MyGraph.Field;

namespace MyGraph.SqlBlocks.Where
{
    public class FieldWhereText : FieldWhere
    {
        public FieldWhereText(IField field)
        {
            this.Field = field;
        }

        public override string GetSql()
        {
            string sql = this.Field.WhereKey.GetSql() + this.Operator + "'" + Value + "'";
            return sql;
        }

        public override object Clone()
        {
            FieldWhereText newField = new FieldWhereText(this.Field)
            {
                Operator = this.Operator,
                Value = this.Value
            };
            return newField;
        }
    }
}