using AprilExam1.Models;
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

namespace AprilExam1
{
    /// <summary>
    /// Логика взаимодействия для NewProductWindow.xaml
    /// </summary>
    public partial class NewProductWindow : Window
    {
        public NewProductWindow()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            using(var contex = new ExamContext())
            {
                CategoryComboBox.ItemsSource = contex.Categories.ToList();
                ManufactureComboBox.ItemsSource = contex.Manufactures.ToList();
                SuplierComboBox.ItemsSource= contex.Suppliers.ToList();
            }
        }

        private void AddNewProductButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using(var context = new ExamContext())
                {
                    var product = new Product
                    {
                        Name = NameTextBox.Text,
                        Description = DescTextBox.Text,
                        Price = double.Parse(PriceTextBox.Text),
                        Discount = int.Parse(DiscountTextBox.Text),
                        CategoryId = (int)CategoryComboBox.SelectedValue,
                        ManufactureId = (int)ManufactureComboBox.SelectedValue,
                        SupplireId = (int)SuplierComboBox.SelectedValue
                    };
                    context.Products.Add(product);
                    context.SaveChanges();
                    MessageBox.Show("Товар добавлен");
                    AdminWindow ad = new AdminWindow();
                    ad.Show();
                    this.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
