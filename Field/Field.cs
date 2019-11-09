using MyGraph.SqlBlocks.Sides;
using Util.Structs;

namespace MyGraph.Field
{
    public class Field : IField
    {
        public string ReadableName { get; private set; }
        public IOneSide SelectKey { get; private set; }
        public IOneSide WhereKey { get; private set; }
        public FieldType FieldType { get; private set; }

        public string SelectAs
        {
            get { return this.SelectKey.Table + "_" + this.SelectKey.Field; }
        }

        public Field(string readName, FieldType fieldType, IOneSide selectKey, IOneSide whereKey)
        {
            this.ReadableName = readName;
            this.SelectKey = selectKey;
            this.WhereKey = whereKey;
            this.FieldType = fieldType;
        }

        protected bool Equals(Field other)
        {
            return SelectKey.Equals(other.SelectKey);
        }

        public bool Equals(IField obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Field) obj);
        }

        public override int GetHashCode()
        {
            return SelectKey.GetHashCode();
        }

        public object Clone()
        {
            return new Field(this.ReadableName, this.FieldType, this.SelectKey, this.WhereKey);
        }
    }
}
