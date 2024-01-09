using System;
using System.Collections.Generic;
using System.Data;
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
using static System.Net.Mime.MediaTypeNames;


namespace WPFKP
{
    /// <summary>
    /// Логика взаимодействия для Winkeyboard.xaml
    /// </summary>
    public partial class Winkeyboard : Window
    {
        public Winkeyboard()
        {
            InitializeComponent();
            
            MainWindow.row_page.Clear();
            MainWindow.page_fifo4.Clear();
            MainWindow.page_fifo5.Clear();
            MainWindow.page_lru4.Clear();
            MainWindow.page_lru5.Clear();
        }

        private void Cell1_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab)
                firstblock.Focus();
            
        }
        private void Cell2_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab)
                secondblock.Focus();
            
        }
        private void Cell3_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab)
                thirdblock.Focus();
            
        }
        private void Cell4_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab)
                fourthblock.Focus();

        }

        private void textBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string s = "";
            bool error = false;
            
            if (rowpage.Text.Length == 0)
            {
                MessageBox.Show("Пожалуйста заполните страницы");
                MainWindow.row_page.Clear();
                MainWindow.page_fifo4.Clear();
                MainWindow.page_fifo5.Clear();
                MainWindow.page_lru4.Clear();
                MainWindow.page_lru5.Clear();
                error = true;
            }
            else
            {
                s = rowpage.Text;
                string[] words = s.Split(new char[] { ' ' });

                foreach (string page in words)
                {
                    MainWindow.row_page.Add(int.Parse(page));
                }
            }
            if (firstblock.Text.Length == 0 || secondblock.Text.Length == 0 || thirdblock.Text.Length == 0 || fourthblock.Text.Length == 0)
            {
                MessageBox.Show("Пожалуйста заполните все страничные блоки");
                MainWindow.row_page.Clear();
                MainWindow.page_fifo4.Clear();
                MainWindow.page_fifo5.Clear();
                MainWindow.page_lru4.Clear();
                MainWindow.page_lru5.Clear();
                error = true;

            }
            else
            {
                s = firstblock.Text;
                s += secondblock.Text;
                s += thirdblock.Text;
                s += fourthblock.Text;
                for (int i = 0; i < s.Length; i++)
                {
                    if (s[i].ToString() != " ")
                    {
                        MainWindow.page_fifo4.Add(int.Parse(s[i].ToString()));
                        MainWindow.page_fifo5.Add(s[i].ToString());
                        MainWindow.page_lru4.Add(int.Parse(s[i].ToString()));
                        MainWindow.page_lru5.Add(s[i].ToString());
                    }
                }
                MainWindow.page_fifo5.Add("");
                MainWindow.page_lru5.Add("");
            }
            //if (MainWindow.row_page.Count() != 0 && MainWindow.page_fifo4.Count() != 0 && MainWindow.page_lru4.Count() != 0)
            //{
            //    MessageBox.Show("Сохранено");
            //    Keyboard_window.Close();
            //}
            if (!error)
            {
                MessageBox.Show("Сохранено");
                Close();
            }
        }
    }
}
