using Kingsman20.ClassHelper;
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
    /// Логика взаимодействия для CartWindow.xaml
    /// </summary>
    public partial class CartWindow : Window
    {
        public CartWindow()
        {
            InitializeComponent();
            SetListServise();
        }

        private void SetListServise()
        {
            LvCartService.ItemsSource = ClassHelper.CartServiceClass.ServiceCart;

        }

        private void BtnRomoveToCart_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button == null)
            {
                return;
            }
            var service = button.DataContext as DataBase.Service; // получаем выбранную запись

            ClassHelper.CartServiceClass.ServiceCart.Remove(service);

            SetListServise();
        }
        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            ServiceWindow serviceWindow = new ServiceWindow();
            serviceWindow.Show();
            this.Close();
        }

        private void BtnPay_Click(object sender, RoutedEventArgs e)
        {
            DataBase.Order order = new DataBase.Order();

            order.IdClient = 1;
            order.IdEmployee = 1; //UserDataClass.Employee.IDEmployee;
            order.StartTime = DateTime.Now;
            order.EndDate = DateTime.Now;

            EF.Context.Order.Add(order);

            EF.Context.SaveChanges();

            foreach (var item in ClassHelper.CartServiceClass.ServiceCart)
            {
                DataBase.OrderService orderService = new DataBase.OrderService();
                orderService.IdOrder = 14;
                orderService.IdService = item.IDService;
                orderService.Quantity = 1;

                EF.Context.OrderService.Add(orderService);
                EF.Context.SaveChanges();
            }
            EF.Context.SaveChanges();
            // переход на главную

            MessageBox.Show("Зaказ оформлен");

            ClassHelper.CartServiceClass.ServiceCart.Clear();

            ServiceWindow serviceWindow = new ServiceWindow();
            serviceWindow.Show();
            this.Close();

        }
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button == null)
            {
                return;
            }
            var service = button.DataContext as DataBase.Service;

            if (service.Count > 1)
            {
                service.Count--;
            }

            SetListServise();
        }

        private void BtnDelet_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button == null)
            {
                return;
            }
            var service = button.DataContext as DataBase.Service;

            if (service.Count < 10)
            {
                service.Count++;
            }

            SetListServise();
        }
    }
}
