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
    /// Логика взаимодействия для AdminWidow.xaml
    /// </summary>
    public partial class AdminWidow : Window
    {
        public static int UseId = -1;
        SqlConnection con = new SqlConnection("Data Source=ARTEM-ПК\\ArtemPC;Initial Catalog=TRPO_KURS;Integrated Security=True");

        public static void GetUserId(int i)
        {
            UseId = i;
        }
        public AdminWidow()
        {
            InitializeComponent();
            string query;
            DataTable dataTable = new DataTable();
            query =
                ("SELECT Id AS '№', Year AS Год, Month AS Месяц, Client_Id AS '№ Клиента', Resource_Id AS '№ Ресурса', Status AS Статус, Payment AS Сумма FROM Bills");
            dataTable = WorkWithQuery(query);
            BillsDG.ItemsSource = dataTable.DefaultView;


            query = "SELECT Id AS '№', Client_Id AS '№ Клиента', CONCAT(DAY(Date), '.', MONTH(Date), '.', YEAR(Date)) AS Дата, RequestType_Id AS '№ Типа заявки', Description AS Описание, Worker_Id AS '№ Работника', Status_Id AS '№ Статуса' FROM Requests";
            dataTable = WorkWithQuery(query);
            RequestsDG.ItemsSource = dataTable.DefaultView;

            query = "SELECT Id AS '№', Name AS Наименование, PointX AS 'Координата Х', PointY AS 'Координата Y' FROM Addresses";
            dataTable = WorkWithQuery(query);
            AddressesDG.ItemsSource = dataTable.DefaultView;

            query = "SELECT Id AS '№', Surname AS Фамилия, Name AS Имя, Lastname AS Отчество, Address_Id AS '№ Адреса', Apartment_Number AS Квартира FROM Clients";
            dataTable = WorkWithQuery(query);
            ClientsDG.ItemsSource = dataTable.DefaultView;

            query = "CREATE TABLE #Vrem " +
                    "( " +
                    "Номер_пользователя INT, " +
                    "Логин NVARCHAR(100), " +
                    "Пароль NVARCHAR(100), " +
                    "Роль INT, " +
                    "Фамилия NVARCHAR(300), " +
                    "Имя NVARCHAR(300), " +
                    "Отчество NVARCHAR(300) " +
                    ") " +
                    "DECLARE @Id int, @Pass nvarchar(50), @Len int " +
                    "SET @Id = (SELECT MIN(Id) FROM Users) " +
                    "SET @Pass = '•' " +
                    "WHILE @Id <= (SELECT MAX(Id) FROM Users) " +
                    "BEGIN " +
                    "SET @Len = (SELECT LEN(Password) FROM Users WHERE Id = @Id) " +
                    "WHILE LEN(@Pass) < @Len " +
                    "BEGIN " +
                    "SET @Pass = @Pass + '•' " +
                    "END " +
                    "INSERT INTO #Vrem SELECT Users.Id , Login, @Pass, Role_Id, Surname, Name, Lastname  " +
                    "FROM Users " +
                    "WHERE Users.Id = @Id " +
                    "SET @Id = @Id + 1 " +
                    "SET @Pass = ''  " +
                    "END " +
                    "SELECT Номер_пользователя AS '№', Логин, Пароль, Роль AS '№ Роли', Фамилия, Имя, Отчество FROM #Vrem " +
                    "DROP TABLE #Vrem";
            dataTable = WorkWithQuery(query);
            UsersDG.ItemsSource = dataTable.DefaultView;

            query = "SELECT Id AS '№', Surname AS Фамилия, Name AS Имя, Lastname AS Отчество, Specialty_Id AS '№ Специальности' FROM Workers ";
            dataTable = WorkWithQuery(query);
            WorkersDG.ItemsSource = dataTable.DefaultView;

            query = "SELECT Id AS '№', Name AS Наименование FROM Specialties";
            dataTable = WorkWithQuery(query);
            SpecialtiesDG.ItemsSource = dataTable.DefaultView;

            query = "SELECT Id AS '№', Name AS Наименование FROM Statuses";
            dataTable = WorkWithQuery(query);
            StatusesDG.ItemsSource = dataTable.DefaultView;

            query = "SELECT Id AS '№', Name AS Наименование FROM RequestTypes";
            dataTable = WorkWithQuery(query);
            TypesDG.ItemsSource = dataTable.DefaultView;

            query = "SELECT Id AS '№', Name AS Наименование FROM Resources";
            dataTable = WorkWithQuery(query);
            ResourcesDG.ItemsSource = dataTable.DefaultView;

            query = "SELECT Id AS '№', Name AS Наименование FROM Roles";
            dataTable = WorkWithQuery(query);
            RolesDG.ItemsSource = dataTable.DefaultView;
        }

        public DataTable WorkWithQuery(string query)
        {
            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            con.Close();
            return dataTable;
        }

        private void RequestsDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView rowView = RequestsDG.SelectedItem as DataRowView;
            if (rowView != null)
            {
                MessageBox.Show(rowView[0].ToString());
            }
        }
    }
}
