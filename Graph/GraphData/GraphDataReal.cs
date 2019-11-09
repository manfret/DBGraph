using System.Collections.Generic;
using MyGraph.Field;
using MyGraph.Graph.GraphData.Enums;
using MyGraph.SqlBlocks.Factory;
using MyGraph.SqlBlocks.Sides;
using Ninject;
using Util.MyGeneral;
using Util.Ninject;
using Util.Structs;

namespace MyGraph.Graph.GraphData
{
    public class GraphDataReal : GraphData
    {
        public GraphDataReal()
        {
            this.Groups = new List<IGraphTablesGroup>();
            this.Fact = NinjectKernel.Kernel.Get<ISqlBlocksFactory>();

            #region Employee

            IOneSide osEId = Fact.CreateOneSide(SqlTableNames.EMP, VEmpFields.ID_E);
            IField fEID = Fact.CreateField("ID", FieldType.TEXT, osEId, osEId);

            IOneSide osEName = Fact.CreateOneSide(SqlTableNames.EMP, VEmpFields.NAME);
            IField fEName = Fact.CreateField("���", FieldType.TEXT, osEName, osEName);

            IOneSide osEFam = Fact.CreateOneSide(SqlTableNames.EMP, VEmpFields.FAM);
            IField fEFam = Fact.CreateField("�������", FieldType.TEXT, osEFam, osEFam);

            IOneSide osESecondName = Fact.CreateOneSide(SqlTableNames.EMP, VEmpFields.SEC_NAME);
            IField fESecondName = Fact.CreateField("��������", FieldType.TEXT, osESecondName, osESecondName);

            IOneSide osEGender = Fact.CreateOneSide(SqlTableNames.EMP, VEmpFields.GENDER);
            IField fEGender = Fact.CreateField("���", FieldType.TEXT, osEGender, osEGender);

            IOneSide osEDegreeId = Fact.CreateOneSide(SqlTableNames.EMP, VEmpFields.DEG_ID);
            IOneSide osEDegreeName = Fact.CreateOneSide(SqlTableNames.EMP, VEmpFields.DEG_NAME);
            IField fEDegre = Fact.CreateField("������ �������", FieldType.COMBO, osEDegreeName, osEDegreeId);

            IOneSide osERankId = Fact.CreateOneSide(SqlTableNames.EMP, VEmpFields.RANK_ID);
            IOneSide osERankName = Fact.CreateOneSide(SqlTableNames.EMP, VEmpFields.NAME);
            IField fERank = Fact.CreateField("������ ������", FieldType.COMBO, osERankName, osERankId);

            IOneSide osEExceptId = Fact.CreateOneSide(SqlTableNames.EMP, VEmpFields.REASON_ID);
            IOneSide osEExceptName = Fact.CreateOneSide(SqlTableNames.EMP, VEmpFields.REASON_NAME);
            IField fEExcept = Fact.CreateField("������� ���������� �� �������", FieldType.COMBO, osEExceptName, osEExceptId);

            IOneSide osEExceptDateStart = Fact.CreateOneSide(SqlTableNames.EMP, VEmpFields.EX_START);
            IField fEExceptDateStart = Fact.CreateField("���� ������ ���������� �� �������", FieldType.DATE, osEExceptDateStart, osEExceptDateStart);

            IOneSide osEExceptDateFinish = Fact.CreateOneSide(SqlTableNames.EMP, VEmpFields.EX_FINISH);
            IField fEExceptDateFinish = Fact.CreateField("���� ��������� ���������� �� �������", FieldType.DATE, osEExceptDateFinish, osEExceptDateFinish);

            IOneSide osEFullSalary = Fact.CreateOneSide(SqlTableNames.EMP, VEmpFields.FULL_SAL);
            IField fEFullSalary = Fact.CreateField("����������� ����� (� ����������)", FieldType.TEXT, osEFullSalary, osEFullSalary);

            IOneSide osEFullSalaryNoBonuses = Fact.CreateOneSide(SqlTableNames.EMP, VEmpFields.FULL_SAL_NO_BON);
            IField fEFullSalaryNoBonuses = Fact.CreateField("����������� ����� (��� ��������)", FieldType.TEXT, osEFullSalaryNoBonuses, osEFullSalaryNoBonuses);

            IGraphTable graphTableEmployee = new GraphTable(StringEnum.GetStringValue(SqlTableNames.EMP), "id_e");
            graphTableEmployee.AddField(fEID);
            graphTableEmployee.AddField(fEName);
            graphTableEmployee.AddField(fEFam);
            graphTableEmployee.AddField(fESecondName);
            graphTableEmployee.AddField(fEGender);
            graphTableEmployee.AddField(fEDegre);
            graphTableEmployee.AddField(fERank);
            graphTableEmployee.AddField(fEExcept);
            graphTableEmployee.AddField(fEExceptDateStart);
            graphTableEmployee.AddField(fEExceptDateFinish);
            graphTableEmployee.AddField(fEFullSalary);
            graphTableEmployee.AddField(fEFullSalaryNoBonuses);

            #endregion

            #region WorkList

            IOneSide osWLStavka = Fact.CreateOneSide(SqlTableNames.WORK_LIST, VWorkListFields.STAVKA);
            IField fieldWorkListStavka = Fact.CreateField("������", FieldType.TEXT, osWLStavka, osWLStavka);

            IOneSide osWLFullworkId = Fact.CreateOneSide(SqlTableNames.WORK_LIST, VWorkListFields.FW_ID);
            IOneSide osWLFullworkName = Fact.CreateOneSide(SqlTableNames.WORK_LIST, VWorkListFields.FW_NAME);
            IField fWLFullwork = Fact.CreateField("����������", FieldType.COMBO, osWLFullworkName, osWLFullworkId);

            IOneSide osWLDateStart = Fact.CreateOneSide(SqlTableNames.WORK_LIST, VWorkListFields.DATE_START);
            IField fWLDateStart = Fact.CreateField("���� ������", FieldType.DATE, osWLDateStart, osWLDateStart);

            IOneSide osWLDateFinish = Fact.CreateOneSide(SqlTableNames.WORK_LIST, VWorkListFields.DATE_FINISH);
            IField fWLDateFinish = Fact.CreateField("���� ����������", FieldType.DATE, osWLDateFinish, osWLDateFinish);

            IOneSide osWLFinalSalary = Fact.CreateOneSide(SqlTableNames.WORK_LIST, VWorkListFields.FINAL_SAL);
            IField fWLFinalSalary = Fact.CreateField("��������� �����", FieldType.TEXT, osWLFinalSalary, osWLFinalSalary);

            IOneSide osWLFinalSalaryNoBonuses = Fact.CreateOneSide(SqlTableNames.WORK_LIST, VWorkListFields.FINAL_SAL_NO_BONUS);
            IField fWLFinalSalaryNoBonuses = Fact.CreateField("��������� ����� (��� ��������)", FieldType.TEXT, osWLFinalSalaryNoBonuses, osWLFinalSalaryNoBonuses);

            IGraphTable graphTableWorkList = new GraphTable(StringEnum.GetStringValue(SqlTableNames.WORK_LIST), "id_work");
            graphTableWorkList.AddField(fieldWorkListStavka);
            graphTableWorkList.AddField(fWLFullwork);
            graphTableWorkList.AddField(fWLDateStart);
            graphTableWorkList.AddField(fWLDateFinish);
            graphTableWorkList.AddField(fWLFinalSalary);
            graphTableWorkList.AddField(fWLFinalSalaryNoBonuses);

            #endregion

            #region StaffList

            IOneSide osSLPositionId = Fact.CreateOneSide(SqlTableNames.STAFF_LIST, VStaffListFields.POS_ID);
            IOneSide osSLPositionName = Fact.CreateOneSide(SqlTableNames.STAFF_LIST, VStaffListFields.POS_NAME);
            IField fSLPositionName = Fact.CreateField("�������� ���������", FieldType.COMBO, osSLPositionName, osSLPositionId);

            IOneSide osSlDivisionId = Fact.CreateOneSide(SqlTableNames.STAFF_LIST, VStaffListFields.DIV_ID);
            IOneSide osSlDivisionName = Fact.CreateOneSide(SqlTableNames.STAFF_LIST, VStaffListFields.DIV_NAME);
            IField fieldStaffListDivision = Fact.CreateField("�������������", FieldType.COMBO, osSlDivisionName, osSlDivisionId);

            IOneSide osSLFacultyId = Fact.CreateOneSide(SqlTableNames.STAFF_LIST, VStaffListFields.FAC_ID);
            IOneSide osSLFacultyName = Fact.CreateOneSide(SqlTableNames.STAFF_LIST, VStaffListFields.FAC_NAME);
            IField fSLFaculty = Fact.CreateField("���������", FieldType.COMBO, osSLFacultyName, osSLFacultyId);

            IOneSide osSLTypeId = Fact.CreateOneSide(SqlTableNames.STAFF_LIST, VStaffListFields.TYPE_ID);
            IOneSide osSLTypeName = Fact.CreateOneSide(SqlTableNames.STAFF_LIST, VStaffListFields.TYPE_NAME);
            IField fSLType = Fact.CreateField("��� ���������", FieldType.COMBO, osSLTypeName, osSLTypeId);

            IOneSide osSLFundingId = Fact.CreateOneSide(SqlTableNames.STAFF_LIST, VStaffListFields.FUND_ID);
            IOneSide osSLFundingName = Fact.CreateOneSide(SqlTableNames.STAFF_LIST, VStaffListFields.FUND_NAME);
            IField fSLFunding = Fact.CreateField("�������� ��������������", FieldType.COMBO, osSLFundingName, osSLFundingId);

            IOneSide osSLCapacity = Fact.CreateOneSide(SqlTableNames.STAFF_LIST, VStaffListFields.CAPACITY);
            IField fSLCapacity = Fact.CreateField("���-�� ������", FieldType.TEXT, osSLCapacity, osSLCapacity);

            IOneSide osSLCategoryId = Fact.CreateOneSide(SqlTableNames.STAFF_LIST, VStaffListFields.CAT_ID);
            IOneSide osSLCategoryName = Fact.CreateOneSide(SqlTableNames.STAFF_LIST, VStaffListFields.CAT_NAME);
            IField fSLCategory = Fact.CreateField("���������", FieldType.COMBO, osSLCategoryName, osSLCategoryId);

            IOneSide osSLPKGId = Fact.CreateOneSide(SqlTableNames.STAFF_LIST, VStaffListFields.PKG_ID);
            IOneSide osSLPKGName = Fact.CreateOneSide(SqlTableNames.STAFF_LIST, VStaffListFields.PKG_NAME);
            IField fSLPKG = Fact.CreateField("���", FieldType.COMBO, osSLPKGName, osSLPKGId);

            IOneSide osSLLvlId = Fact.CreateOneSide(SqlTableNames.STAFF_LIST, VStaffListFields.LVL_ID);
            IOneSide osSLLvlName = Fact.CreateOneSide(SqlTableNames.STAFF_LIST, VStaffListFields.LVL_NAME);
            IField fSLLvl = Fact.CreateField("�������", FieldType.COMBO, osSLLvlName, osSLLvlId);

            IOneSide osSLSalary = Fact.CreateOneSide(SqlTableNames.STAFF_LIST, VStaffListFields.SALARY);
            IField fSLSalary = Fact.CreateField("�����(�� ����.�.)", FieldType.TEXT, osSLSalary, osSLSalary);

            IOneSide osSLPosGroupId = Fact.CreateOneSide(SqlTableNames.STAFF_LIST, VStaffListFields.POS_GROUP_ID);
            IOneSide osSLPosGroupName = Fact.CreateOneSide(SqlTableNames.STAFF_LIST, VStaffListFields.POS_GROUP_NAME);
            IField fSLPosGroup = Fact.CreateField("������ ����������", FieldType.COMBO, osSLPosGroupName, osSLPosGroupId);

            IGraphTable graphTableStaffList = new GraphTable(StringEnum.GetStringValue(SqlTableNames.STAFF_LIST), "id_pos");
            graphTableStaffList.AddField(fSLPositionName);
            graphTableStaffList.AddField(fieldStaffListDivision);
            graphTableStaffList.AddField(fSLFaculty);
            graphTableStaffList.AddField(fSLType);
            graphTableStaffList.AddField(fSLFunding);
            graphTableStaffList.AddField(fSLCapacity);
            graphTableStaffList.AddField(fSLCategory);
            graphTableStaffList.AddField(fSLPKG);
            graphTableStaffList.AddField(fSLLvl);
            graphTableStaffList.AddField(fSLSalary);
            graphTableStaffList.AddField(fSLPosGroup);

            #endregion

            #region Bonus

            IOneSide osBonusId = Fact.CreateOneSide(SqlTableNames.BONUS, VBonusFields.BON_ID);
            IOneSide osBonusName = Fact.CreateOneSide(SqlTableNames.BONUS, VBonusFields.BON_NAME);
            IField fBName = Fact.CreateField("�������� ��������", FieldType.COMBO, osBonusName, osBonusId);

            IOneSide osBTypId = Fact.CreateOneSide(SqlTableNames.BONUS, VBonusFields.BON_TYPE_ID);
            IOneSide osBTypeName = Fact.CreateOneSide(SqlTableNames.BONUS, VBonusFields.BON_TYPE_NAME);
            IField fBType = Fact.CreateField("��� ��������", FieldType.COMBO, osBTypeName, osBTypId);

            IOneSide osBAmTypeId = Fact.CreateOneSide(SqlTableNames.BONUS, VBonusFields.AM_TYPE_ID);
            IOneSide osBAmTypeName = Fact.CreateOneSide(SqlTableNames.BONUS, VBonusFields.AM_TYPE_NAME);
            IField fBAmountType = Fact.CreateField("���./����./�������.", FieldType.COMBO, osBAmTypeName, osBAmTypeId);

            IOneSide osBPercent = Fact.CreateOneSide(SqlTableNames.BONUS, VBonusFields.PERCENT);
            IField fBPercent = Fact.CreateField("�������", FieldType.TEXT, osBPercent, osBPercent);

            IOneSide osBAmount = Fact.CreateOneSide(SqlTableNames.BONUS, VBonusFields.AMOUNT);
            IField fBAmount = Fact.CreateField("������ ������", FieldType.TEXT, osBAmount, osBAmount);

            IOneSide osBFindingId = Fact.CreateOneSide(SqlTableNames.BONUS, VBonusFields.FUND_ID);
            IOneSide osBFindingName = Fact.CreateOneSide(SqlTableNames.BONUS, VBonusFields.FUND_NAME);
            IField fBFunding = Fact.CreateField("�������� ��������������", FieldType.COMBO, osBFindingName, osBFindingId);

            IOneSide osBDateStart = Fact.CreateOneSide(SqlTableNames.BONUS, VBonusFields.DATE_START);
            IField fBDateStart = Fact.CreateField("���� ������ ������", FieldType.DATE, osBDateStart, osBDateStart);

            IOneSide osBDateFinish = Fact.CreateOneSide(SqlTableNames.BONUS, VBonusFields.DATE_FINISH);
            IField fBDateFinish = Fact.CreateField("���� ��������� ������", FieldType.DATE, osBDateFinish, osBDateFinish);

            IOneSide osBFinalBonus = Fact.CreateOneSide(SqlTableNames.BONUS, VBonusFields.FINAL_BON);
            IField fBFinalBonus = Fact.CreateField("����������� ������ ������", FieldType.TEXT, osBFinalBonus, osBFinalBonus);

            IGraphTable graphTableBonus = new GraphTable(StringEnum.GetStringValue(SqlTableNames.BONUS), "id_b");
            graphTableBonus.AddField(fBName);
            graphTableBonus.AddField(fBType);
            graphTableBonus.AddField(fBAmountType);
            graphTableBonus.AddField(fBPercent);
            graphTableBonus.AddField(fBFunding);
            graphTableBonus.AddField(fBAmount);
            graphTableBonus.AddField(fBDateStart);
            graphTableBonus.AddField(fBDateFinish);
            graphTableBonus.AddField(fBFinalBonus);

            #endregion

            //History - ������� �� ����������� ��������, �� ��������������
            #region History

            IOneSide osHidE = Fact.CreateOneSide(SqlTableNames.HISTORY, HistoryFields.ID_E);
            IField fHIDE = Fact.CreateField("ID", FieldType.TEXT, osHidE, osHidE);

            IOneSide osHEmployeeName = Fact.CreateOneSide(SqlTableNames.HISTORY, HistoryFields.NAME);
            IField fhEmployeeName = Fact.CreateField("���", FieldType.TEXT, osHEmployeeName, osHEmployeeName);

            IOneSide osHEmployeeFam = Fact.CreateOneSide(SqlTableNames.HISTORY, HistoryFields.FAM);
            IField fHEmployeeFam = Fact.CreateField("�������", FieldType.TEXT, osHEmployeeFam, osHEmployeeFam);

            IOneSide osHEmployeeSecName = Fact.CreateOneSide(SqlTableNames.HISTORY, HistoryFields.SEC_NAME);
            IField fHEmployeeSecName = Fact.CreateField("��������", FieldType.TEXT, osHEmployeeSecName, osHEmployeeSecName);

            IOneSide osHGender = Fact.CreateOneSide(SqlTableNames.HISTORY, HistoryFields.GENDER);
            IField fHGender = Fact.CreateField("���", FieldType.TEXT, osHGender, osHGender);

            IOneSide osHDegree = Fact.CreateOneSide(SqlTableNames.HISTORY, HistoryFields.DEG);
            IField fHDegree = Fact.CreateField("������ �������", FieldType.TEXT, osHDegree, osHDegree);

            IOneSide osHRank = Fact.CreateOneSide(SqlTableNames.HISTORY, HistoryFields.RANK);
            IField fHRank = Fact.CreateField("������ ������", FieldType.TEXT, osHRank, osHRank);

            IOneSide osHDivision = Fact.CreateOneSide(SqlTableNames.HISTORY, HistoryFields.DIVISION);
            IField fHDivision = Fact.CreateField("�������������", FieldType.TEXT, osHDivision, osHDivision);

            IOneSide osHPosition = Fact.CreateOneSide(SqlTableNames.HISTORY, HistoryFields.POSITION);
            IField fHPosition = Fact.CreateField("�������� ���������", FieldType.TEXT, osHPosition, osHPosition);

            IOneSide osHLvl = Fact.CreateOneSide(SqlTableNames.HISTORY, HistoryFields.LVL);
            IField fHLvl = Fact.CreateField("�������", FieldType.TEXT, osHLvl, osHLvl);

            IOneSide osHPkg = Fact.CreateOneSide(SqlTableNames.HISTORY, HistoryFields.PKG);
            IField fHPkg = Fact.CreateField("���", FieldType.TEXT, osHPkg, osHPkg);

            IOneSide osHCategory = Fact.CreateOneSide(SqlTableNames.HISTORY, HistoryFields.CAT);
            IField fHCategory = Fact.CreateField("���������", FieldType.TEXT, osHCategory, osHCategory);

            IOneSide osHType = Fact.CreateOneSide(SqlTableNames.HISTORY, HistoryFields.TYPE);
            IField fHType = Fact.CreateField("��� ���������", FieldType.TEXT, osHType, osHType);

            IOneSide osHFunding = Fact.CreateOneSide(SqlTableNames.HISTORY, HistoryFields.FUND);
            IField fHFunding = Fact.CreateField("�������� ��������������", FieldType.TEXT, osHFunding, osHFunding);

            IOneSide osHFullwork = Fact.CreateOneSide(SqlTableNames.HISTORY, HistoryFields.FW);
            IField fHFullwork = Fact.CreateField("����������", FieldType.TEXT, osHFullwork, osHFullwork);

            IOneSide osHStavka = Fact.CreateOneSide(SqlTableNames.HISTORY, HistoryFields.STAVKA);
            IField fHStavka = Fact.CreateField("������", FieldType.TEXT, osHStavka, osHStavka);

            IOneSide osHSalary = Fact.CreateOneSide(SqlTableNames.HISTORY, HistoryFields.SALARY);
            IField fHSalary = Fact.CreateField("�����", FieldType.TEXT, osHSalary, osHSalary);

            IOneSide osHDateStart = Fact.CreateOneSide(SqlTableNames.HISTORY, HistoryFields.DATE_START);
            IField fHDateStart = Fact.CreateField("���� �����", FieldType.DATE, osHDateStart, osHDateStart);

            IOneSide osHDateFinish = Fact.CreateOneSide(SqlTableNames.HISTORY, HistoryFields.DATE_FINISH);
            IField fHDateFinish = Fact.CreateField("���� ����������", FieldType.DATE, osHDateFinish, osHDateFinish);

            IOneSide osHStatus = Fact.CreateOneSide(SqlTableNames.HISTORY, HistoryFields.STATUS);
            IField fHStatus = Fact.CreateField("������", FieldType.TEXT, osHStatus, osHStatus);

            IOneSide osHPosGroup = Fact.CreateOneSide(SqlTableNames.HISTORY, HistoryFields.GROUP_POS);
            IField fHPosGroup = Fact.CreateField("������ ����������", FieldType.TEXT, osHPosGroup, osHPosGroup);

            IGraphTable graphTableHistory = new GraphTable(StringEnum.GetStringValue(SqlTableNames.HISTORY), "id_h");
            graphTableHistory.AddField(fHIDE);
            graphTableHistory.AddField(fhEmployeeName);
            graphTableHistory.AddField(fHEmployeeFam);
            graphTableHistory.AddField(fHEmployeeSecName);
            graphTableHistory.AddField(fHGender);
            graphTableHistory.AddField(fHDegree);
            graphTableHistory.AddField(fHRank);
            graphTableHistory.AddField(fHDivision);
            graphTableHistory.AddField(fHPosition);
            graphTableHistory.AddField(fHLvl);
            graphTableHistory.AddField(fHPkg);
            graphTableHistory.AddField(fHCategory);
            graphTableHistory.AddField(fHType);
            graphTableHistory.AddField(fHSalary);
            graphTableHistory.AddField(fHFunding);
            graphTableHistory.AddField(fHFullwork);
            graphTableHistory.AddField(fHStavka);
            graphTableHistory.AddField(fHStatus);
            graphTableHistory.AddField(fHPosGroup);
            graphTableHistory.AddField(fHDateStart);
            graphTableHistory.AddField(fHDateFinish);

            #endregion

            #region HistoryBonusInHist

            IOneSide osHBInHisBName = Fact.CreateOneSide(SqlTableNames.HISTORY_BONUS_IN_HIST, HistoryBonFields.BON_NAME);
            IField fHBInHisBName = Fact.CreateField("�������� ��������", FieldType.TEXT, osHBInHisBName, osHBInHisBName);

            IOneSide osHBInHisBType = Fact.CreateOneSide(SqlTableNames.HISTORY_BONUS_IN_HIST, HistoryBonFields.TYPE);
            IField fHBInHisBType = Fact.CreateField("��� ��������", FieldType.TEXT, osHBInHisBType, osHBInHisBType);

            IOneSide osHBInHisAmountType = Fact.CreateOneSide(SqlTableNames.HISTORY_BONUS_IN_HIST, HistoryBonFields.AM_TYPE);
            IField fHBInHisAmountType = Fact.CreateField("���./����./�������.", FieldType.TEXT, osHBInHisAmountType, osHBInHisAmountType);

            IOneSide osHBInHisAmount = Fact.CreateOneSide(SqlTableNames.HISTORY_BONUS_IN_HIST, HistoryBonFields.AMOUNT);
            IField fHBInHisAmount = Fact.CreateField("������ ������", FieldType.TEXT, osHBInHisAmount, osHBInHisAmount);

            IOneSide osHBInHisBFund = Fact.CreateOneSide(SqlTableNames.HISTORY_BONUS_IN_HIST, HistoryBonFields.FUND);
            IField fHBInHisBFund = Fact.CreateField("�������� ��������������", FieldType.TEXT, osHBInHisBFund, osHBInHisBFund);

            IOneSide osHBInHisDateStart = Fact.CreateOneSide(SqlTableNames.HISTORY_BONUS_IN_HIST, HistoryBonFields.DATE_START);
            IField fHBInHisDateStart = Fact.CreateField("���� ������ ������", FieldType.DATE, osHBInHisDateStart, osHBInHisDateStart);

            IOneSide osHBInHisDateFinish = Fact.CreateOneSide(SqlTableNames.HISTORY_BONUS_IN_HIST, HistoryBonFields.DATE_FINISH);
            IField fHBInHisDateFinish = Fact.CreateField("���� ��������� ������", FieldType.DATE, osHBInHisDateFinish, osHBInHisDateFinish);

            IGraphTable graphTableBInHis = new GraphTable(StringEnum.GetStringValue(SqlTableNames.HISTORY_BONUS_IN_HIST), "id_bh");
            graphTableBInHis.AddField(fHBInHisBName);
            graphTableBInHis.AddField(fHBInHisBType);
            graphTableBInHis.AddField(fHBInHisAmountType);
            graphTableBInHis.AddField(fHBInHisAmount);
            graphTableBInHis.AddField(fHBInHisBFund);
            graphTableBInHis.AddField(fHBInHisDateStart);
            graphTableBInHis.AddField(fHBInHisDateFinish);            

            #endregion

            #region HistoryBonusInWork

            IOneSide osHBInWorkBName = Fact.CreateOneSide(SqlTableNames.HISTORY_BONUS_IN_WORK, HistoryBonFields.BON_NAME);
            IField fHBInWorkBName = Fact.CreateField("�������� ��������", FieldType.TEXT, osHBInWorkBName, osHBInWorkBName);

            IOneSide osHBInWorkBType = Fact.CreateOneSide(SqlTableNames.HISTORY_BONUS_IN_WORK, HistoryBonFields.TYPE);
            IField fHBInWorkBType = Fact.CreateField("��� ��������", FieldType.TEXT, osHBInWorkBType, osHBInWorkBType);

            IOneSide osHBInWorkAmountType = Fact.CreateOneSide(SqlTableNames.HISTORY_BONUS_IN_WORK, HistoryBonFields.AM_TYPE);
            IField fHBInWorkAmountType = Fact.CreateField("���./����./�������.", FieldType.TEXT, osHBInWorkAmountType, osHBInWorkAmountType);

            IOneSide osHBInWorkAmount = Fact.CreateOneSide(SqlTableNames.HISTORY_BONUS_IN_WORK, HistoryBonFields.AMOUNT);
            IField fHBInWorkAmount = Fact.CreateField("������ ������", FieldType.TEXT, osHBInWorkAmount, osHBInWorkAmount);

            IOneSide osHBInWorkBFund = Fact.CreateOneSide(SqlTableNames.HISTORY_BONUS_IN_WORK, HistoryBonFields.FUND);
            IField fHBInWorkBFund = Fact.CreateField("�������� ��������������", FieldType.TEXT, osHBInWorkBFund, osHBInWorkBFund);

            IOneSide osHBInWorkDateStart = Fact.CreateOneSide(SqlTableNames.HISTORY_BONUS_IN_WORK, HistoryBonFields.DATE_START);
            IField fHBInWorkDateStart = Fact.CreateField("���� ������ ������", FieldType.DATE, osHBInWorkDateStart, osHBInWorkDateStart);

            IOneSide osHBInWorkDateFinish = Fact.CreateOneSide(SqlTableNames.HISTORY_BONUS_IN_WORK, HistoryBonFields.DATE_FINISH);
            IField fHBInWorkDateFinish = Fact.CreateField("���� ��������� ������", FieldType.DATE, osHBInWorkDateFinish, osHBInWorkDateFinish);

            IGraphTable graphTableHBIhWork = new GraphTable(StringEnum.GetStringValue(SqlTableNames.HISTORY_BONUS_IN_WORK), "id_bh");
            graphTableHBIhWork.AddField(fHBInWorkBName);
            graphTableHBIhWork.AddField(fHBInWorkBType);
            graphTableHBIhWork.AddField(fHBInWorkAmountType);
            graphTableHBIhWork.AddField(fHBInWorkAmount);
            graphTableHBIhWork.AddField(fHBInWorkBFund);
            graphTableHBIhWork.AddField(fHBInWorkDateStart);
            graphTableHBIhWork.AddField(fHBInWorkDateFinish);

            #endregion

            #region Connections

            CreateConnection(graphTableEmployee, "id_e", graphTableWorkList, "id_e");
            CreateConnection(graphTableStaffList, "id_pos", graphTableWorkList, "id_pos");
            CreateConnection(graphTableBonus, "id_work", graphTableWorkList, "id_work");
            CreateConnection(graphTableHistory, "id_e", graphTableEmployee, "id_e");
            CreateConnection(graphTableHBIhWork, "id_work", graphTableWorkList, "id_work");
            CreateConnection(graphTableBInHis, "id_h", graphTableHistory, "id_h");

            #endregion

            #region TableGroup

            IGraphTablesGroup graphTablesGroupEmployee = new GraphTablesGroup("���������");
            graphTablesGroupEmployee.AddTable(graphTableEmployee);

            IGraphTablesGroup graphTablesGroupPosition = new GraphTablesGroup("���������");
            graphTablesGroupPosition.AddTable(graphTableStaffList);
            graphTablesGroupPosition.AddTable(graphTableWorkList);

            IGraphTablesGroup graphTablesGroupBonus = new GraphTablesGroup("��������");
            graphTablesGroupBonus.AddTable(graphTableBonus);

            IGraphTablesGroup graphTablesGroupHist = new GraphTablesGroup("�����(���������)");
            graphTablesGroupHist.AddTable(graphTableHistory);

            IGraphTablesGroup graphTablesGroupBonInHis = new GraphTablesGroup("�����(��������, ��������� � ������)");
            graphTablesGroupBonInHis.AddTable(graphTableBInHis);

            IGraphTablesGroup graphTablesGroupBonInWork = new GraphTablesGroup("�����(��������, ������� ���������)");
            graphTablesGroupBonInWork.AddTable(graphTableHBIhWork); 

            #endregion

            this.Groups.Add(graphTablesGroupEmployee);
            this.Groups.Add(graphTablesGroupPosition);
            this.Groups.Add(graphTablesGroupBonus);
            this.Groups.Add(graphTablesGroupHist);
            this.Groups.Add(graphTablesGroupBonInHis);
            this.Groups.Add(graphTablesGroupBonInWork);
        
        }
    }
}