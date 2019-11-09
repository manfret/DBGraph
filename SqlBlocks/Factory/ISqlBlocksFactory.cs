using System;
using MyGraph.Field;
using MyGraph.SqlBlocks.Agregate;
using MyGraph.SqlBlocks.Order;
using MyGraph.SqlBlocks.Sides;
using MyGraph.SqlBlocks.Where;
using Util.Structs;

namespace MyGraph.SqlBlocks.Factory
{
    public interface ISqlBlocksFactory
    {
        IOneSide CreateOneSide(string table, string field);
        IOneSide CreateOneSide(Enum table, Enum field);
        ITwoSides CreateTwoSide(string table1, string field1, string table2, string field2);
        ITwoSides CreateTwoSide(IOneSide firstSide, IOneSide secondSide);
        ITwoSides CreateTwoSideDecorator(ITwoSides wrappedTwoSides, IOneSide side1, IOneSide side2);
        ITwoSides CreateTwoSideDecorator(ITwoSides wrappedTwoSides, string table1, string field1, string table2, string field2);
        IField CreateField(string readName, FieldType fieldType, IOneSide selectKey, IOneSide whereKey);
        IFieldWhere CreateFieldWhere(IField field, FieldType type);
        IFieldOrder CreateOrder(IField field, SortType sort);
        IAgregateForFields CreateAgregate(AgregateType ident);
    }
}