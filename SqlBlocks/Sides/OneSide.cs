namespace MyGraph.SqlBlocks.Sides
{
    //для создания "Table.Field"
    public class OneSide : IOneSide
    {
        public string Table { get; private set; }
        public string Field { get; private set; }

        public OneSide(string table, string field)
        {
            this.Table = table;
            this.Field = field;
        }

        public string GetSql()
        {
            return this.Table + "." + this.Field;
        }

        protected bool Equals(OneSide other)
        {
            return string.Equals(Table, other.Table) && string.Equals(Field, other.Field);
        }

        public bool Equals(IOneSide obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((OneSide) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Table.GetHashCode()*397) ^ Field.GetHashCode();
            }
        }
    }
}