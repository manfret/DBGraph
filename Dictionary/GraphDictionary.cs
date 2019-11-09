using System.Collections.Generic;
using System.Linq;
using MyGraph.Graph.GraphData.Enums;
using Ninject;
using PFOClasses.All.All;
using PFOClasses.Refs.Facades;
using PFOClasses.Refs.Ref;
using PFOClasses.StaffPosition;
using Util.Ninject;

namespace MyGraph.Dictionary
{
    //словарь соответсвия всех combo всем IAll
    public class GraphDictionary : IGraphDictionary
    {
        private readonly List<IGraphContentForCmb> _contents;

        public GraphDictionary()
        {
            this._contents = new List<IGraphContentForCmb>();

            FillDictionary();
        }

        private void SetField(string codeName, List<IRefFacade> content)
        {
            //не будем создавать отдельную фабрику чтобы генерировать GraphContentForCmb
            GraphContentForCombo one = new GraphContentForCombo(codeName, content);
            this._contents.Add(one);
        }

        public IGraphContentForCmb GetContent(string codeName)
        {
            return this._contents.SingleOrDefault(a => a.CodeName == codeName);
        }

        private void FillDictionary()
        {
            IAll<IRefDegree> allDegree = NinjectKernel.Kernel.Get<IAll<IRefDegree>>();
            List<IRefFacade> lstDegries = allDegree.GetAllFacades();
            SetField(EnumsConcatToSql.GetStr(SqlTableNames.EMP, VEmpFields.DEG_ID), lstDegries);

            IAll<IRefRank> allRank = NinjectKernel.Kernel.Get<IAll<IRefRank>>();
            List<IRefFacade> lstRanks = allRank.GetAllFacades();
            SetField(EnumsConcatToSql.GetStr(SqlTableNames.EMP, VEmpFields.RANK_ID), lstRanks);

            IAll<IRefExcept> allRemove = NinjectKernel.Kernel.Get<IAll<IRefExcept>>();
            List<IRefFacade> lstRemoveTypes = allRemove.GetAllFacades();
            SetField(EnumsConcatToSql.GetStr(SqlTableNames.EMP, VEmpFields.REASON_ID), lstRemoveTypes);

            IAll<IRefFullwork> allFullwork = NinjectKernel.Kernel.Get<IAll<IRefFullwork>>();
            List<IRefFacade> lstFullworks = allFullwork.GetAllFacades();
            SetField(EnumsConcatToSql.GetStr(SqlTableNames.WORK_LIST, VWorkListFields.FW_ID), lstFullworks);

            IAll<IRefBonusType> allBonusType = NinjectKernel.Kernel.Get<IAll<IRefBonusType>>();
            List<IRefFacade> lstBonusTypes = allBonusType.GetAllFacades();
            SetField(EnumsConcatToSql.GetStr(SqlTableNames.BONUS, VBonusFields.BON_TYPE_ID), lstBonusTypes);

            IAll<IRefAmountType> allBonusAmountType = NinjectKernel.Kernel.Get<IAll<IRefAmountType>>();
            List<IRefFacade> lstBonusAmountTypes = allBonusAmountType.GetAllFacades();
            SetField(EnumsConcatToSql.GetStr(SqlTableNames.BONUS, VBonusFields.AM_TYPE_ID), lstBonusAmountTypes);

            IAll<IRefBonus> allBonus = NinjectKernel.Kernel.Get<IAll<IRefBonus>>();
            List<IRefFacade> lstBonuses = allBonus.GetAllFacades();
            SetField(EnumsConcatToSql.GetStr(SqlTableNames.BONUS, VBonusFields.BON_ID), lstBonuses);

            IAll<IRefDivision> allDivision = NinjectKernel.Kernel.Get<IAll<IRefDivision>>();
            List<IRefFacade> lstDivisions = allDivision.GetAllFacades();
            SetField(EnumsConcatToSql.GetStr(SqlTableNames.STAFF_LIST, VStaffListFields.DIV_ID), lstDivisions);

            IAll<IRefFunding> allFunding = NinjectKernel.Kernel.Get<IAll<IRefFunding>>();
            List<IRefFacade> lstFundingTypes = allFunding.GetAllFacades();
            SetField(EnumsConcatToSql.GetStr(SqlTableNames.STAFF_LIST, VBonusFields.FUND_ID), lstFundingTypes);

            IAll<IRefCategory> allCategories = NinjectKernel.Kernel.Get<IAll<IRefCategory>>();
            List<IRefFacade> lstCategories = allCategories.GetAllFacades();
            SetField(EnumsConcatToSql.GetStr(SqlTableNames.STAFF_LIST, VStaffListFields.CAT_ID), lstCategories);

            IAll<IRefFaculty> allFaculties = NinjectKernel.Kernel.Get<IAll<IRefFaculty>>();
            List<IRefFacade> lstFaculties = allFaculties.GetAllFacades();
            SetField(EnumsConcatToSql.GetStr(SqlTableNames.STAFF_LIST, VStaffListFields.FAC_ID), lstFaculties);

            IAll<IRefLvl> allLvls = NinjectKernel.Kernel.Get<IAll<IRefLvl>>();
            List<IRefFacade> lstLvls = allLvls.GetAllFacades();
            SetField(EnumsConcatToSql.GetStr(SqlTableNames.STAFF_LIST, VStaffListFields.LVL_ID), lstLvls);

            IAll<IRefPkg> allPkgs = NinjectKernel.Kernel.Get<IAll<IRefPkg>>();
            List<IRefFacade> lstPkgs = allPkgs.GetAllFacades();
            SetField(EnumsConcatToSql.GetStr(SqlTableNames.STAFF_LIST, VStaffListFields.PKG_ID), lstPkgs);

            IAll<IRefPosGroup> allPosGroups = NinjectKernel.Kernel.Get<IAll<IRefPosGroup>>();
            List<IRefFacade> lstPosGroups = allPosGroups.GetAllFacades();
            SetField(EnumsConcatToSql.GetStr(SqlTableNames.STAFF_LIST, VStaffListFields.POS_GROUP_ID), lstPosGroups);

            IAll<IRefType> allTypes = NinjectKernel.Kernel.Get<IAll<IRefType>>();
            List<IRefFacade> lstTypes = allTypes.GetAllFacades();
            SetField(EnumsConcatToSql.GetStr(SqlTableNames.STAFF_LIST, VStaffListFields.TYPE_ID), lstTypes);

        }

        //Список должностей может заполняться отдельно
        //т.к. чтобы определить должность нужно сначала выбрать вид персонала и подразделение
        public List<IRefFacade> GetContentForPos(int idDiv, int idType)
        {
            IAll<IStaffPosition> allPoses = NinjectKernel.Kernel.Get<IAll<IStaffPosition>>();
            List<IRefFacade> lstPoses = (allPoses as AllStaffPosition).GetAllAdaptersByDivType(idDiv, idType);
            return lstPoses;
        }
    }
}
