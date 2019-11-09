using Util.Structs;

namespace MyGraph.SqlBlocks.Agregate
{
    public class AgregateForFieldsSum : AgregateForFields
    {
        public AgregateForFieldsSum()
        {
            AgregateType = AgregateType.SUM;
        }
    }
}