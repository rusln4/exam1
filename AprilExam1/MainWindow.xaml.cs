using System.Text;
using System.Linq;
using AprilExam1.Models;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AprilExam1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            string email = EmailTextBox.Text;
            string password = PasswordTextBox.Text;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Заполните все поля!");
                return;
            }
            using (var contex = new ExamContext())
            {
                var user = contex.Users.FirstOrDefault(u => u.Mail == email && u.Password ==  password);
                if (user != null)
                {
                    MessageBox.Show($"Авторизация успешна ({user.Role})");
                    if (user.Role == "Клиент")
                    {
                        ClientWindow wind = new ClientWindow();
                        wind.Show();
                        this.Close();
                    }
                    else if (user.Role == "Менеджер")
                    {

                    }
                    else if (user.Role == "Администратор")
                    {
                        AdminWindow admin = new AdminWindow();
                        admin.Show();
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Пользовыатель не найден");
                }
            }
        }
    }
}