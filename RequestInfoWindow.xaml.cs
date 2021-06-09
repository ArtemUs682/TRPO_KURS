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

namespace Kurs
{
    /// <summary>
    /// Логика взаимодействия для RequestWindow.xaml
    /// </summary>
    public partial class RequestInfoWindow : Window
    {
        public static int Index = -1;
        public gr682_uatEntities db = new gr682_uatEntities();
        public static int UserId = -1;

        public static void GetUserId(int i)
        {
            UserId = i;
        }
        public static void GetID (int Id)
        {
            Index = Id;
        }
        public RequestInfoWindow()
        {
            InitializeComponent();
            var selectedREQ = db.Requests.Where(w => w.Id == Index).FirstOrDefault();
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
            var CLIENTrow = db.Clients.Where(w => w.Id == selectedREQ.Client_Id).FirstOrDefault();
            string s = "[" + CLIENTrow.Id + "] " + CLIENTrow.Surname + " " + CLIENTrow.Name + " " + CLIENTrow.Lastname;
            ClientComboBox.SelectedIndex = ClientComboBox.Items.IndexOf(s);

            for (int i = 1; i <= db.RequestTypes.Count(); i++)
            {
                var row = db.RequestTypes.Where(w => w.Id == i).FirstOrDefault();
                if (row != null)
                {
                    if (row.IsDeleted != true)
                    {
                        TypesComboBox.Items.Add(row.Name);
                    }
                }
            }
            var TYPErow = db.RequestTypes.Where(w => w.Id == selectedREQ.RequestType_Id).FirstOrDefault();
            s = TYPErow.Name;
            TypesComboBox.SelectedIndex = TypesComboBox.Items.IndexOf(s);

            for (int i = 1; i <= db.Workers.Count(); i++)
            {
                var row = db.Workers.Where(w => w.Id == i).FirstOrDefault();
                if (row != null)
                {
                    if (row.IsDeleted != true)
                    {
                        WorkerComboBox.Items.Add("[" + row.Id + "] " + row.Surname + " " + row.Name + " " + row.Lastname);
                    }
                }
            }
            var WORKERrow = db.Workers.Where(w => w.Id == selectedREQ.Worker_Id).FirstOrDefault();
            s = "[" + WORKERrow.Id + "] " + WORKERrow.Surname + " " + WORKERrow.Name + " " + WORKERrow.Lastname;
            WorkerComboBox.SelectedIndex = WorkerComboBox.Items.IndexOf(s);

            for (int i = 1; i <= db.Statuses.Count(); i++)
            {
                var row = db.Statuses.Where(w => w.Id == i).FirstOrDefault();
                if (row != null)
                {
                    if (row.IsDeleted != true)
                    {
                        StatusComboBox.Items.Add(row.Name);
                    }
                }
            }
            var STATUSrow = db.Statuses.Where(w => w.Id == selectedREQ.Status_Id).FirstOrDefault();
            s = STATUSrow.Name;
            StatusComboBox.SelectedIndex = StatusComboBox.Items.IndexOf(s);

            DateBox.SelectedDate = selectedREQ.Date;
            DescripBox.Text = selectedREQ.Description;
        }

        private void AddBut_Click(object sender, RoutedEventArgs e)
        {
            var uRow = db.Requests.Where(w => w.Id == Index).FirstOrDefault();
            
            uRow.Client_Id = WhatId(ClientComboBox.SelectedItem.ToString());
            uRow.Date = DateBox.SelectedDate.Value;
            uRow.RequestType_Id = db.RequestTypes.Where(w => w.Name == TypesComboBox.SelectedItem.ToString()).FirstOrDefault().Id;
            uRow.Description = DescripBox.Text;
            uRow.Worker_Id = WhatId(WorkerComboBox.Text);
            uRow.Status_Id = db.Statuses.Where(w => w.Name == StatusComboBox.Text).FirstOrDefault().Id;
            db.SaveChanges();
            RequestsWindow window = new RequestsWindow();
            window.Vivod();
        }

        private int WhatId (string str)
        {
            string id = "";
            for (int i = 0; str[i] != ']'; i++)
            {
                id += str[i];
            }
            id = id.Substring(1);
            return int.Parse(id);
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
