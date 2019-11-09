using Util.Structs;

namespace MyGraph.SqlBlocks.Agregate
{
    public class AgregateForFieldsCount : AgregateForFields
    {
        public AgregateForFieldsCount()
        {
            AgregateType = AgregateType.COUNT;
        }
    }
}