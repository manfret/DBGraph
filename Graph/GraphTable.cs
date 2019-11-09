using System.Collections.Generic;
using MyGraph.Field;
using MyGraph.SqlBlocks.Factory;
using MyGraph.SqlBlocks.Sides;
using Ninject;
using Util.Ninject;

namespace MyGraph.Graph
{
    public class GraphTable : IGraphTable
    {
        //employee + id_e
        public IOneSide PrimaryKey { get; private set; }
        public List<IField> Fields { get; private set; }
        public List<IGraphConnection> Connections { get; private set; }

        //флаг для помечания при поиске пути
        public int Flag { get; set; }

        public GraphTable(string tableName, string id)
        {
            ISqlBlocksFactory fact = NinjectKernel.Kernel.Get<ISqlBlocksFactory>();
            this.Flag = 0;
            this.PrimaryKey = fact.CreateOneSide(tableName, id);
            this.Fields = new List<IField>();
            this.Connections = new List<IGraphConnection>();
        }

        public void AddField(IField field)
        {
            this.Fields.Add(field);
        }

        public void AddConnection(IGraphConnection connection)
        {
            this.Connections.Add(connection);
        }

        protected bool Equals(GraphTable other)
        {
            return Flag == other.Flag && PrimaryKey.Equals(other.PrimaryKey);
        }

        public bool Equals(IGraphTable obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((GraphTable) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Flag*397) ^ PrimaryKey.GetHashCode();
            }
        }
    }
}