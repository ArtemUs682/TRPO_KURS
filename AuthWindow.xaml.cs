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

namespace Kurs
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public TRPO_KURSEntities db = new TRPO_KURSEntities();
        public AuthWindow()
        {
            InitializeComponent();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void SignIn_Click(object sender, RoutedEventArgs e)
        {
            if (db.Users.Select(w => w.Login + " " + w.Password).Contains(LoginBox.Text + " " + PasswordBox.Password))
            {
                var row = db.Users.Where(w => w.Login == LoginBox.Text).FirstOrDefault();
                if (row.Role_Id == 2)
                {
                    RequestsWindow.GetUserId(row.Id);
                    Main main = new Main();
                    main.Show();
                }
                if(row.Role_Id == 1)
                {
                    AdminWidow.GetUserId(row.Id);
                    AdminWidow window = new AdminWidow();
                    window.Show();
                }    
                
            }
            else
            {
                MessageBox.Show("Ошибка авторизации");
            }
            
        }

        private void Turn_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
