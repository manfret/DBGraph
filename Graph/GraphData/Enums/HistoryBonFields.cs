using Util.MyGeneral;

namespace MyGraph.Graph.GraphData.Enums
{
    public enum HistoryBonFields
    {
        [StringValue("bonus_name")]
        BON_NAME,
        [StringValue("bonus_type")]
        TYPE,
        [StringValue("amount_type")]
        AM_TYPE,
        [StringValue("amount")]
        AMOUNT,
        [StringValue("bonus_fund")]
        FUND,
        [StringValue("date_start")]
        DATE_START,
        [StringValue("date_finish")]
        DATE_FINISH,
    }
}