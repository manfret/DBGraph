using System.Collections.Generic;
using PFOClasses.Refs.Facades;

namespace MyGraph.Dictionary
{
    public class GraphContentForCombo : IGraphContentForCmb
    {
        public string CodeName { get; private set; }
        public List<IRefFacade> RefFacades { get; private set; }

        public GraphContentForCombo(string codeName, List<IRefFacade> content)
        {
            this.CodeName = codeName;
            this.RefFacades = content;
        }
    }
}