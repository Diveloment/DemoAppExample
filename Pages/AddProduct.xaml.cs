using DemoApp2.Entities;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DemoApp2.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddProduct.xaml
    /// </summary>
    public partial class AddProduct : Page
    {
        public Entities.Products _currentProduct = null;
        public byte[] _imgData = File.ReadAllBytes(@"C:\Users\Admin\source\repos\DemoApp2\Imgs\picture.png");

        public AddProduct()
        {
            InitializeComponent();

            comboDim.ItemsSource = new List<string>() { "уп.", "шт." };
            comboManuf.ItemsSource = App.Context.Manufacturers.ToList();
            comboProv.ItemsSource = App.Context.Providers.ToList();
            comboType.ItemsSource = App.Context.ProductTypes.ToList();
        }

        public AddProduct(Entities.Products product)
        {
            InitializeComponent();

            _currentProduct = product;
            _imgData = _currentProduct.Product_image;
            textArticle.Text = _currentProduct.Product_article;
            textName.Text = _currentProduct.Product_name;

            comboDim.ItemsSource = new List<string>() { "уп.", "шт." };
            comboDim.SelectedItem = _currentProduct.Product_dimension;

            comboManuf.ItemsSource = App.Context.Manufacturers.ToList();
            comboManuf.SelectedItem = _currentProduct.Manufacturers;

            comboProv.ItemsSource = App.Context.Providers.ToList();
            comboProv.SelectedItem = _currentProduct.Providers;

            comboType.ItemsSource = App.Context.ProductTypes.ToList();
            comboType.SelectedItem = _currentProduct.ProductTypes;

            textMaxSale.Text = _currentProduct.Product_maxDiscount.ToString();
            textSale.Text = _currentProduct.Product_discount.ToString();
            textCost.Text = _currentProduct.Product_cost.ToString();
            textStock.Text = _currentProduct.Product_stock.ToString();
            textDescription.Text = _currentProduct.Product_description.ToString();

            pageImg.Source = (ImageSource)new ImageSourceConverter()
                    .ConvertFrom(_imgData);
        }

        private void submit(object sender, RoutedEventArgs e)
        {
            try
            {
                var product = new Entities.Products
                {
                    Manufacturers = comboManuf.SelectedItem as Entities.Manufacturers,
                    Product_dimension = comboDim.SelectedItem.ToString(),
                    Providers = comboProv.SelectedItem as Entities.Providers,
                    ProductTypes = comboType.SelectedItem as Entities.ProductTypes,
                    Product_article = textArticle.Text,
                    Product_name = textName.Text,
                    Product_maxDiscount = float.Parse(textMaxSale.Text),
                    Product_discount = float.Parse(textSale.Text),
                    Product_cost = float.Parse(textCost.Text),
                    Product_stock = Convert.ToInt32(textStock.Text),
                    Product_description = textDescription.Text,
                    Product_image = _imgData,
                    Product_manufacturer = (comboManuf.SelectedItem as Entities.Manufacturers).Manufacturer_id,
                    Product_provider = (comboProv.SelectedItem as Entities.Providers).Provider_id,
                    Product_type = (comboType.SelectedItem as Entities.ProductTypes).ProductType_id,
                    Product_id = 0,
                };
                if (_currentProduct != null)
                {
                    _currentProduct.Product_dimension = comboDim.SelectedItem.ToString();
                    _currentProduct.Product_article = textArticle.Text;
                    _currentProduct.Product_name = textName.Text;
                    _currentProduct.Product_maxDiscount = float.Parse(textMaxSale.Text);
                    _currentProduct.Product_discount = float.Parse(textSale.Text);
                    _currentProduct.Product_cost = float.Parse(textCost.Text);
                    _currentProduct.Product_stock = Convert.ToInt32(textStock.Text);
                    _currentProduct.Product_description = textDescription.Text;
                    _currentProduct.Product_image = _imgData;
                    _currentProduct.Product_manufacturer = (comboManuf.SelectedItem as Entities.Manufacturers).Manufacturer_id;
                    _currentProduct.Product_provider = (comboProv.SelectedItem as Entities.Providers).Provider_id;
                    _currentProduct.Product_type = (comboType.SelectedItem as Entities.ProductTypes).ProductType_id;
                    App.Context.SaveChanges();
                }
                else
                {
                    App.Context.Products.Add(product);
                    App.Context.SaveChanges();
                }
                NavigationService.Navigate(new Pages.ProductView());
            }
            catch
            {
                MessageBox.Show("Поля заполнены неверно!", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void loadImg(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image |*.png; *jpg"; 
            if (dialog.ShowDialog() == true)
            {
                _imgData = File.ReadAllBytes(dialog.FileName);
                pageImg.Source = (ImageSource)new ImageSourceConverter()
                    .ConvertFrom(_imgData);
            }
        }
    }
}
