using MyGraph.Field;

namespace MyGraph.SqlBlocks.Where
{
    public abstract class FieldWhere : IFieldWhere
    {
        protected bool Equals(FieldWhere other)
        {
            return this.Field.Equals(other.Field) && string.Equals(Operator, other.Operator) && Value.Equals(other.Value);
        }

        public bool Equals(IFieldWhere obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((FieldWhere)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = Field.GetHashCode();
                hashCode = (hashCode * 397) ^ Operator.GetHashCode();
                hashCode = (hashCode * 397) ^ Value.GetHashCode();
                return hashCode;
            }
        }

        public IField Field { get; protected set; }
        public string Operator { get; set; }
        public dynamic Value { get; set; }

        public abstract object Clone();
        public abstract string GetSql();
    }
}
