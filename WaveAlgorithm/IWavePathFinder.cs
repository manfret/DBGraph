using System.Collections.Generic;

namespace MyGraph.WaveAlgorithm
{
    public interface IWavePathFinder
    {
        void MarkPath(IWavePoint first, IWavePoint second);
        IEnumerable<IWavePoint> GetPath(IWavePoint first, IWavePoint second);
    }
}