using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using fifolru_algo_lib;


namespace WPFKP
{

    /// Логика взаимодействия для MainWindow.xaml

    public partial class MainWindow : Window, Service_pra.IService_praCallback
    {

        Service_pra.Service_praClient client;
        public static List<int> row_page = new List<int>();
        public static List<int> page_fifo4 = new List<int>();
        public static List<string> page_fifo5 = new List<string>();
        public static List<int> page_lru4 = new List<int>();
        public static List<string> page_lru5 = new List<string>();

        public MainWindow()
        {
            InitializeComponent();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            

        }

                



        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbSelect.SelectedIndex == 0)
            {
                Winfile winfile = new Winfile();
                winfile.Show();
                cmbSelect.SelectedIndex = -1;
                cmbSelect.Text = "Ввод";
                client = new Service_pra.Service_praClient(new System.ServiceModel.InstanceContext(this));

            }
            else if (cmbSelect.SelectedIndex == 1)
            {
                Winkeyboard winkeyb = new Winkeyboard();
                winkeyb.Show();
                cmbSelect.SelectedIndex = -1;
                cmbSelect.Text = "Ввод";
                client = new Service_pra.Service_praClient(new System.ServiceModel.InstanceContext(this));


            }

        }

        private void cmbResult_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            /***********************************************************/
            string result_fifo4 = "";
            string result_lru4 = "";
            string result_fifo5 = "";
            string result_lru5 = "";

            List<string> res_fifo4 = new List<string>();
            //res_fifo4 = fifo4(row_pg, page_ff4, 1);

            //res_fifo4 = fifolru_algo_lib.Class1.fifo4(row_page, page_fifo4, 1);

            List<string> res_fifo5 = new List<string>();
            //res_fifo5 = fifo5(row_pg, page_ff5, 1);
           // res_fifo5 = fifolru_algo_lib.Class1.fifo5(row_page, page_fifo5, 1);

            List<string> res_lru4 = new List<string>();
            //res_lru4 = lru4(row_pg, page_l4, 1);
            //res_lru4 = fifolru_algo_lib.Class1.lru4(row_page, page_lru4, 1);


            List<string> res_lru5 = new List<string>();
            //res_lru5 = lru5(row_pg, page_l5, 1);

            //res_lru5 = fifolru_algo_lib.Class1.lru5(row_page, page_lru5, 1);

            if (cmbResult.SelectedIndex == 0)
            {
                if (row_page.Count() == 0 || page_fifo4.Count() == 0 || page_fifo5.Count() == 0 || page_lru4.Count() == 0 || page_lru5.Count() == 0)
                {
                    MessageBox.Show("Сначала введите данные");
                }
                else
                {
                    int[] row_pg = new int[row_page.Count()];
                    for (int i = 0; i < row_page.Count(); i++)
                    {
                        row_pg[i] = row_page[i];
                    }
                    int[] pg_ff4 = new int[page_fifo4.Count()];
                    for (int i = 0; i < page_fifo4.Count(); i++)
                    {
                        pg_ff4[i] = page_fifo4[i];
                    }
                    string[] pg_ff5 = new string[page_fifo5.Count()];
                    for (int i = 0; i < page_fifo5.Count(); i++)
                    {
                        pg_ff5[i] = page_fifo5[i];
                    }
                    int[] pg_l4 = new int[page_lru4.Count()];
                    for (int i = 0; i < page_lru4.Count(); i++)
                    {
                        pg_l4[i] = page_lru4[i];
                    }
                    string[] pg_l5 = new string[page_lru5.Count()];
                    for (int i = 0; i < page_lru5.Count(); i++)
                    {
                        pg_l5[i] = page_lru5[i];
                    }
                    if (client != null)
                    {
                        try
                        {
                            client.algorithm_fifo4(row_pg, pg_ff4, pg_ff5, pg_l4, pg_l5);
                        }
                        catch (CommunicationObjectFaultedException)
                        {
                            MessageBox.Show("Не удалось подключиться к серверу. \nВозможно не запущен хост. Попробуйте еще раз.");
                        }
                        catch (EndpointNotFoundException)
                        {
                            MessageBox.Show("Не удалось подключиться к серверу. \nВозможно не запущен хост. Попробуйте еще раз.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Не удалось подключиться к серверу. \nВозможно не запущен хост. Попробуйте еще раз.");
                    }
                }
            }

            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window_help winhelp = new Window_help();
            winhelp.Show();
        }



        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            client = null;
        }

        public void fifo4_callback(string[] result_fifo4, string[] result_fifo5, string[] result_lru4, string[] result_lru5)
        {
            string res_fifo4 = "";
            string res_lru4 = "";
            string res_fifo5 = "";
            string res_lru5 = "";

            for (int i = 0; i < result_fifo4.Length; i++)
            {
                res_fifo4 += result_fifo4[i];
                res_fifo4 += "\n";
            }
            f4.Text = res_fifo4;

            for (int i = 0; i < result_fifo5.Length; i++)
            {
                res_fifo5 += result_fifo5[i];
                res_fifo5 += "\n";
            }
            f5.Text = res_fifo5;

            for (int i = 0; i < result_lru4.Length; i++)
            {
                res_lru4 += result_lru4[i];
                res_lru4 += "\n";
            }
            l4.Text = res_lru4;

            for (int i = 0; i < result_lru5.Length; i++)
            {
                res_lru5 += result_lru5[i];
                res_lru5 += "\n";
            }
            l5.Text = res_lru5;
            client = null;
        }
    }
}
