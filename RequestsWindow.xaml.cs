using System;
using System.Collections.Generic;
using System.Data;
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
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;

namespace Kurs
{
    /// <summary>
    /// Логика взаимодействия для RequestsWindow.xaml
    /// </summary>
    public partial class RequestsWindow : System.Windows.Window
    {
        public List<string> ChosenItems = new List<string>();
        public gr682_uatEntities db = new gr682_uatEntities();
        public static int UserId = -1;
        SqlConnection con = new SqlConnection("Data Source=mssql;Initial Catalog=gr682_uat;Integrated Security=True");

        public static void GetUserId(int i)
        {
            UserId = i;
        }


        public RequestsWindow()
        {
            InitializeComponent();
            Vivod();

            for (int i = 1; i <= db.Clients.Count(); i++)
            {
                var row = db.Clients.Where(w => w.Id == i).FirstOrDefault();
                if (row != null)
                {
                    if (row.IsDeleted != true)
                    {
                        ClientComboBox.Items.Add("[" + row.Id + "] " + row.Surname + " " + row.Name + " " + row.Lastname);
                    }
                }
            }

            DateBox.SelectedDate = DateTime.Now;

            for (int i = 1; i <= db.RequestTypes.Count(); i++)
            {
                var row = db.RequestTypes.Where(w => w.Id == i).FirstOrDefault();
                if (row != null)
                {
                    if (row.IsDeleted != true)
                    {
                        TypeBox.Items.Add(row.Name);
                    }
                }
            }

            for (int i = 1; i <= db.Workers.Count(); i++)
            {
                var row = db.Workers.Where(w => w.Id == i).FirstOrDefault();
                if (row != null)
                {
                    if (row.IsDeleted != true)
                    {
                        WorkerBox.Items.Add("[" + row.Id + "] " + row.Surname + " " + row.Name + " " + row.Lastname);
                    }
                }
            }

            for (int i = 1; i <= db.Statuses.Count(); i++)
            {
                var row = db.Statuses.Where(w => w.Id == i).FirstOrDefault();
                if (row != null)
                {
                    if (row.IsDeleted != true)
                    {
                        StatusBox.Items.Add(row.Name);
                    }
                }
            }

            StatusBox.SelectedIndex = StatusBox.Items.IndexOf("В ожидании");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            object tag = (sender as FrameworkElement).Tag;
            int index = LV.Items.IndexOf(tag);
            LV.SelectedIndex = index;
            string str = LV.SelectedItem.ToString();
            str = str.Substring(8);
            string number = "";
            for (int i = 0; str[i] != ' '; i++)
            {
                number += str[i];
            }
            int Index = int.Parse(number);
            RequestInfoWindow.GetID(Index);

            RequestInfoWindow window = new RequestInfoWindow();
            window.Show();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            object tag = (sender as FrameworkElement).Tag;
            int index = LV.Items.IndexOf(tag);
            LV.SelectedIndex = index;
            if (sender.ToString().Contains("True"))
            {
                ChosenItems.Add(LV.SelectedItem.ToString());
            }
            if (sender.ToString().Contains("False"))
            {
                ChosenItems.Remove(LV.SelectedItem.ToString());
            }
           
        }

