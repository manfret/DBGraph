using Util.Structs;

namespace MyGraph.SqlBlocks.Agregate
{
    public class AgregateForFieldsMin : AgregateForFields
    {
        public AgregateForFieldsMin()
        {
            this.AgregateType = AgregateType.MIN;
        }
    }
}