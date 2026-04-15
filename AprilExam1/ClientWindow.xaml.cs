using AprilExam1.Models;
using Microsoft.EntityFrameworkCore;
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
    /// Логика взаимодействия для ClientWindow.xaml
    /// </summary>
    public partial class ClientWindow : Window
    {
        public ClientWindow()
        {
            InitializeComponent();
            LoadProducts();
        }

        private void LoadProducts()
        {
            using (var context = new ExamContext())
            {
                var products = context.Products.Include(p => p.Category)
                    .Include(p => p.Manufacture)
                    .Include(p => p.Supplire)
                    .Include(p => p.Images)
                    .Include(p => p.Storages).ToList();
                ProductsListBox.ItemsSource = products;
            }
            
        }
    }
}
