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
        SqlConnection con = new SqlConnection("Data Source=mssql;Initial Catalog=gr682_uat;Integrated Security=True");
        public gr682_uatEntities db = new gr682_uatEntities();

        public static void GetUserId(int i)
        {
            UseId = i;
        }
        public AdminWidow()
        {
            InitializeComponent();
            Vivod();
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

        private void RequestsAddBtn_Click(object sender, RoutedEventArgs e)
        {
            if (RequestId.Text == "" || RequestClientId.Text == "" || RequestDate.SelectedDate == null || RequestTypeId.Text == "" || RequestDescrip.Text == "" || RequestWorkerId.Text == "" || RequestStatusId.Text == "")
            {
                try
                {
                    Requests request = new Requests();
                    request.Id = db.Requests.Max().Id + 1;
                    request.Client_Id = int.Parse(RequestClientId.Text);
                    request.Date = RequestDate.SelectedDate.Value;
                    request.RequestType_Id = int.Parse(RequestTypeId.Text);
                    request.Description = RequestDescrip.Text;
                    request.Worker_Id = int.Parse(RequestWorkerId.Text);
                    request.Status_Id = int.Parse(RequestStatusId.Text);
                    request.IsDeleted = false;
                    db.Requests.Add(request);
                    db.SaveChanges();
                    MessageBox.Show("Данные добавлены");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка" + Environment.NewLine + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Заполнены не все поля!");
            }
            Vivod();
        }

        private void RequestsUpdBtn_Click(object sender, RoutedEventArgs e)
        {
            if (RequestId.Text == "" || RequestClientId.Text == "" || RequestDate.SelectedDate == null || RequestTypeId.Text == "" || RequestDescrip.Text == "" || RequestWorkerId.Text == "" || RequestStatusId.Text == "")
            {
                try
                {
                    int i = int.Parse(RequestId.Text);
                    var request = db.Requests.Where(w => w.Id == i).FirstOrDefault();
                    request.Client_Id = int.Parse(RequestClientId.Text);
                    request.Date = RequestDate.SelectedDate.Value;
                    request.RequestType_Id = int.Parse(RequestTypeId.Text);
                    request.Description = RequestDescrip.Text;
                    request.Worker_Id = int.Parse(RequestWorkerId.Text);
                    request.Status_Id = int.Parse(RequestStatusId.Text);
                    db.SaveChanges();
                    MessageBox.Show("Данные обновлены");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка" + Environment.NewLine + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Заполнены не все поля!");
            }
            Vivod();
        }

        private void RequestsDelBtn_Click(object sender, RoutedEventArgs e)
        {
            if (RequestId.Text == "")
            {
                try
                {
                    int i = int.Parse(RequestId.Text);
                    var request = db.Requests.Where(w => w.Id == i).FirstOrDefault();
                    request.IsDeleted = true;
                    db.SaveChanges();
                    MessageBox.Show("Данные удалены");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка" + Environment.NewLine + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Заполнены не все поля!");
            }
            Vivod();
        }

        private void BillsAddBtn_Click(object sender, RoutedEventArgs e)
        {
            if (BillsId.Text == "" || BillsYear.Text == "" || BillsMonth.Text == "" || BillsResourceId.Text == "" || BillsPayment.Text == "" || BillsClientId.Text == "")
            {
                try
                {
                    Bills bill = new Bills();
                    bill.Id = db.Bills.Max().Id + 1;
                    bill.Year = int.Parse(BillsYear.Text);
                    bill.Month = int.Parse(BillsMonth.Text);
                    bill.Resource_Id = int.Parse(BillsResourceId.Text);
                    bill.Payment = int.Parse(BillsPayment.Text);
                    bill.Client_Id = int.Parse(BillsClientId.Text);
                    bill.IsDeleted = false;
                    db.Bills.Add(bill);
                    db.SaveChanges();
                    MessageBox.Show("Данные добавлены");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка" + Environment.NewLine + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Заполнены не все поля!");
            }
            Vivod();
        }

        private void BillsUpdBtn_Click(object sender, RoutedEventArgs e)
        {
            if (BillsId.Text == "" || BillsYear.Text == "" || BillsMonth.Text == "" || BillsResourceId.Text == "" || BillsPayment.Text == "" || BillsClientId.Text == "")
            {
                try
                {
                    int i = int.Parse(BillsId.Text);
                    var bill = db.Bills.Where(w => w.Id == i).FirstOrDefault();
                    bill.Year = int.Parse(BillsYear.Text);
                    bill.Month = int.Parse(BillsMonth.Text);
                    bill.Resource_Id = int.Parse(BillsResourceId.Text);
                    bill.Payment = int.Parse(BillsPayment.Text);
                    bill.Client_Id = int.Parse(BillsClientId.Text);
                    db.SaveChanges();
                    MessageBox.Show("Данные обновлены");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка" + Environment.NewLine + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Заполнены не все поля!");
            }
            Vivod();
        }

        private void BillsDelBtn_Click(object sender, RoutedEventArgs e)
        {
            if (BillsId.Text == "")
            {
                try
                {
                    int i = int.Parse(BillsId.Text);
                    var bill = db.Bills.Where(w => w.Id == i).FirstOrDefault();
                    bill.IsDeleted = true;
                    db.SaveChanges();
                    MessageBox.Show("Данные удалены");

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка" + Environment.NewLine + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Заполнены не все поля!");
            }
            Vivod();
        }

        private void ClientsAddBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ClientsId.Text == "" || ClientsSurname.Text == "" || ClientsName.Text == "" || ClientsLastname.Text == "" || ClientsAddress.Text == "" || ClientsApartment.Text == "")
            {
                try
                {
                    Clients client = new Clients();
                    client.Id = db.Clients.Max().Id + 1;
                    client.Surname = ClientsSurname.Text;
                    client.Name = ClientsName.Text;
                    client.Lastname = ClientsLastname.Text;
                    client.Address_Id = int.Parse(ClientsAddress.Text);
                    client.Apartment_Number = int.Parse(ClientsApartment.Text);
                    client.IsDeleted = false;
                    db.Clients.Add(client);
                    db.SaveChanges();
                    MessageBox.Show("Данные добавлены");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка" + Environment.NewLine + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Заполнены не все поля!");
            }
            Vivod();
        }

        private void ClientsUpdBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ClientsId.Text == "" || ClientsSurname.Text == "" || ClientsName.Text == "" || ClientsLastname.Text == "" || ClientsAddress.Text == "" || ClientsApartment.Text == "")
            {
                try
                {
                    int i = int.Parse(ClientsId.Text);
                    var client = db.Clients.Where(w => w.Id == i).FirstOrDefault();
                    client.Surname = ClientsSurname.Text;
                    client.Name = ClientsName.Text;
                    client.Lastname = ClientsLastname.Text;
                    client.Address_Id = int.Parse(ClientsAddress.Text);
                    client.Apartment_Number = int.Parse(ClientsApartment.Text);
                    db.SaveChanges();
                    MessageBox.Show("Данные обновлены");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка" + Environment.NewLine + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Заполнены не все поля!");
            }
            Vivod();
        }

        private void ClientsDelBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ClientsId.Text == "")
            {
                try
                {
                    int i = int.Parse(ClientsId.Text);
                    var client = db.Clients.Where(w => w.Id == i).FirstOrDefault();
                    client.IsDeleted = true;
                    db.SaveChanges();
                    MessageBox.Show("Данные удалены");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка" + Environment.NewLine + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Заполнены не все поля!");
            }
            Vivod();
        }

        private void WorkersAddBtn_Click(object sender, RoutedEventArgs e)
        {
            if (WorkersId.Text == "" || WorkersSurname.Text == "" || WorkersName.Text == "" || WorkersLastname.Text == "" || WorkersSpecialtyId.Text == "")
            {
                try
                {
                    Workers worker = new Workers();
                    worker.Id = db.Workers.Max().Id + 1;
                    worker.Surname = WorkersSurname.Text;
                    worker.Name = WorkersName.Text;
                    worker.Lastname = WorkersLastname.Text;
                    worker.Specialty_Id = int.Parse(WorkersSpecialtyId.Text);
                    worker.IsDeleted = false;
                    db.Workers.Add(worker);
                    db.SaveChanges();
                    MessageBox.Show("Данные добавлены");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка" + Environment.NewLine + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Заполнены не все поля!");
            }
            Vivod();
        }

        private void WorkersUpdBtn_Click(object sender, RoutedEventArgs e)
        {
            if (WorkersId.Text == "" || WorkersSurname.Text == "" || WorkersName.Text == "" || WorkersLastname.Text == "" || WorkersSpecialtyId.Text == "")
            {
                try
                {
                    int i = int.Parse(WorkersId.Text);
                    var worker = db.Workers.Where(w => w.Id == i).FirstOrDefault();
                    worker.Surname = WorkersSurname.Text;
                    worker.Name = WorkersName.Text;
                    worker.Lastname = WorkersLastname.Text;
                    worker.Specialty_Id = int.Parse(WorkersSpecialtyId.Text);
                    db.SaveChanges();
                    MessageBox.Show("Данные обновлены");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка" + Environment.NewLine + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Заполнены не все поля!");
            }
            Vivod();
        }

        private void WorkersDelBtn_Click(object sender, RoutedEventArgs e)
        {
            if (WorkersId.Text == "")
            {
                try
                {
                    int i = int.Parse(WorkersId.Text);
                    var worker = db.Workers.Where(w => w.Id == i).FirstOrDefault();
                    worker.IsDeleted = true;
                    db.SaveChanges();
                    MessageBox.Show("Данные удалены");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка" + Environment.NewLine + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Заполнены не все поля!");
            }
            Vivod();
        }

        private void UsersAddBtn_Click(object sender, RoutedEventArgs e)
        {
            if (UsersId.Text == "" || UsersLogin.Text == "" || UsersPassword.Password == "" || UsersRoleId.Text == "" || UsersSurname.Text == "" || UsersName.Text == "" || UsersLastname.Text == "")
            {
                try
                {
                    Users user = new Users();
                    user.Id = db.Users.Max().Id + 1;
                    user.Surname = UsersSurname.Text;
                    user.Name = UsersName.Text;
                    user.Lastname = UsersLastname.Text;
                    user.Login = UsersLogin.Text;
                    user.Password = UsersPassword.Password;
                    user.Role_Id = int.Parse(UsersRoleId.Text);
                    user.IsDeleted = false;
                    db.Users.Add(user);
                    db.SaveChanges();
                    MessageBox.Show("Данные добавлены");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка" + Environment.NewLine + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Заполнены не все поля!");
            }
            Vivod();
        }

        private void UsersUpdBtn_Click(object sender, RoutedEventArgs e)
        {
            if (UsersId.Text == "" || UsersLogin.Text == "" || UsersPassword.Password == "" || UsersRoleId.Text == "" || UsersSurname.Text == "" || UsersName.Text == "" || UsersLastname.Text == "")
            {
                try
                {
                    int i = int.Parse(UsersId.Text);
                    var user = db.Users.Where(w => w.Id == i).FirstOrDefault();
                    user.Surname = UsersSurname.Text;
                    user.Name = UsersName.Text;
                    user.Lastname = UsersLastname.Text;
                    user.Login = UsersLogin.Text;
                    user.Password = UsersPassword.Password;
                    user.Role_Id = int.Parse(UsersRoleId.Text);
                    db.SaveChanges();
                    MessageBox.Show("Данные обновлены");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка" + Environment.NewLine + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Заполнены не все поля!");
            }
            Vivod();
        }

        private void UsersDelBtn_Click(object sender, RoutedEventArgs e)
        {
            if (UsersId.Text == "")
            {
                try
                {
                    int i = int.Parse(UsersId.Text);
                    var user = db.Users.Where(w => w.Id == i).FirstOrDefault();
                    user.IsDeleted = true;
                    db.SaveChanges();
                    MessageBox.Show("Данные удалены");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка" + Environment.NewLine + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Заполнены не все поля!");
            }
            Vivod();
        }

        private void SpecialtiesAddBtn_Click(object sender, RoutedEventArgs e)
        {
            if (SpecialtiesId.Text == "" || SpecialtiesName.Text == "")
            {
                try
                {
                    Specialties specialty = new Specialties();
                    specialty.Id = db.Specialties.Max().Id + 1;
                    specialty.Name = SpecialtiesName.Text;
                    specialty.IsDeleted = false;
                    db.Specialties.Add(specialty);
                    db.SaveChanges();
                    MessageBox.Show("Данные добавлены");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка" + Environment.NewLine + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Заполнены не все поля!");
            }
            Vivod();
        }

        private void SpecialtiesUpdBtn_Click(object sender, RoutedEventArgs e)
        {
            if (SpecialtiesId.Text == "" || SpecialtiesName.Text == "")
            {
                try
                {
                    int i = int.Parse(SpecialtiesId.Text);
                    var specialty = db.Specialties.Where(w => w.Id == i).FirstOrDefault();
                    specialty.Name = SpecialtiesName.Text;
                    db.SaveChanges();
                    MessageBox.Show("Данные обновлены");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка" + Environment.NewLine + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Заполнены не все поля!");
            }
            Vivod();
        }

        private void SpecialtiesDelBtn_Click(object sender, RoutedEventArgs e)
        {
            if (SpecialtiesId.Text == "")
            {
                try
                {
                    int i = int.Parse(SpecialtiesId.Text);
                    var specialty = db.Specialties.Where(w => w.Id == i).FirstOrDefault();
                    specialty.IsDeleted = true;
                    db.SaveChanges();
                    MessageBox.Show("Данные удалены");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка" + Environment.NewLine + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Заполнены не все поля!");
            }
            Vivod();
        }

        private void RolesAddBtn_Click(object sender, RoutedEventArgs e)
        {
            if (RolesId.Text == "" || RolesName.Text == "")
            {
                try
                {
                    Roles role = new Roles();
                    role.Id = db.Roles.Max().Id + 1;
                    role.Name = RolesName.Text;
                    role.IsDeleted = false;
                    db.Roles.Add(role);
                    db.SaveChanges();
                    MessageBox.Show("Данные добавлены");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка" + Environment.NewLine + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Заполнены не все поля!");
            }
            Vivod();
        }

        private void RolesUpdBtn_Click(object sender, RoutedEventArgs e)
        {
            if (RolesId.Text == "" || RolesName.Text == "")
            {
                try
                {
                    int i = int.Parse(RolesId.Text);
                    var role = db.Roles.Where(w => w.Id == i).FirstOrDefault();
                    role.Name = RolesName.Text;
                    db.SaveChanges();
                    MessageBox.Show("Данные обновлены");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка" + Environment.NewLine + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Заполнены не все поля!");
            }
            Vivod();
        }

        private void RolesDelBtn_Click(object sender, RoutedEventArgs e)
        {
            if (RolesId.Text == "")
            {
                try
                {
                    int i = int.Parse(RolesId.Text);
                    var role = db.Roles.Where(w => w.Id == i).FirstOrDefault();
                    role.IsDeleted = true;
                    db.SaveChanges();
                    MessageBox.Show("Данные удалены");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка" + Environment.NewLine + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Заполнены не все поля!");
            }
            Vivod();
        }

        private void AddressesAddBtn_Click(object sender, RoutedEventArgs e)
        {
            if (AddressesId.Text == "" || AddressesX.Text == "" || AddressesY.Text == "" || AddressesName.Text == "")
            {
                try
                {
                    Addresses address = new Addresses();
                    address.Id = db.Addresses.Max().Id + 1;
                    address.Name = AddressesName.Text;
                    address.PointX = int.Parse(AddressesX.Text);
                    address.PointY = int.Parse(AddressesY.Text);
                    address.IsDeleted = false;
                    db.Addresses.Add(address);
                    db.SaveChanges();
                    MessageBox.Show("Данные добавлены");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка" + Environment.NewLine + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Заполнены не все поля!");
            }
            Vivod();
        }

        private void AddressesUpdBtn_Click(object sender, RoutedEventArgs e)
        {
            if (AddressesId.Text == "" || AddressesX.Text == "" || AddressesY.Text == "" || AddressesName.Text == "")
            {
                try
                {
                    int i = int.Parse(AddressesId.Text);
                    var address = db.Addresses.Where(w => w.Id == i).FirstOrDefault();
                    address.Name = AddressesName.Text;
                    address.PointX = int.Parse(AddressesX.Text);
                    address.PointY = int.Parse(AddressesY.Text);
                    db.SaveChanges();
                    MessageBox.Show("Данные обновлены");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка" + Environment.NewLine + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Заполнены не все поля!");
            }
            Vivod();
        }

        private void AddressesDelBtn_Click(object sender, RoutedEventArgs e)
        {
            if (AddressesId.Text == "")
            {
                try
                {
                    int i = int.Parse(AddressesId.Text);
                    var address = db.Addresses.Where(w => w.Id == i).FirstOrDefault();
                    address.IsDeleted = true;
                    db.SaveChanges();
                    MessageBox.Show("Данные удалены");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка" + Environment.NewLine + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Заполнены не все поля!");
            }
            Vivod();
        }

        private void ResourcesAddBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ResourcesId.Text == "" || ResourcesName.Text == "")
            {
                try
                {
                    Resources resource = new Resources();
                    resource.Id = db.Resources.Max().Id + 1;
                    resource.Name = ResourcesName.Text;
                    resource.IsDeleted = false;
                    db.Resources.Add(resource);
                    db.SaveChanges();
                    MessageBox.Show("Данные добавлены");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка" + Environment.NewLine + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Заполнены не все поля!");
            }
            Vivod();
        }

        private void ResourcesUpdBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ResourcesId.Text == "" || ResourcesName.Text == "")
            {
                try
                {
                    int i = int.Parse(ResourcesId.Text);
                    var resource = db.Resources.Where(w => w.Id == i).FirstOrDefault();
                    resource.Name = ResourcesName.Text;
                    db.SaveChanges();
                    MessageBox.Show("Данные обновлены");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка" + Environment.NewLine + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Заполнены не все поля!");
            }
            Vivod();
        }

        private void ResourcesDelBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ResourcesId.Text == "")
            {
                try
                {
                    int i = int.Parse(ResourcesId.Text);
                    var resource = db.Resources.Where(w => w.Id == i).FirstOrDefault();
                    resource.IsDeleted = true;
                    db.SaveChanges();
                    MessageBox.Show("Данные удалены");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка" + Environment.NewLine + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Заполнены не все поля!");
            }
            Vivod();
        }

        private void TypesAddBtn_Click(object sender, RoutedEventArgs e)
        {
            if (TypesId.Text == "" || TypesName.Text == "")
            {
                try
                {
                    RequestTypes type = new RequestTypes();
                    type.Id = db.RequestTypes.Max().Id + 1;
                    type.Name = TypesName.Text;
                    type.IsDeleted = false;
                    db.RequestTypes.Add(type);
                    db.SaveChanges();
                    MessageBox.Show("Данные добавлены");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка" + Environment.NewLine + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Заполнены не все поля!");
            }
            Vivod();
        }

        private void TypesUpdBtn_Click(object sender, RoutedEventArgs e)
        {
            if (TypesId.Text == "" || TypesName.Text == "")
            {
                try
                {
                    int i = int.Parse(TypesId.Text);
                    var type = db.RequestTypes.Where(w => w.Id == i).FirstOrDefault();
                    type.Name = TypesName.Text;
                    db.SaveChanges();
                    MessageBox.Show("Данные обновлены");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка" + Environment.NewLine + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Заполнены не все поля!");
            }
            Vivod();
        }

        private void TypesDelBtn_Click(object sender, RoutedEventArgs e)
        {
            if (TypesId.Text == "")
            {
                try
                {
                    int i = int.Parse(TypesId.Text);
                    var type = db.RequestTypes.Where(w => w.Id == i).FirstOrDefault();
                    type.IsDeleted = true;
                    db.SaveChanges();
                    MessageBox.Show("Данные удалены");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка" + Environment.NewLine + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Заполнены не все поля!");
            }
            Vivod();
        }

        private void StatutusesAddBtn_Click(object sender, RoutedEventArgs e)
        {
            if (StatusesId.Text == "" || StatusesName.Text == "")
            {
                try
                {
                    Statuses status = new Statuses();
                    status.Id = db.Statuses.Max().Id + 1;
                    status.Name = StatusesName.Text;
                    status.IsDeleted = false;
                    db.Statuses.Add(status);
                    db.SaveChanges();
                    MessageBox.Show("Данные добавлены");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка" + Environment.NewLine + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Заполнены не все поля!");
            }
            Vivod();
        }

        private void StatutusesUpdBtn_Click(object sender, RoutedEventArgs e)
        {
            if (StatusesId.Text == "" || StatusesName.Text == "")
            {
                try
                {
                    int i = int.Parse(TypesId.Text);
                    var status = db.Statuses.Where(w => w.Id == i).FirstOrDefault();
                    status.Name = StatusesName.Text;
                    db.SaveChanges();
                    MessageBox.Show("Данные обновлены");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка" + Environment.NewLine + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Заполнены не все поля!");
            }
            Vivod();
        }

        private void StatutusesDelBtn_Click(object sender, RoutedEventArgs e)
        {
            if (StatusesId.Text == "")
            {
                try
                {
                    int i = int.Parse(TypesId.Text);
                    var status = db.Statuses.Where(w => w.Id == i).FirstOrDefault();
                    status.IsDeleted = true;
                    db.SaveChanges();
                    MessageBox.Show("Данные удалены");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка" + Environment.NewLine + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Заполнены не все поля!");
            }
            Vivod();
        }

        public void Vivod()
        {
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
    }
}
