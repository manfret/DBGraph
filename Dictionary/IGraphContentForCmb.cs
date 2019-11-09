using System.Collections.Generic;
using MyGraph.Field;
using PFOClasses.Refs.Facades;

namespace MyGraph.Dictionary
{
    //IAll для конкретного combo-набора
    public interface IGraphContentForCmb
    {
        //кодовое имя
        string CodeName { get; }
        List<IRefFacade> RefFacades { get; }
    }
}