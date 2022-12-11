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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DemoApp2.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProductView.xaml
    /// </summary>
    public partial class ProductView : Page
    {
        public ProductView()
        {
            InitializeComponent();
            listView.ItemsSource = App.Context.Products.ToList();
        }

        private void UpdateList()
        {
            listView.ItemsSource = App.Context.Products.ToList();
        }

        private void editBtnclk(object sender, RoutedEventArgs e)
        {
            if (App.CheckRights(2) || App.CheckRights(3))
            {
                MessageBox.Show("У ва нет прав!");
                return;
            }
            var currentProduct = (sender as Button).DataContext as Entities.Products;
            NavigationService.Navigate(new Pages.AddProduct(currentProduct));
        }

        private void deleteBtnclk(object sender, RoutedEventArgs e)
        {
            if (App.CheckRights(2) || App.CheckRights(3))
            {
                MessageBox.Show("У ва нет прав!");
                return;
            }
            var product = (sender as Button).DataContext as Entities.Products;

            if (MessageBox.Show("Вы хотите удалить " + product.Product_name, 
                "Warning", MessageBoxButton.YesNo, 
                MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                App.Context.Products.Remove(product);
                App.Context.SaveChanges();
                UpdateList();
            }
        }

        private void UpdateView(object sender, RoutedEventArgs e)
        {
            UpdateList();
        }

        private void addProduct(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.AddProduct());
        }
    }
}
