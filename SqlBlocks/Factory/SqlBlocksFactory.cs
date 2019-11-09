using System;
using MyGraph.Field;
using MyGraph.SqlBlocks.Agregate;
using MyGraph.SqlBlocks.Order;
using MyGraph.SqlBlocks.Sides;
using MyGraph.SqlBlocks.Where;
using Util.MyGeneral;
using Util.Structs;

namespace MyGraph.SqlBlocks.Factory
{
    public class SqlBlocksFactory : ISqlBlocksFactory
    {
        public IFieldWhere CreateFieldWhere(IField field, FieldType type)
        {
            switch (type)
            {
                case FieldType.TEXT:
                    return new FieldWhereText(field);
                case FieldType.COMBO:
                    return new FieldWhereCombo(field);
                case FieldType.DATE:
                    return new FieldWhereDate(field);
            }

            return null;
        }

        public IOneSide CreateOneSide(string table, string field)
        {
            return new OneSide(table, field);
        }

        public IOneSide CreateOneSide(Enum table, Enum field)
        {
            return new OneSide(StringEnum.GetStringValue(table), StringEnum.GetStringValue(field));
        }

        public ITwoSides CreateTwoSide(string table1, string field1, string table2, string field2)
        {
            IOneSide s1 = CreateOneSide(table1, field1);
            IOneSide s2 = CreateOneSide(table2, field2);
            return new TwoSides(s1, s2);
        }

        public ITwoSides CreateTwoSide(IOneSide firstSide, IOneSide secondSide)
        {
            return new TwoSides(firstSide, secondSide);
        }

        public ITwoSides CreateTwoSideDecorator(ITwoSides wrappedTwoSides, IOneSide side1, IOneSide side2)
        {
            return new TwoSidesDecorator(wrappedTwoSides, side1, side2);
        }

        public ITwoSides CreateTwoSideDecorator(ITwoSides wrappedTwoSides, string table1, string field1, string table2, string field2)
        {
            return new TwoSidesDecorator(wrappedTwoSides, new OneSide(table1, field1), new OneSide(table2, field2));
        }

        public IFieldOrder CreateOrder(IField field, SortType sort)
        {
            return new FieldOrder(field, sort);
        }

        public IAgregateForFields CreateAgregate(AgregateType ident)
        {
            switch (ident)
            {
                case (AgregateType.COUNT):
                    return new AgregateForFieldsCount();
                case (AgregateType.SUM):
                    return new AgregateForFieldsSum();
                case (AgregateType.MAX):
                    return new AgregateForFieldsMax();
                case (AgregateType.MIN):
                    return new AgregateForFieldsMin();
                case (AgregateType.AVG):
                    return new AgregateForFieldsAvg();
            }
            return null;
        }

        public IField CreateField(string readName, FieldType fieldType, IOneSide primaryKey, IOneSide whereKey)
        {
            return new Field.Field(readName, fieldType, primaryKey, whereKey);
        }
    }
}
