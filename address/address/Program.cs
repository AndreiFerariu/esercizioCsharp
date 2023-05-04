using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace address
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] bit = {1,1,1,1,1,1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0};
            double value = 0;
            string address = "";
            int sent = 0;
            do
            {
                for (int j = 8; j > 0; j--)
                {
                    if (sent != 32)
                    {
                        if (bit[sent] == 1)
                        {
                            value += (Math.Pow(2, (double)j - 1));
                        }
                        sent++;
                    }
                }
                address += Convert.ToString(value) + ".";
                value = 0;

            } while (sent != 32);

           Console.WriteLine(address);
            Console.ReadLine();
        }
    }
}
