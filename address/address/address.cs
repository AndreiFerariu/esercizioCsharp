using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace address
{
  public interface IAddress
    {
        string generateIPv4();
        string generateSubnet();
    }
   public class address : IAddress
    {
        int[] bit = new int[32];

        address(int[] bit)
        {
            this.bit = bit;
        }

        public int[] get_bit()
        {
            return bit;

        }

       
         int Get_Cidr()
        {
            int[] bit = get_bit();
            int cidr = 0;

            for (int i = 0; i < bit.Length;i++)
            {
                if (bit[i] == 1)
                    cidr++;
            }
            return cidr;

        }
        public string generateIPv4()
        {
            int[] bit = get_bit();
            int cidr = Get_Cidr();
            int sent = 0;
            double value = 0;
            string address = "";

            do
            {
                for (int j = 8; j > 0; j--)
                {
                    if (sent != 32)
                    {
                        if (bit[sent] == 1 && sent <cidr )
                        {
                            value += (Math.Pow(2, (double)j - 1));
                        }
                        sent++;
                    }
                }
                if(sent == 32 && bit[sent] <254 )
                {
                    value++;
                }
                address += Convert.ToString(value) + ".";
                value = 0;

            } while (sent != 32);
            return address;
        }
      public string generateSubnet()
        {
            int[] bit = get_bit();
            int cidr = Get_Cidr();
            double value = 0;
            string subnet = "";
            int sent = 0;
            do
            {
                for (int j = 8; j > 0; j--)
                {
                    if (sent != 32)
                    {
                        if (sent < cidr)
                        {
                            value += (Math.Pow(2, (double)j - 1));
                        }
                        sent++;
                    }
                }
                subnet += Convert.ToString(value) + ".";
                value = 0;

            } while (sent != 32);

            return subnet;

        }

    }
}
