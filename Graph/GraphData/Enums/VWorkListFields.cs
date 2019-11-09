using Util.MyGeneral;

namespace MyGraph.Graph.GraphData.Enums
{
    public enum VWorkListFields
    {
        [StringValue("stavka")]
        STAVKA,
        [StringValue("id_fw")]
        FW_ID,
        [StringValue("fullwork_name")]
        FW_NAME,
        [StringValue("date_start")]
        DATE_START,
        [StringValue("date_finish")]
        DATE_FINISH,
        [StringValue("final_salary")]
        FINAL_SAL,
        [StringValue("final_salary_without_bonuses")]
        FINAL_SAL_NO_BONUS
    }
}