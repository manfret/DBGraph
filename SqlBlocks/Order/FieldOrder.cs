using MyGraph.Field;
using Util.Structs;

namespace MyGraph.SqlBlocks.Order
{
    public class FieldOrder : IFieldOrder
    {
        public IField Field { get; private set; }
        public SortType Sort { get; private set; }

        public FieldOrder(IField field, SortType sort)
        {
            this.Field = field;
            this.Sort = sort;
        }

        public string GetSql()
        {
            if (Sort == SortType.NONE) return "";
            return this.Field.SelectKey.GetSql() + " " + Sort + " ";
        }
    }
}