        private void DoneBut_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < ChosenItems.Count; i++)
            {
                string str = "";
                for(int j = 8; ChosenItems[i][j] != ' '; j++)
                {
                    str += ChosenItems[i][j];
                }
                int id = int.Parse(str);
                var row = db.Requests.Where(w => w.Id == id).FirstOrDefault();
                row.Status_Id = 1;
            }
            Vivod();
        }

        private void CanceledBut_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < ChosenItems.Count; i++)
            {
                string str = "";
                for (int j = 8; ChosenItems[i][j] != ' '; j++)
                {
                    str += ChosenItems[i][j];
                }
                int id = int.Parse(str);
                var row = db.Requests.Where(w => w.Id == id).FirstOrDefault();
                row.Status_Id = 4;
            }
            Vivod(); 
        }

        private void AddBut_Click(object sender, RoutedEventArgs e)
        {
            if (ClientComboBox.SelectedItem == null || DateBox.SelectedDate.Value == null || TypeBox.SelectedItem == null || DescripBox.Text == "" || WorkerBox.SelectedItem == null || StatusBox.SelectedItem == null)
            {
                MessageBox.Show("Заполнены не все поля!");
            }
            else
            {
                Requests request = new Requests();
                request.Id = db.Requests.Max(w => w.Id) + 1;
                request.Client_Id = WhatId(ClientComboBox.SelectedItem.ToString());
                request.RequestType_Id = db.RequestTypes.Where(w => w.Name == TypeBox.SelectedItem.ToString()).FirstOrDefault().Id;
                request.Date = DateBox.SelectedDate.Value;
                request.Description = DescripBox.Text;
                request.Worker_Id = WhatId(WorkerBox.Text);
                request.Status_Id = db.Statuses.Where(w => w.Name == StatusBox.SelectedItem.ToString()).FirstOrDefault().Id;
                request.User_Id = UserId;
                request.IsDeleted = false;
                db.Requests.Add(request);
                db.SaveChanges();
                Vivod();
            }
        }

        private int WhatId(string str)
        {
            string id = "";
            for (int i = 0; str[i] != ']'; i++)
            {
                id += str[i];
            }
            id = id.Substring(1);
            return int.Parse(id);
        }

        public void Vivod()
        {
            LV.Items.Clear();
            for (int i = 0; i <= db.Requests.Count(); i++)
            {
                var row = db.Requests.Where(w => w.Id == i).FirstOrDefault();
                if (row != null)
                { 
                    if (row.IsDeleted == false && row.Status_Id != 1 && row.Status_Id != 4)
                    {
                        LV.Items.Add("Заявка №" + row.Id.ToString() + "   " + row.Description);
                    }
                }
            }
        }

        private void FindPeriodBtn_Click(object sender, RoutedEventArgs e)
        {
            if (StartDate.SelectedDate == null || EndDate.SelectedDate == null)
            {
                MessageBox.Show("Не выбрана начальная и/или конечная дата");
            }
            else
            {
                LV.Items.Clear();
                for (int i = 0; i <= db.Requests.Count(); i++)
                {
                    var row = db.Requests.Where(w => w.Id == i).FirstOrDefault();
                    if (row != null)
                    {
                        if (row != null && row.IsDeleted == false && row.Status_Id != 1 && row.Status_Id != 4)
                        {
                            if (row.Date >= StartDate.SelectedDate.Value && row.Date <= EndDate.SelectedDate.Value)
                            {
                                LV.Items.Add("Заявка №" + row.Id.ToString() + "   " + row.Description);
                            }
                        }
                    }
                }
            }
        }

        private void ReportBtn_Click(object sender, RoutedEventArgs e)
        {
            var row = db.Users.Where(w => w.Id == UserId).FirstOrDefault();
            if (StartDate.SelectedDate.Value.ToString().Contains("DELETE") || StartDate.SelectedDate.Value.ToString().Contains(";") || EndDate.SelectedDate.Value.ToString().Contains("DELETE") || EndDate.SelectedDate.Value.ToString().Contains(";"))
            {
                MessageBox.Show("Поля содержат недопустимые значения");
            }
            else
            {
                if (StartDate.SelectedDate == null || EndDate.SelectedDate == null)
                {
                    MessageBox.Show("Не выбрана начальная и/или конечная дата");
                }
                else
                {
                    string query = ("CREATE TABLE #Vrem " +
                                    "( " +
                                    "s1 NVARCHAR(300) NULL, " +
                                    "s2 NVARCHAR(100) NULL, " +
                                    "s3 NVARCHAR(100) NULL, " +
                                    "s4 NVARCHAR(100) NULL, " +
                                    "s5 NVARCHAR(300) NULL, " +
                                    "s6 NVARCHAR(300) NULL, " +
                                    "s7 NVARCHAR(300) null, " +
                                    ") " +
                                    "INSERT INTO #Vrem " +
                                    "SELECT Requests.Id, Clients.Surname + ' ' + Clients.Name + ' ' + Clients.Lastname, Date, RequestTypes.Name, Description, Workers.Surname + ' ' + Workers.Name + ' ' + Workers.Lastname, Statuses.Name FROM Requests " +
                                    "INNER JOIN Clients ON Client_Id = Clients.Id " +
                                    "INNER JOIN RequestTypes ON RequestType_Id = RequestTypes.Id " +
                                    "INNER JOIN Workers ON Worker_Id = Workers.Id " +
                                    "INNER JOIN Statuses ON Status_Id = Statuses.Id " +
                                    "INNER JOIN Users ON User_Id = Users.Id " +
                                    "WHERE Date BETWEEN '" + StartDate.SelectedDate.Value.ToShortDateString() + "' AND '" + EndDate.SelectedDate.Value.ToShortDateString() + "' " +
                                    "INSERT INTO #Vrem VALUES (null, null, null, null, null, null, null) " +
                                    "INSERT INTO #Vrem  " +
                                    "SELECT " +
                                    "CASE " +
                                    "WHEN Statuses.Name = 'Отменён' THEN 'Отменено' " +
                                    "WHEN Statuses.Name = 'Выполнен' THEN 'Выполнено' " +
                                    "END ' ',  " +
                                    "COUNT(Requests.Id) AS ' ', null, null, null, null, null FROM Requests " +
                                    "INNER JOIN Clients ON Client_Id = Clients.Id " +
                                    "INNER JOIN RequestTypes ON RequestType_Id = RequestTypes.Id " +
                                    "INNER JOIN Workers ON Worker_Id = Workers.Id " +
                                    "INNER JOIN Statuses ON Status_Id = Statuses.Id " +
                                    "INNER JOIN Users ON User_Id = Users.Id " +
                                    "WHERE Date BETWEEN '31.01.2018' AND '09.06.2021' " +
                                    "GROUP BY Statuses.Name " +
                                    "Having Statuses.Name = 'Отменён' OR Statuses.Name = 'Выполнен' " +
                                    "INSERT INTO #Vrem VALUES ('Дата отчёта', CONCAT(DAY(GETDATE()), '.', MONTH(GETDATE()), '.', YEAR(GETDATE())), null, null, null, null, null) " +
                                    "INSERT INTO #Vrem VALUES ('Отчет составил(а)', '" + row.Surname + " " + row.Name + " " + row.Lastname + "', null, null, null, null, null) " +
                                    "SELECT s1 AS 'Номер заявки', s2 AS Клиент, s3 AS Дата, s4 AS 'Тип заявки', s5 AS Описание, s6 AS 'Назначенный работник', s7 AS Статус FROM #Vrem " +
                                    "DROP TABLE #Vrem;");
                    System.Data.DataTable dataTable = new System.Data.DataTable();
                    dataTable = WorkWithQuery(query);

                    ///////Работа с эксель
                    Excel.Application excel = new Excel.Application();
                    Excel.Workbook workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);
                    Excel.Worksheet sheet1 = (Excel.Worksheet)workbook.Sheets[1];

                    for (int j = 0; j < dataTable.Columns.Count; j++)
                    {
                        Excel.Range myRange = (Excel.Range)sheet1.Cells[1, j + 1];
                        sheet1.Cells[1, j + 1].Font.Bold = true;
                        sheet1.Columns[j + 1].ColumnWidth = 20;
                        myRange.Value2 = dataTable.Columns[j].ColumnName;
                    }
                    for (int i = 0; i < dataTable.Columns.Count; i++)
                    {
                        for (int j = 0; j < dataTable.Rows.Count; j++)
                        {
                            Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[j + 2, i + 1];
                            myRange.Value2 = dataTable.Rows[j][i].ToString();
                            if (sheet1.Columns[i + 1].ColumnWidth < dataTable.Rows[j][i].ToString().Length)
                            {
                                sheet1.Columns[i + 1].ColumnWidth = dataTable.Rows[j][i].ToString().Length + 5;
                            }
                        }
                    }
                    excel.Visible = true;
                }
            }
        }

        public System.Data.DataTable WorkWithQuery(string query)
        {
            con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            System.Data.DataTable dataTable = new System.Data.DataTable();
            adapter.Fill(dataTable);
            con.Close();
            return dataTable;
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
