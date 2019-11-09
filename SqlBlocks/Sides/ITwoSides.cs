using System.Collections.Generic;

namespace MyGraph.SqlBlocks.Sides
{
    public interface ITwoSides : ISql
    {
        IOneSide Side1 { get; }
        IOneSide Side2 { get; }

        List<string> GetFrom();
    }
}