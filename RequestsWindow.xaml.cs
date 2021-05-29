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

namespace Kurs
{
    /// <summary>
    /// Логика взаимодействия для RequestsWindow.xaml
    /// </summary>
    public partial class RequestsWindow : Window
    {
        public List<string> ChosenItems = new List<string>();
        public TRPO_KURSEntities db = new TRPO_KURSEntities();
        public static int UserId = -1;

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
                if (row.IsDeleted != true)
                {
                    ClientComboBox.Items.Add("[" + row.Id + "] " + row.Surname + " " + row.Name + " " + row.Lastname);
                }
            }

            DateBox.SelectedDate = DateTime.Now;

            for (int i = 1; i <= db.RequestTypes.Count(); i++)
            {
                var row = db.RequestTypes.Where(w => w.Id == i).FirstOrDefault();
                if (row.IsDeleted != true)
                {
                    TypeBox.Items.Add(row.Name);
                }
            }

            for (int i = 1; i <= db.Workers.Count(); i++)
            {
                var row = db.Workers.Where(w => w.Id == i).FirstOrDefault();
                if (row.IsDeleted != true)
                {
                    WorkerBox.Items.Add("[" + row.Id + "] " + row.Surname + " " + row.Name + " " + row.Lastname);
                }
            }

            for (int i = 1; i <= db.Statuses.Count(); i++)
            {
                var row = db.Statuses.Where(w => w.Id == i).FirstOrDefault();
                if (row.IsDeleted != true)
                {
                    StatusBox.Items.Add(row.Name);
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
                if (row != null && row.IsDeleted == false && row.Status_Id != 1 && row.Status_Id != 4)
                {
                    LV.Items.Add("Заявка №" + row.Id.ToString() + "   " + row.Description);
                }
            }
        }

        private void FindPeriodBtn_Click(object sender, RoutedEventArgs e)
        {
            LV.Items.Clear();
            for (int i = 0; i <= db.Requests.Count(); i++)
            {
                var row = db.Requests.Where(w => w.Id == i).FirstOrDefault();
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
