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
    /// Логика взаимодействия для TechsWindow.xaml
    /// </summary>
    public partial class TechsWindow : Window
    {
        SqlConnection con = new SqlConnection("Data Source=mssql;Initial Catalog=gr682_uat;Integrated Security=True");
        public TechsWindow()
        {
            InitializeComponent();
            string query;
            DataTable dataTable = new DataTable();
            query =
                ("SELECT Bills.Id AS '№', " +
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
                "WHERE Bills.IsDeleted = 0");
            dataTable = WorkWithQuery(query);
            BillsDataGrid.ItemsSource = dataTable.DefaultView;


            query = "SELECT Requests.Id AS '№', Clients.Surname + ' ' + Clients.Name + ' ' + Clients.Lastname AS Клиент, CONCAT(DAY(Date), '.', MONTH(Date), '.', YEAR(Date)) AS Дата, RequestTypes.Name AS 'Тип заявки', Description AS Описание, Workers.Surname + ' ' + Workers.Name + ' ' + Workers.Lastname AS 'Назначенный работник', Statuses.Name AS Статус FROM Requests " +
                    "INNER JOIN Clients ON Client_Id = Clients.Id " +
                    "INNER JOIN RequestTypes ON RequestType_Id = RequestTypes.Id " +
                    "INNER JOIN Workers ON Worker_Id = Workers.Id " +
                    "INNER JOIN Statuses ON Status_Id = Statuses.Id " +
                    "INNER JOIN Users ON User_Id = Users.Id " +
                    "WHERE Requests.IsDeleted = 0";
            dataTable = WorkWithQuery(query);
            RequestDataGrid.ItemsSource = dataTable.DefaultView;

            query = "SELECT Id AS '№', Name AS Наименование, CONCAT(PointX, ', ', PointY) AS Координаты FROM Addresses WHERE Addresses.IsDeleted = 0";
            dataTable = WorkWithQuery(query);
            AddressesDataGrid.ItemsSource = dataTable.DefaultView;

            query = "SELECT Clients.Id AS '№', CONCAT(Surname, ' ', Clients.Name, ' ', Lastname) AS ФИО, CONCAT(Addresses.Name, '  кв. №', Apartment_Number) AS Адрес FROM Clients INNER JOIN Addresses on Address_Id = Addresses.Id WHERE Clients.IsDeleted = 0";
            dataTable = WorkWithQuery(query);
            ClinetsDataGrid.ItemsSource = dataTable.DefaultView;

            query = "CREATE TABLE #Vrem " +
                    "( " +
                    "Номер_пользователя INT, " +
                    "Логин NVARCHAR(100), " +
                    "Пароль NVARCHAR(100), " +
                    "Роль NVARCHAR(100), " +
                    "ФИО NVARCHAR(300) " +
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
                    "INSERT INTO #Vrem SELECT Users.Id , Login, @Pass, Roles.Name, CONCAT(Surname, ' ', Users.Name, ' ', Lastname)  " +
                    "FROM Users " +
                    "INNER JOIN Roles ON Role_Id = Roles.Id " +
                    "WHERE Users.Id = @Id AND Users.IsDeleted = 0" +
                    "SET @Id = @Id + 1 " +
                    "SET @Pass = ''  " +
                    "END " +
                    "SELECT Номер_пользователя AS '№', ФИО, Логин, Пароль, Роль FROM #Vrem " +
                    "DROP TABLE #Vrem";
            dataTable = WorkWithQuery(query);
            UsersDataGrid.ItemsSource = dataTable.DefaultView;

            query = "SELECT Workers.Id AS '№', CONCAT(Surname, ' ', Workers.Name, ' ', Lastname) AS ФИО, Specialties.Name AS Специальность FROM Workers " +
                    "INNER JOIN Specialties ON Specialty_Id = Specialties.Id WHERE Workers.IsDeleted = 0";
            dataTable = WorkWithQuery(query);
            WorkersDataGrid.ItemsSource = dataTable.DefaultView;

            query = "SELECT Id AS '№', Name AS Наименование FROM Specialties WHERE Specialties.IsDeleted = 0";
            dataTable = WorkWithQuery(query);
            SpecialtiesDataGrid.ItemsSource = dataTable.DefaultView;

            query = "SELECT Id AS '№', Name AS Наименование FROM Statuses WHERE Statuses.IsDeleted = 0";
            dataTable = WorkWithQuery(query);
            StatusesDataGrid.ItemsSource = dataTable.DefaultView;

            query = "SELECT Id AS '№', Name AS Наименование FROM RequestTypes WHERE RequestTypes.IsDeleted = 0";
            dataTable = WorkWithQuery(query);
            TypesDataGrid.ItemsSource = dataTable.DefaultView;

            query = "SELECT Id AS '№', Name AS Наименование FROM Resources WHERE Resources.IsDeleted = 0";
            dataTable = WorkWithQuery(query);
            ResourcesDataGrid.ItemsSource = dataTable.DefaultView;

            query = "SELECT Id AS '№', Name AS Наименование FROM Roles WHERE Roles.IsDeleted = 0";
            dataTable = WorkWithQuery(query);
            RolesDataGrid.ItemsSource = dataTable.DefaultView;
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

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
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
