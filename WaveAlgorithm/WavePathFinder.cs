using System.Collections.Generic;

namespace MyGraph.WaveAlgorithm
{
    public class WavePathFinder : IWavePathFinder
    {
        public void MarkPath(IWavePoint first, IWavePoint second)
        {
            //������������� ����� �������, ����� ����
            first.Flag = 1;

            //��������� ���������� ����
            MarkAllPath(first, second);
        }

        private void MarkAllPath(IWavePoint first, IWavePoint second)
        {
            IWavePoint current = first;

            while (second.Flag == 0 && current.Flag != 10)
            {
                //���� "�������" 
                List<IWavePoint> neigbs = new List<IWavePoint>();

                foreach (IWaveConnection connection in current.Connections)
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
                foreach (IWavePoint neigb in neigbs)
                {
                    MarkAllPath(neigb, second);
                }
            }
        }

        public IEnumerable<IWavePoint> GetPath(IWavePoint first, IWavePoint second)
        {
            List<IWavePoint> pathPoints = new List<IWavePoint>();

            //���� � �������� �������
            IWavePoint current = first;

            //�� ��� ��� ���� �� ��������� � ������ ����������
            while (current.Flag != 1)
            {
                int lastFlag = current.Flag;

                foreach (IWaveConnection connection in current.Connections)
                {
                    if (connection.ForeignPoint.Flag == current.Flag - 1)
                    {
                        yield return current;
                        pathPoints.Add(current);
                        current = connection.ForeignPoint;
                        break;
                    }
                }
            }

            pathPoints.Add(current);
            //return pathPoints;
        }
    }
}