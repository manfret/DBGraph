using Util.MyGeneral;

namespace MyGraph.Graph.GraphData.Enums
{
    public enum SqlTableNames
    {
        [StringValue("vEmployee")]
        EMP,
        [StringValue("vWorkList")]
        WORK_LIST,
        [StringValue("vStaffList")]
        STAFF_LIST,
        [StringValue("vBonus")]
        BONUS,
        [StringValue("history")]
        HISTORY,
        [StringValue("bonus_history_in_his")]
        HISTORY_BONUS_IN_HIST,
        [StringValue("bonus_history_in_work")]
        HISTORY_BONUS_IN_WORK
    }
}