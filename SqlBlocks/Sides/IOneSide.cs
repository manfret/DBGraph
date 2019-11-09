using System;

namespace MyGraph.SqlBlocks.Sides
{
    public interface IOneSide : ISql, IEquatable<IOneSide>
    {
        string Table { get; }
        string Field { get; }
    }
}