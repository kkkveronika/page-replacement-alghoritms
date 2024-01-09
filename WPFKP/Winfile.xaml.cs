using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPFKP
{
    /// <summary>
    /// Логика взаимодействия для Winfile.xaml
    /// </summary>
    public partial class Winfile : Window
    {


        public Winfile()
        {
            InitializeComponent();
        }



        public string Input_row_page(List<int> row_page)
        {
            MainWindow.row_page.Clear();
            int pg = 0;
            string file_name = "";
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            if (ofd.FileName != "")
            {
                StreamReader sr = new StreamReader(ofd.FileName);
                while (!sr.EndOfStream)
                {
                    string s = sr.ReadLine();
                    try
                    {
                        pg=int.Parse(s);
                        if (pg < 100)
                        {
                            row_page.Add(pg);
                        }
                        else
                        {
                            MessageBox.Show("Страница должна являться значением от 0 до 99");
                        }
                        
                    }
                    catch
                    {
                        MessageBox.Show("В файле должны содержаться только цифры.\nВсе остальные символы из файла не считаны.");
                    }
                }
                file_name = ofd.FileName;
            }
            else
            {
                MessageBox.Show("Файл не выбран");
                row_page.Clear();
            }
            return file_name;
        }

        public string Input_blockpage(List<int> page_fifo4, List<string> page_fifo5, List<int> page_lru4, List<string> page_lru5)
        {
            page_fifo4.Clear();
            page_fifo5.Clear();
            page_lru4.Clear();
            page_lru5.Clear();
            string file_name="";
            int pg = 0;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            if (ofd.FileName != "")
            {
                StreamReader sr = new StreamReader(ofd.FileName);
                while (!sr.EndOfStream)
                {
                    string s = sr.ReadLine();
                    try
                    {
                        pg=int.Parse(s);
                        if (pg < 100)
                        {
                            page_fifo4.Add(pg);
                        }
                        else
                        {
                            MessageBox.Show("Страничные блоки должны являться значением от 0 до 99");
                        }
                    }
                    catch
                    {
                        MessageBox.Show("В файле должны содержаться только цифры.\nВсе остальные символы из файла не считаны.");
                        continue;
                    }
                    page_fifo5.Add(pg.ToString());
                    try { page_lru4.Add(pg); }
                    catch
                    {
                       
                    }
                    page_lru5.Add(pg.ToString());
                    file_name = ofd.FileName;
                }
            }
            else
            {
                MessageBox.Show("Файл не выбран");
                page_fifo4.Clear();
                page_fifo5.Clear();
                page_lru4.Clear();
                page_lru5.Clear();
            }
            return file_name;
        }

       
        private void Butpage_Click(object sender, RoutedEventArgs e)
        {
            string file_name=Input_row_page(MainWindow.row_page);
        

            Butpage.Content = System.IO.Path.GetFileNameWithoutExtension(file_name);
            
            
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (MainWindow.page_fifo4.Count() == 0)
            {
                MessageBox.Show("Файл страничные блоки пустой.");
            }
            else
            {
                if (MainWindow.page_fifo4.Count() > 4)
                {
                    MainWindow.page_fifo4.RemoveRange(4, MainWindow.page_fifo4.Count() - 4);
                    MessageBox.Show("Страничных блоков должно быть 4, загружены первые 4 числа.");
                    MainWindow.page_fifo5.Add("");
                    MainWindow.page_lru5.Add("");
                }
                if (MainWindow.page_fifo4.Count() < 4)
                {
                    MessageBox.Show("Страничных блоков должно быть 4.");
                }
                if (MainWindow.page_fifo4.Count() == 4 && MainWindow.row_page.Count()!=0)
                {
                    MessageBox.Show("Сохранено.");
                    MainWindow.page_fifo5.Add("");
                    MainWindow.page_lru5.Add("");
                    Winfile_window.Close();
                }
            }
            if (MainWindow.row_page.Count() == 0)
            {
                MessageBox.Show("Файл страницы пустой.");
            }
            
        }

        private void Butblockpage_Click_1(object sender, RoutedEventArgs e)
        {
            string file_name=Input_blockpage(MainWindow.page_fifo4, MainWindow.page_fifo5, MainWindow.page_lru4, MainWindow.page_lru5);
            
            Butblockpage.Content = System.IO.Path.GetFileNameWithoutExtension(file_name);
        }
    }
}
