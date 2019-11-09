namespace MyGraph.Graph
{
    public class GraphConnection : IGraphConnection
    {
        public string IdOwn { get; private set; } 
        public string IdForeign { get; private set; }
        public IGraphTable ForeignPoint { get; private set; }


        public GraphConnection(string idOwnField, string idForeignField, IGraphTable foreignTable)
        {
            this.IdOwn = idOwnField;
            this.ForeignPoint = foreignTable;
            this.IdForeign = idForeignField;
        }
    }
}