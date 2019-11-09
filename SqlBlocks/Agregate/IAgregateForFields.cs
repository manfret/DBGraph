using System.Collections.Generic;
using MyGraph.Field;
using Util.Structs;

namespace MyGraph.SqlBlocks.Agregate
{
    public interface IAgregateForFields : ISql
    {
        AgregateType AgregateType { get; }
        List<IField> Fields { get; }

        void AddField(IField field);
        void RemoveField(IField field);
    }
}
