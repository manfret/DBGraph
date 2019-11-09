namespace MyGraph.Graph
{
    public interface IGraphConnection
    {
        string IdOwn { get; }
        string IdForeign { get; }
        IGraphTable ForeignPoint { get; }
    }
}