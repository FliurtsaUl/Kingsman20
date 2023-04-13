using Kingsman20.DataBase;
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

namespace Kingsman20.Windows
{
    /// <summary>
    /// Логика взаимодействия для ClientInfWindow.xaml
    /// </summary>
    public partial class ClientInfWindow : Window
    {
        public ClientInfWindow()
        {
            InitializeComponent();
            GetListService();
        }
        private void GetListService()
        {
            LvClient.ItemsSource = ClassHelper.EF.context.Client.ToList();
        }
        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
