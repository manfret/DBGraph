using System.Collections.Generic;
using System;

namespace MyGraph.WaveAlgorithm
{
    public interface IWavePoint : IEquatable<IWavePoint>
    {
        //для разметки 
        int Flag { get; set; }
        List<IWaveConnection> Connections { get; }
        void AddConnection(IWaveConnection connection);
    }
}