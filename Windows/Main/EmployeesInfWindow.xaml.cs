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
    /// Логика взаимодействия для EmployeesInfWindow.xaml
    /// </summary>
    public partial class EmployeesInfWindow : Window
    {
        public EmployeesInfWindow()
        {
            InitializeComponent();
            GetListService();
        }
        private void GetListService()
        {
            LvClient.ItemsSource = ClassHelper.EF.context.Employee.ToList();
        }
        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
