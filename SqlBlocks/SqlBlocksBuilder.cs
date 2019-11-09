using System.Linq;
using MyGraph.Field;
using MyGraph.SqlBlocks.Agregate;
using MyGraph.SqlBlocks.Factory;
using Ninject;
using Util;
using Util.Ninject;
using Util.Structs;

namespace MyGraph.SqlBlocks
{
    public class SqlBlocksBuilder : ISqlBlocksBuilder
    {
        private readonly ISqlBlocks _sqlBlocks;
        private readonly ISqlBlocksFactory _fact;

        public SqlBlocksBuilder()
        {
            this._sqlBlocks = new SqlBlocks();
            this._fact = NinjectKernel.Kernel.Get<ISqlBlocksFactory>();
        }

        public void AddSelect(IField select)
        {
            this._sqlBlocks.Selects.Add(select);
        }

        public void RemoveSelect(IField select)
        {
            this._sqlBlocks.Selects.RemoveAll(a => a.Equals(select));
        }

        public void AddWhere(ISql where)
        {
            this._sqlBlocks.Wheres.Add(where);
        }

        public void SetOrder(IField field, SortType sort)
        {
            this._sqlBlocks.Order = this._fact.CreateOrder(field, sort);
        }

        public void SetGroupBy(IField groupBy)
        {
            this._sqlBlocks.GroupBy = groupBy;
        }

        public void AddAgregateField(IField field, AgregateType ident)
        {
            //если не находим нужного agregateForFields - создаем и в него записываем Field
            IAgregateForFields agregateForFields = this._sqlBlocks.Argerates.SingleOrDefault(a => a.AgregateType == ident);
            if (agregateForFields == null)
            {
                IAgregateForFields newAgregateForFields = this._fact.CreateAgregate(ident);
                newAgregateForFields.AddField(field);
                this._sqlBlocks.Argerates.Add(newAgregateForFields);
            }
            else
                agregateForFields.AddField(field);
        }

        public void RemoveAgregateField(IField field, AgregateType ident)
        {
            if (!this._sqlBlocks.Argerates.IsAny()) return;
            IAgregateForFields agregateForFields = this._sqlBlocks.Argerates.SingleOrDefault(a => a.AgregateType == ident);
            if (agregateForFields == null) return;
            agregateForFields.RemoveField(field);
            //если после удаления, остается 0 IFields в agregateForFields, то удаляем его
            if (agregateForFields.Fields.Count == 0) this._sqlBlocks.Argerates.Remove(agregateForFields);
        }

        public void SetGroupCount(bool makeGroupCount)
        {
            this._sqlBlocks.GroupCount = makeGroupCount;
        }

        public ISqlBlocks GetSqlBlocks()
        {
            return this._sqlBlocks;
        }
    }
}