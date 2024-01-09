using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{

    class Crc30B9C7
    {
        static ulong[] crc30_table = new ulong[256];

        static void Main()
        {
            GenerateTable();

            string input = "123456789";
            byte[] bytes = System.Text.Encoding.ASCII.GetBytes(input);

            ulong crc = 0x3FFFFFFF;

            foreach (byte b in bytes)
            {
                crc = (crc >> 8) ^ crc30_table[(crc ^ b) & 0xFF];
            }

            crc ^= 0x3FFFFFFF;

            Console.WriteLine(String.Format("{0:X8}", crc));
        }

        static void GenerateTable()
        {
            const ulong poly = 0x2030B9C7;
            for (int i = 0; i < 256; i++)
            {
                ulong crc = (ulong)i << 24;
                for (int j = 0; j < 8; j++)
                {
                    if ((crc & 0x80000000) != 0)
                    {
                        crc = (crc << 1) ^ poly;
                    }
                    else
                    {
                        crc <<= 1;
                    }
                }
                crc30_table[i] = crc;
            }
        }
    }
}
