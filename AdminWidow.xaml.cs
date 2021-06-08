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
        public TRPO_KURSEntities db = new TRPO_KURSEntities();

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
                ("SELECT Id AS '№', Year AS Год, Month AS Месяц, Client_Id AS '№ Клиента', Resource_Id AS '№ Ресурса', Status AS Статус, Payment AS Сумма FROM Bills WHERE IsDeleted = 0");
            dataTable = WorkWithQuery(query);
            BillsDG.ItemsSource = dataTable.DefaultView;


            query = "SELECT Id AS '№', Client_Id AS '№ Клиента', CONCAT(DAY(Date), '.', MONTH(Date), '.', YEAR(Date)) AS Дата, RequestType_Id AS '№ Типа заявки', Description AS Описание, Worker_Id AS '№ Работника', Status_Id AS '№ Статуса' FROM Requests WHERE IsDeleted = 0";
            dataTable = WorkWithQuery(query);
            RequestsDG.ItemsSource = dataTable.DefaultView;

            query = "SELECT Id AS '№', Name AS Наименование, PointX AS 'Координата Х', PointY AS 'Координата Y' FROM Addresses WHERE IsDeleted = 0";
            dataTable = WorkWithQuery(query);
            AddressesDG.ItemsSource = dataTable.DefaultView;

            query = "SELECT Id AS '№', Surname AS Фамилия, Name AS Имя, Lastname AS Отчество, Address_Id AS '№ Адреса', Apartment_Number AS Квартира FROM Clients WHERE IsDeleted = 0";
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
                    "WHERE Users.Id = @Id AND IsDeleted = 0" +
                    "SET @Id = @Id + 1 " +
                    "SET @Pass = ''  " +
                    "END " +
                    "SELECT Номер_пользователя AS '№', Логин, Пароль, Роль AS '№ Роли', Фамилия, Имя, Отчество FROM #Vrem " +
                    "DROP TABLE #Vrem";
            dataTable = WorkWithQuery(query);
            UsersDG.ItemsSource = dataTable.DefaultView;

            query = "SELECT Id AS '№', Surname AS Фамилия, Name AS Имя, Lastname AS Отчество, Specialty_Id AS '№ Специальности' FROM Workers WHERE IsDeleted = 0";
            dataTable = WorkWithQuery(query);
            WorkersDG.ItemsSource = dataTable.DefaultView;

            query = "SELECT Id AS '№', Name AS Наименование FROM Specialties WHERE IsDeleted = 0";
            dataTable = WorkWithQuery(query);
            SpecialtiesDG.ItemsSource = dataTable.DefaultView;
             
            query = "SELECT Id AS '№', Name AS Наименование FROM Statuses WHERE IsDeleted = 0";
            dataTable = WorkWithQuery(query);
            StatusesDG.ItemsSource = dataTable.DefaultView;

            query = "SELECT Id AS '№', Name AS Наименование FROM RequestTypes WHERE IsDeleted = 0";
            dataTable = WorkWithQuery(query);
            TypesDG.ItemsSource = dataTable.DefaultView;

            query = "SELECT Id AS '№', Name AS Наименование FROM Resources WHERE IsDeleted = 0";
            dataTable = WorkWithQuery(query);
            ResourcesDG.ItemsSource = dataTable.DefaultView;

            query = "SELECT Id AS '№', Name AS Наименование FROM Roles WHERE IsDeleted = 0";
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
                RequestId.Text = rowView[0].ToString();
            }
        }

        private void BillsDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView rowView = BillsDG.SelectedItem as DataRowView;
            if (rowView != null)
            {
                BillsId.Text = rowView[0].ToString();
            }
        }

        private void ClientsDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView rowView = ClientsDG.SelectedItem as DataRowView;
            if (rowView != null)
            {
                ClientsId.Text = rowView[0].ToString();
            }
        }

        private void WorkersDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView rowView = WorkersDG.SelectedItem as DataRowView;
            if (rowView != null)
            {
                WorkersId.Text = rowView[0].ToString();
            }
        }

        private void UsersDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView rowView = UsersDG.SelectedItem as DataRowView;
            if (rowView != null)
            {
                UsersId.Text = rowView[0].ToString();
            }
        }

        private void SpecialtiesDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView rowView = SpecialtiesDG.SelectedItem as DataRowView;
            if (rowView != null)
            {
                SpecialtiesId.Text = rowView[0].ToString();
            }
        }

        private void RolesDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView rowView = RolesDG.SelectedItem as DataRowView;
            if (rowView != null)
            {
                RolesId.Text = rowView[0].ToString();
            }
        }

        private void AddressesDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView rowView = AddressesDG.SelectedItem as DataRowView;
            if (rowView != null)
            {
                AddressesId.Text = rowView[0].ToString();
            }
        }

        private void ResourcesDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView rowView = ResourcesDG.SelectedItem as DataRowView;
            if (rowView != null)
            {
                ResourcesId.Text = rowView[0].ToString();
            }
        }

        private void TypesDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView rowView = TypesDG.SelectedItem as DataRowView;
            if (rowView != null)
            {
                TypesId.Text = rowView[0].ToString();
            }
        }

        private void StatusesDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView rowView = StatusesDG.SelectedItem as DataRowView;
            if (rowView != null)
            {
                StatusesId.Text = rowView[0].ToString();
            }
        }

        private void RequestId_TextChanged(object sender, TextChangedEventArgs e)
        {
            int i = int.Parse(RequestId.Text);
            var row = db.Requests.Where(w => w.Id == i).FirstOrDefault();
            RequestClientId.Text = row.Client_Id.ToString();
            RequestDate.SelectedDate = row.Date;
            RequestTypeId.Text = row.RequestType_Id.ToString();
            RequestDescrip.Text = row.Description;
            RequestWorkerId.Text = row.Worker_Id.ToString();
            RequestStatusId.Text = row.Status_Id.ToString();
        }

        private void BillsId_TextChanged(object sender, TextChangedEventArgs e)
        {
            int i = int.Parse(BillsId.Text);
            var row = db.Bills.Where(w => w.Id == i).FirstOrDefault();
            BillsYear.Text = row.Year.ToString();
            BillsMonth.Text = row.Month.ToString();
            BillsClientId.Text = row.Client_Id.ToString();
            BillsResourceId.Text = row.Resource_Id.ToString();
            BillsStatus.IsChecked = row.Status;
            BillsPayment.Text = row.Payment.ToString();
        }

        private void ClientsId_TextChanged(object sender, TextChangedEventArgs e)
        {
            int i = int.Parse(ClientsId.Text);
            var row = db.Clients.Where(w => w.Id == i).FirstOrDefault();
            ClientsSurname.Text = row.Surname;
            ClientsName.Text = row.Name;
            ClientsLastname.Text = row.Lastname;
            ClientsAddress.Text = row.Address_Id.ToString();
            ClientsApartment.Text = row.Apartment_Number.ToString();            
        }

        private void WorkersId_TextChanged(object sender, TextChangedEventArgs e)
        {
            int i = int.Parse(WorkersId.Text);
            var row = db.Workers.Where(w => w.Id == i).FirstOrDefault();
            WorkersSurname.Text = row.Surname;
            WorkersName.Text = row.Name;
            WorkersLastname.Text = row.Lastname;
            WorkersSpecialtyId.Text = row.Specialty_Id.ToString();
        }

        private void UsersId_TextChanged(object sender, TextChangedEventArgs e)
        {
            int i = int.Parse(UsersId.Text);
            var row = db.Users.Where(w => w.Id == i).FirstOrDefault();
            UsersSurname.Text = row.Surname;
            UsersName.Text = row.Name;
            UsersLastname.Text = row.Lastname;
            UsersLogin.Text = row.Login;
            UsersPassword.Password = row.Password;
            UsersRoleId.Text = row.Role_Id.ToString();
        }

        private void SpecialtiesId_TextChanged(object sender, TextChangedEventArgs e)
        {
            int i = int.Parse(SpecialtiesId.Text);
            var row = db.Specialties.Where(w => w.Id == i).FirstOrDefault();
            SpecialtiesName.Text = row.Name;
        }

        private void RolesId_TextChanged(object sender, TextChangedEventArgs e)
        {
            int i = int.Parse(RolesId.Text);
            var row = db.Roles.Where(w => w.Id == i).FirstOrDefault();
            RolesName.Text = row.Name;
        }

        private void AddressesId_TextChanged(object sender, TextChangedEventArgs e)
        {
            int i = int.Parse(AddressesId.Text);
            var row = db.Addresses.Where(w => w.Id == i).FirstOrDefault();
            AddressesName.Text = row.Name;
            AddressesX.Text = row.PointX.ToString();
            AddressesY.Text = row.PointY.ToString();
        }

        private void ResourcesId_TextChanged(object sender, TextChangedEventArgs e)
        {
            int i = int.Parse(ResourcesId.Text);
            var row = db.Resources.Where(w => w.Id == i).FirstOrDefault();
            ResourcesId.Text = row.Name;
        }

        private void TypesId_TextChanged(object sender, TextChangedEventArgs e)
        {
            int i = int.Parse(TypesId.Text);
            var row = db.RequestTypes.Where(w => w.Id == i).FirstOrDefault();
            TypesId.Text = row.Name;
        }

        private void StatusesId_TextChanged(object sender, TextChangedEventArgs e)
        {
            int i = int.Parse(StatusesId.Text);
            var row = db.Statuses.Where(w => w.Id == i).FirstOrDefault();
            StatusesId.Text = row.Name;
        }
    }
}
