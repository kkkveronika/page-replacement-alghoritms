using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<byte> polynom = new List<byte>() { 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 1, 0, 1, 1, 1, 0, 0, 1, 1, 1, 0, 0, 0, 1, 1, 1 };
            List<byte> mes30 = new List<byte>()   { 0, 0, 0, 0, 1, 1, 0, 0, 0, 1, 0, 0, 1, 1, 0, 0, 1, 0, 0, 0, 1, 1, 0, 0, 1, 1, 0, 0, 1, 1, 0, 1 };
            List<byte> message = new List<byte>() { 0, 0, 0, 0, 1, 1, 0, 1, 0, 1, 0, 0, 1, 1, 0, 1, 1, 0, 0, 0, 1, 1, 0, 1, 1, 1, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 1 };
            List<byte> state = new List<byte>();
            state = xor(polynom, mes30);
            List<byte> res = new List<byte>();
            res= shift_register(polynom, state, message);
            for(int i=0; i<res.Count(); i++)
            {
                Console.Write(res[i]);
            }

        }

        static List<byte> xor(List<byte> pol, List<byte> m30)
        {
            List<byte> XOR_state= new List<byte>();
            for(int i=0; i<pol.Count(); i++)
            {
                if (pol[i] == m30[i])
                {
                    XOR_state.Add(0);
                }
                else
                {
                    XOR_state.Add(1);
                }
            }
            return XOR_state;
        }

        static List<byte> shift_register(List<byte> poly, List<byte> st, List<byte> mes)
        {
            byte first_bit_mes = mes[0];
            mes.RemoveAt(0);
            byte first_bit_state = st[0];
            st.RemoveAt(0);
            st.Add(first_bit_mes);
            while (mes.Count() != 0)
            {
                if (first_bit_state == 0)
                {


                }
                else if (first_bit_state == 1)
                {
                    xor(poly, st);
                }
            }
            return st;
        }

        //static uint xor(uint poly, uint state, uint message)
        //{

        //}
    }
}