namespace MyGraph.WaveAlgorithm
{
    //граф - однонаправленный
    public interface IWaveConnection
    {
        string IdOwn { get; }
        string IdForeign { get; }
        IWavePoint ForeignPoint { get; }
    }
}