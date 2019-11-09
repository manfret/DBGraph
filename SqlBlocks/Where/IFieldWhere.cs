using System;
using MyGraph.Field;

namespace MyGraph.SqlBlocks.Where
{
    public interface IFieldWhere : ISql, ICloneable, IEquatable<IFieldWhere>
    {
        IField Field { get; }
        string Operator { get; set; }
        dynamic Value { get; set; }
    }
}