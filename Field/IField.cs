using System;
using MyGraph.SqlBlocks.Sides;
using Util.Structs;

namespace MyGraph.Field
{
    public interface IField : IEquatable<IField>, ICloneable
    {
        string ReadableName { get; }
        string SelectAs { get; }//вычисляемое //имя по которому обращаются reader-ы
        IOneSide SelectKey { get; }//vStaffList.div_name
        IOneSide WhereKey { get; }//vStaffList.id_div
        FieldType FieldType { get; }
    }
}