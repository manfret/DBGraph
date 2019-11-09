using MyGraph.Dictionary;
using MyGraph.Graph.GraphData;
using MyGraph.Graph.PathFinder;
using MyGraph.SqlBlocks.Factory;
using MyGraph.WaveAlgorithm;
using Ninject.Modules;

namespace MyGraph
{
    public class GraphModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ISqlBlocksFactory>().To<SqlBlocksFactory>().InSingletonScope();
            Bind<GraphData>().To<GraphDataReal>().InSingletonScope();
            Bind<IWavePathFinder>().To<WavePathFinder>().InSingletonScope();
            Bind<IWavePathFinderPFO>().To<WavePathFinderPFO>().InSingletonScope();
            Bind<IGraphDictionary>().To<GraphDictionary>().InSingletonScope();
        }
    }
}
