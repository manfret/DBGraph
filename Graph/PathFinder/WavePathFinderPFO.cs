using System.Collections.Generic;
using System.Linq;
using MyGraph.Field;
using MyGraph.SqlBlocks.Factory;
using MyGraph.SqlBlocks.Sides;
using MyGraph.SqlBlocks.Sides.Comparers;
using Ninject;
using Util.Ninject;

namespace MyGraph.Graph.PathFinder
{
    public class WavePathFinderPFO : IWavePathFinderPFO
    {
        private readonly ISqlBlocksFactory _fact;

        public WavePathFinderPFO()
        {
            this._fact = NinjectKernel.Kernel.Get<ISqlBlocksFactory>();
        }

        public void GetWhereFromByPath(IField first, IField second, List<IGraphTablesGroup> groups, ref List<string> @from, ref List<ITwoSides> @where)
        {
            ResetFlags(groups);

            IGraphTable firstPoint = null;
            IGraphTable secondPoint = null;

            //��������� ���������� ��� ������ ����������  �������� � ����������� �� ���������
            List<ITwoSides> localResWhere = new List<ITwoSides>();

            //������� �������������� ������� ��� �����
            foreach (IGraphTable tablePoint in groups.SelectMany(treeGroup => treeGroup.GraphTables))
            {
                if (tablePoint.Fields.FirstOrDefault(a => a.SelectKey.Equals(first.SelectKey)) != null)
                {
                    firstPoint = tablePoint;
                }

                if (tablePoint.Fields.FirstOrDefault(a => a.SelectKey.Equals(second.SelectKey)) != null)
                {
                    secondPoint = tablePoint;
                }
            }

            if (firstPoint == null || secondPoint == null) return;
            //���� ���� ����� ����� � ��� �� ��������
            if (firstPoint.PrimaryKey.Equals(secondPoint.PrimaryKey))
            {
                from.Add(firstPoint.PrimaryKey.Table);
                return;
            }

            GetWhereFromByPath(secondPoint, firstPoint, ref @from, ref localResWhere);

            //            ����������� �� ����������
            from = from.Distinct().ToList();
            localResWhere = localResWhere.Distinct(new TwoSideComparer()).ToList();
            where.AddRange(localResWhere);
        }

        private static void ResetFlags(IEnumerable<IGraphTablesGroup> groups)
        {
            foreach (IGraphTable tablePoint in groups.SelectMany(treeGroup => treeGroup.GraphTables))
            {
                tablePoint.Flag = 0;
            }
        }

        private static void MarkPath(IGraphTable first, IGraphTable second)
        {
            //������������� ����� �������, ����� ����
            first.Flag = 1;

            //��������� ���������� ����
            MarkAllPath(first, second);
        }

        private static void MarkAllPath(IGraphTable first, IGraphTable second)
        {
            IGraphTable current = first;

            while (second.Flag == 0 && current.Flag != 10)
            {
                //���� "�������" 
                List<IGraphTable> neigbs = new List<IGraphTable>();

                foreach (IGraphConnection connection in current.Connections)
                {
                    //�� ����� 10 ���������
                    //� ������ ��� ������������
                    if (connection.ForeignPoint.Flag == 0 && connection.ForeignPoint.Flag <= 10)
                    {
                        int curFlag = current.Flag;
                        curFlag++;
                        connection.ForeignPoint.Flag = curFlag;
                        //��������� � ������� ������ ���������� �� ���� ����
                        neigbs.Add(connection.ForeignPoint);
                    }
                }

                //��������� ����������� �������� ��� ���� �������
                foreach (IGraphTable neigb in neigbs)
                {
                    MarkAllPath(neigb, second);
                }
            }
        }

        public void GetWhereFromByPath(IGraphTable first, IGraphTable second, ref List<string> @from, ref List<ITwoSides> @where)
        {
            MarkPath(first, second);
            List<IGraphTable> pathPoints = new List<IGraphTable>();

            //���� � �������� �������
            IGraphTable current = second;

            //�� ��� ��� ���� �� ��������� � ������ ����������
            while (current.Flag != 1 && current != first)
            {
                foreach (var waveConnection in current.Connections)
                {
                    var connection = (GraphConnection) waveConnection;
                    if (connection.ForeignPoint.Flag != current.Flag - 1) continue;
                    @from.Add(current.PrimaryKey.Table);
                    //connection �� �������� ������ � ����� ������� - ������ �������� ���� � id
                    //�.�. ���� ����������������
                    //������� ��� ������� ����� �� current.PrimaryKey.Table
                    IOneSide oneSide = this._fact.CreateOneSide(current.PrimaryKey.Table, connection.IdOwn);
                    IOneSide twoSide = this._fact.CreateOneSide(connection.ForeignPoint.PrimaryKey.Table, connection.IdForeign);
                    ITwoSides whereBlock = this._fact.CreateTwoSide(oneSide, twoSide);
                    @where.Add(whereBlock);
                    pathPoints.Add(current);
                    current = connection.ForeignPoint;
                    break;
                }
            }

            pathPoints.Add(current);
            @from.Add(current.PrimaryKey.Table);
        }

        public IList<IGraphTable> GetPathTables(IGraphTable first, IGraphTable second)
        {
            MarkPath(first, second);
            List<IGraphTable> pathPoints = new List<IGraphTable>();

            //���� � �������� �������
            IGraphTable current = second;

            //�� ��� ��� ���� �� ��������� � ������ ����������
            while (current.Flag != 1 && current != first)
            {
                foreach (var waveConnection in current.Connections)
                {
                    var connection = (GraphConnection)waveConnection;
                    if (connection.ForeignPoint.Flag == current.Flag - 1)
                    {
                        pathPoints.Add(current);
                        current = connection.ForeignPoint;
                    }
                }
            }
            pathPoints.Add(current);
            pathPoints = pathPoints.Distinct(new GraphTableEqualityComparer()).ToList();
            return pathPoints;
        }
    }
}