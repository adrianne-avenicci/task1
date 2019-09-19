using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask01
{
    class Program
    {
        static void Main(string[] args)
        {
            short[] data = GetValues();

            Console.Write(GetPercentile(data, 0.9).ToString("0.00") + "\n");    //  90s percentile
            Console.Write(GetPercentile(data, 0.5).ToString("0.00") + "\n");    //  median (50s percentile)
            Console.Write(data.Max().ToString("0.00") + "\n");                  //  max
            Console.Write(data.Min().ToString("0.00") + "\n");                  //  min
            Console.Write(GetAverage(data).ToString("0.00") + "\n");            //  average

            Console.ReadLine();
        }
        static public short[] GetValues()
        {
            string path = Console.ReadLine();

            string[] lines = System.IO.File.ReadAllLines(path);
            if (lines.Length > 1000)
            {
                Array.Resize(ref lines, 1000);  //cut an array to 1000 elements to fit the task
            }

            short[] data_base = new short[lines.Length];

            //System.Console.WriteLine("Contents of WriteLines2.txt :");
            for (int i = 0; i <= lines.Length - 1; i++)
            {
                data_base[i] = Convert.ToInt16(lines[i]);
                //Console.WriteLine("\t" + data_base[i]);
            }

            return data_base;
        }
        static public double GetPercentile(short[] Sequence, double PercentileValue)
        {
            Array.Sort(Sequence);

            int N = Sequence.Length;
            double n = (N - 1) * PercentileValue + 1;
            //double n = (N + 1) * PercentileValue;

            if (n == 1d) return Sequence[0];
            else if (n == N) return Sequence[N - 1];
            else
            {
                short k = (short)n;
                double d = n - k;
                return Sequence[k - 1] + d * (Sequence[k] - Sequence[k - 1]);
            }
        }
        static public double GetAverage(short[] Sequence)
        {
            double sum = 0;
            foreach (int element in Sequence)
            {
                sum = sum + element;
            }

            return sum/Sequence.Length;
        }
    }
}