using Kingsman20.ClassHelper;
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
            EF.context.Order.Add(new DataBase.Order
            {
                IdClient = 1,
                IdEmployee = UserDataClass.Employee.IDEmployee,
                StartTime = DateTime.Now,
                EndDate = DateTime.Now,
            }
            );

            foreach (var item in ClassHelper.CartServiceClass.ServiceCart)
            {
                DataBase.OrderService orderService = new DataBase.OrderService();
                orderService.IdOrder = 1;
                orderService.IdService = item.IDService;
                orderService.Quantity = 1;

                EF.context.OrderService.Add(orderService);

            }




            EF.context.SaveChanges();
            // переход на главную

            this.Close();
        }
    }
}
