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
using System.Data.SqlClient;
using System.Data;

namespace Kurs
{
    /// <summary>
    /// Логика взаимодействия для ReceiptsWindow.xaml
    /// </summary>
    public partial class ReceiptsWindow : Window
    {
        SqlConnection con = new SqlConnection("Data Source=mssql;Initial Catalog=gr682_uat;Integrated Security=True");
        public ReceiptsWindow()
        {
            InitializeComponent();
            Vivod(" ");
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Vivod (string extra)
        {
            con.Open();
            string query =
                ("SELECT Bills.Id AS 'Номер квитанции', " +
                "CASE " +
                "WHEN Month = 1 THEN CONCAT('Январь ', Year)" +
                "WHEN Month = 2 THEN CONCAT('Февраль ', Year) " +
                "WHEN Month = 3 THEN CONCAT('Март ', Year) " +
                "WHEN Month = 4 THEN CONCAT('Апрель ', Year) " +
                "WHEN Month = 5 THEN CONCAT('Май ', Year) " +
                "WHEN Month = 6 THEN CONCAT('Июнь ', Year) " +
                "WHEN Month = 7 THEN CONCAT('Июль ', Year) " +
                "WHEN Month = 8 THEN CONCAT('Август ', Year) " +
                "WHEN Month = 9 THEN CONCAT('Сентябрь ', Year) " +
                "WHEN Month = 10 THEN CONCAT('Октябрь ', Year) " +
                "WHEN Month = 11 THEN CONCAT('Ноябрь ', Year) " +
                "WHEN Month = 12 THEN CONCAT('Декабрь ', Year) " +
                "END 'Период', " +
                "Clients.Surname + ' ' + Clients.Name + ' ' + Clients.Lastname AS Клиент, " +
                "Resources.Name AS Ресурс, " +
                "CASE " +
                "WHEN Status = 1 THEN 'Оплачено' " +
                "WHEN Status = 0 THEN 'Не оплачено' " +
                "END 'Статус', " +
                "Payment AS Плата " +
                "FROM Bills " +
                "INNER JOIN Clients ON Client_Id = Clients.Id " +
                "INNER JOIN Resources ON Resource_Id = Resources.Id " + 
                "WHERE Bills.IsDeleted = 0 ") +
                extra;

            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            DG.ItemsSource = dataTable.DefaultView;
            adapter.Update(dataTable);
            con.Close();
        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            if (SearchBox.Text.Contains("DELETE") || SearchBox.Text.Contains(";"))
            {
                MessageBox.Show("Полe содержит недопустимые значения");
            }
            else
            {
                string query = "AND CONCAT(Clients.Surname, ' ', Clients.Name, ' ', Clients.Lastname) Like '%" + SearchBox.Text + "%'";
                Vivod(query);
            }
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void TurnBtn_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
    }
}
