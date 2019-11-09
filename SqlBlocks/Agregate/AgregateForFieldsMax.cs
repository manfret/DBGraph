using Util.Structs;

namespace MyGraph.SqlBlocks.Agregate
{
    public class AgregateForFieldsMax : AgregateForFields
    {
        public AgregateForFieldsMax()
        {
            this.AgregateType = AgregateType.MAX;
        }
    }
}