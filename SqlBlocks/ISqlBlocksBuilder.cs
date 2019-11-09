using MyGraph.Field;
using Util.Structs;

namespace MyGraph.SqlBlocks
{
    //строитель для ISqlBlocks
    public interface ISqlBlocksBuilder
    {
        void AddSelect(IField select);
        void RemoveSelect(IField select);
        void AddWhere(ISql where);
        void SetOrder(IField field, SortType sort);
        void SetGroupBy(IField groupBy);
        void AddAgregateField(IField field, AgregateType ident);
        void RemoveAgregateField(IField field, AgregateType ident);
        void SetGroupCount(bool makeGroupCount);

        ISqlBlocks GetSqlBlocks();
    }
}