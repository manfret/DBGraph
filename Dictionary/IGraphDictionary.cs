namespace MyGraph.Dictionary
{
    public interface IGraphDictionary
    {
        IGraphContentForCmb GetContent(string codeName);
        System.Collections.Generic.List<PFOClasses.Refs.Facades.IRefFacade> GetContentForPos(int idDiv, int idType);
    }
}
