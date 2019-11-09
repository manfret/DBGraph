using Util.MyGeneral;

namespace MyGraph.Graph.GraphData.Enums
{
    public enum VStaffListFields
    {
        [StringValue("id_pos")]
        POS_ID,
        [StringValue("position_name")]
        POS_NAME,
        [StringValue("id_div")]
        DIV_ID,
        [StringValue("division_name")]
        DIV_NAME,
        [StringValue("id_fac")]
        FAC_ID,
        [StringValue("faculty_name")]
        FAC_NAME,
        [StringValue("id_type")]
        TYPE_ID,
        [StringValue("type_name")]
        TYPE_NAME,
        [StringValue("id_fund")]
        FUND_ID,
        [StringValue("funding_name")]
        FUND_NAME,
        [StringValue("capacity")]
        CAPACITY,
        [StringValue("id_cat")]
        CAT_ID,
        [StringValue("categories_name")]
        CAT_NAME,
        [StringValue("id_pkg")]
        PKG_ID,
        [StringValue("pkg_name")]
        PKG_NAME,
        [StringValue("id_lvl")]
        LVL_ID,
        [StringValue("lvl_name")]
        LVL_NAME,
        [StringValue("salary")]
        SALARY,
        [StringValue("id_pos_group")]
        POS_GROUP_ID,
        [StringValue("pos_group_name")]
        POS_GROUP_NAME
    }
}