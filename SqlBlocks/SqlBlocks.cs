using System.Collections.Generic;
using MyGraph.Field;
using MyGraph.SqlBlocks.Agregate;
using MyGraph.SqlBlocks.Order;

namespace MyGraph.SqlBlocks
{
    public class SqlBlocks : ISqlBlocks
    {
        public List<IField> Selects { get; set; }
        public List<ISql> Wheres { get; set; }
        public IFieldOrder Order { get; set; }
        public IField GroupBy { get; set; }
        public List<IAgregateForFields> Argerates { get; set; }
        public bool GroupCount { get; set; }

        public SqlBlocks()
        {
            this.Selects = new List<IField>();
            this.Wheres = new List<ISql>();
            this.Argerates = new List<IAgregateForFields>();
            this.GroupCount = false;
        }

        public SqlBlocks(List<IField> selects, List<ISql> wheres = null, IFieldOrder order = null, IField groupBy = null, List<IAgregateForFields> agregates = null, bool groupCount = false)
        {
            Selects = selects;
            Wheres = wheres ?? new List<ISql>();
            Order = order;
            GroupBy = groupBy;
            Argerates = agregates ?? new List<IAgregateForFields>();
            GroupCount = groupCount;
        }
    }
}