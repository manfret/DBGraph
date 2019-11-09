using System.Collections.Generic;
using MyGraph.Field;
using MyGraph.SqlBlocks.Agregate;
using MyGraph.SqlBlocks.Order;

namespace MyGraph.SqlBlocks
{
    public interface ISqlBlocks
    {
        List<IField> Selects { get; set; }
        List<ISql> Wheres { get; set; }
        IField GroupBy { get; set; }
        IFieldOrder Order { get; set; }
        List<IAgregateForFields> Argerates { get; set; }
        bool GroupCount { get; set; }
    }
}