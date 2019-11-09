using Util.MyGeneral;

namespace MyGraph.Graph.GraphData.Enums
{
    public enum VBonusFields
    {
        [StringValue("id_b")]
        BON_ID,
        [StringValue("bonus_name")]
        BON_NAME,
        [StringValue("id_bonus")]
        BON_TYPE_ID,
        [StringValue("bonus_type_name")]
        BON_TYPE_NAME,
        [StringValue("id_am_type")]
        AM_TYPE_ID,
        [StringValue("amount_type_name")]
        AM_TYPE_NAME,
        [StringValue("b_percent")]
        PERCENT,
        [StringValue("amount")]
        AMOUNT,
        [StringValue("id_fund")]
        FUND_ID,
        [StringValue("funding_name")]
        FUND_NAME,
        [StringValue("date_start")]
        DATE_START,
        [StringValue("date_finish")]
        DATE_FINISH,
        [StringValue("final_bonus")]
        FINAL_BON
    }
}