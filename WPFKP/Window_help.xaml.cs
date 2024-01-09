using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для Window_help.xaml
    /// </summary>
    public partial class Window_help : Window
    {
        public Window_help()
        {
            InitializeComponent();
        }
        public void Winloaded(object sender, System.EventArgs e)
        {
            spravka.Height = 430;
            spravka.Width = 550;
            txtblck_about.Width = 470;
            txtblck_about.Height = 316;
        }

        public void Window_stateChanged(object sender, EventArgs e)
        {
            switch (this.WindowState)
            {
                case WindowState.Maximized:
                    {
                        txtblck_about.Width = txtblck_about.Width + 100;
                        txtblck_about.Height = txtblck_about.Height + 150;
                        TabControl.Width = spravka.Width+300;
                        TabControl.Height = spravka.Height+200;
                        break;
                    }
                case WindowState.Normal:
                    {
                        TabControl.Width = 480;
                        TabControl.Height = 364;
                        txtblck_about.Width = txtblck_about.Width - 100;
                        txtblck_about.Height = txtblck_about.Height - 150;
                        break;
                    }

            }
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
