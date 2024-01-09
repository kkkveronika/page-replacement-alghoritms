using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Crc30B9C7
{
    static ulong[] crc30_table = new ulong[256];

    static void Main()
    {
        string input = "123456789";
        ulong result = CalcCrc30B9C7(input);
        Console.WriteLine(result.ToString("X8"));
        Console.WriteLine();
    }

    static void CreateTable()
    {
        ulong polynomial = 0x2030B9C7;
        for (ulong i = 0; i < 256; i++)
        {
            ulong temp = i;
            for (int j = 0; j < 8; j++)
            {
                if ((temp & 1) != 0)
                {
                    temp = (temp >> 1) ^ polynomial;
                }
                else
                {
                    temp = (temp >> 1);
                }
            }
            crc30_table[i] = temp;
        }
    }

    static ulong CalcCrc30B9C7(string input)
    {
        CreateTable();
        ulong crc = 0x3FFFFFFF;
        for (int i = 0; i < input.Length; i++)
        {
            crc = (crc >> 8) ^ crc30_table[(crc & 0xFF) ^ input[i]];
        }
        return crc ^ 0x3FFFFFFF;
    }
}

