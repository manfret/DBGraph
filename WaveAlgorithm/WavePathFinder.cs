using System.Collections.Generic;

namespace MyGraph.WaveAlgorithm
{
    public class WavePathFinder : IWavePathFinder
    {
        public void MarkPath(IWavePoint first, IWavePoint second)
        {
            //устанавливаем точку отсчета, меняя флаг
            first.Flag = 1;

            //маркируем оставшийся граф
            MarkAllPath(first, second);
        }

        private void MarkAllPath(IWavePoint first, IWavePoint second)
        {
            IWavePoint current = first;

            while (second.Flag == 0 && current.Flag != 10)
            {
                //лист "соседей" 
                List<IWavePoint> neigbs = new List<IWavePoint>();

                foreach (IWaveConnection connection in current.Connections)
                {
                    //не более 10 переходов
                    //и только для непомеченных
                    if (connection.ForeignPoint.Flag == 0 && connection.ForeignPoint.Flag <= 10)
                    {
                        int curFlag = current.Flag;
                        curFlag++;
                        connection.ForeignPoint.Flag = curFlag;
                        //добавляем с соседей только помеченные на этом шаге
                        neigbs.Add(connection.ForeignPoint);
                    }
                }

                //запускаем рекурсивную разметку для всех соседей
                foreach (IWavePoint neigb in neigbs)
                {
                    MarkAllPath(neigb, second);
                }
            }
        }

        public IEnumerable<IWavePoint> GetPath(IWavePoint first, IWavePoint second)
        {
            List<IWavePoint> pathPoints = new List<IWavePoint>();

            //идем в обратном порядке
            IWavePoint current = first;

            //до тех пор пока не вернулись в первую помеченную
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