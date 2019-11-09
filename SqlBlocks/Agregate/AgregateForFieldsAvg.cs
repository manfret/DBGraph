using Util.Structs;

namespace MyGraph.SqlBlocks.Agregate
{
    public class AgregateForFieldsAvg : AgregateForFields
    {
        public AgregateForFieldsAvg()
        {
            this.AgregateType = AgregateType.AVG;
        }
    }
}