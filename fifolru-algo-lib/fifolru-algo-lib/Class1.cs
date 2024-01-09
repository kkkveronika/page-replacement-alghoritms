using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fifolru_algo_lib
{
    public class Class1
    {
        public static List<string> fifo4(List<int> row_page, List<int> page_fifo4, int count_inter)
        {

            string str = "";
            List<string> res_row_page = new List<string>();
            for (int i = 0; i < row_page.Count; i++)
            {
                if (page_fifo4.Contains(row_page[i]))
                {
                    for (int k = 0; k < page_fifo4.Count(); k++)
                    {
                        str = str + page_fifo4[k].ToString();
                    }
                    res_row_page.Add(str);
                    str = "";
                }
                else
                {
                    count_inter++;
                    page_fifo4.RemoveAt(0);
                    page_fifo4.Add(row_page[i]);
                    for (int j = 0; j < page_fifo4.Count(); j++)
                    {
                        str = str + page_fifo4[j].ToString();
                    }
                    str = str + "X";
                    res_row_page.Add(str);
                    str = "";
                }
            }
            return res_row_page;
        }

        public static List<string> fifo5(List<int> row_page, List<string> page_fifo5, int count_inter)
        {
            string str = "";
            List<string> res_page_fifo5 = new List<string>();

            for (int i = 0; i < row_page.Count; i++)
            {
                if (page_fifo5[4] == "")
                {
                    if (page_fifo5.Contains(row_page[i].ToString()))
                    {
                        for (int k = 0; k < page_fifo5.Count(); k++)
                        {
                            str = str + page_fifo5[k];
                        }
                        res_page_fifo5.Add(str);
                        str = "";
                    }
                    else
                    {
                        count_inter++;
                        page_fifo5[4] = row_page[i].ToString();
                        for (int j = 0; j < page_fifo5.Count(); j++)
                        {
                            str = str + page_fifo5[j];
                        }
                        str = str + "X";
                        res_page_fifo5.Add(str);
                        str = "";
                    }
                }
                else
                {
                    if (page_fifo5.Contains(row_page[i].ToString()))
                    {
                        for (int k = 0; k < page_fifo5.Count(); k++)
                        {
                            str = str + page_fifo5[k];
                        }
                        res_page_fifo5.Add(str);
                        str = "";
                    }
                    else
                    {
                        count_inter++;
                        page_fifo5.RemoveAt(0);
                        page_fifo5.Add(row_page[i].ToString());
                        for (int j = 0; j < page_fifo5.Count(); j++)
                        {
                            str = str + page_fifo5[j];
                        }
                        str = str + "X";
                        res_page_fifo5.Add(str);
                        str = "";
                    }
                }
            }
            return res_page_fifo5;
        }
        public static List<string> lru4(List<int> row_page, List<int> page_lru4, int count_inter)
        {
            List<string> res_lru4 = new List<string>();
            count_inter = 0;
            string str = "";
            for (int i = 0; i < row_page.Count; i++)
            {
                if (page_lru4.Contains(row_page[i]))
                {
                    page_lru4.RemoveAt(page_lru4.IndexOf(row_page[i]));
                    page_lru4.Add(row_page[i]);
                    for (int k = 0; k < page_lru4.Count(); k++)
                    {
                        str = str + page_lru4[k];
                    }
                    res_lru4.Add(str);
                    str = "";
                }
                else
                {
                    count_inter++;
                    page_lru4.RemoveAt(0);
                    page_lru4.Add(row_page[i]);
                    for (int j = 0; j < page_lru4.Count(); j++)
                    {
                        str = str + page_lru4[j];
                    }
                    str = str + "X";
                    res_lru4.Add(str);
                    str = "";
                }
            }
            return res_lru4;
        }
        
        public static List<string> lru5(List<int> row_page, List<string> page_lru5, int count_inter)
        {
            List<string> res_page_lru5 = new List<string>();
            count_inter = 0;
            string str = "";
            for (int i = 0; i < row_page.Count; i++)
            {
                if (page_lru5[4] == "")
                {
                    if (page_lru5.Contains(row_page[i].ToString()))
                    {
                        page_lru5.RemoveAt(page_lru5.IndexOf(row_page[i].ToString()));
                        page_lru5[3] = row_page[i].ToString();
                        page_lru5.Add("");
                        for (int k = 0; k < page_lru5.Count(); k++)
                        {
                            str = str + page_lru5[k];
                        }
                        res_page_lru5.Add(str);
                        str = "";
                    }
                    else
                    {
                        count_inter++;
                        page_lru5[4] = row_page[i].ToString();
                        for (int j = 0; j < page_lru5.Count(); j++)
                        {
                            str = str + page_lru5[j];
                        }
                        str = str + "X";
                        res_page_lru5.Add(str);
                        str = "";
                    }
                }
                else
                {
                    if (page_lru5.Contains(row_page[i].ToString()))
                    {
                        page_lru5.RemoveAt(page_lru5.IndexOf(row_page[i].ToString()));
                        page_lru5.Add(row_page[i].ToString());
                        for (int k = 0; k < page_lru5.Count(); k++)
                        {
                            str = str + page_lru5[k];
                        }
                        res_page_lru5.Add(str);
                        str = "";
                    }
                    else
                    {
                        count_inter++;
                        page_lru5.RemoveAt(0);
                        page_lru5.Add(row_page[i].ToString());
                        for (int j = 0; j < page_lru5.Count(); j++)
                        {
                            str = str + page_lru5[j];
                        }
                        str = str + "X";
                        res_page_lru5.Add(str);
                        str = "";
                    }
                }
            }
            return res_page_lru5;
        }

    }
}
