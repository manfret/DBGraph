using MyGraph.Field;
using Util.Structs;

namespace MyGraph.SqlBlocks.Order
{
    public interface IFieldOrder : ISql
    {
        IField Field { get; }
        SortType Sort  { get; }
    }
}