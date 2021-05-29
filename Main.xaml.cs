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
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        public RequestsWindow requestsWindow = new RequestsWindow();
        public ReceiptsWindow receiptsWindow = new ReceiptsWindow();
        public MapWindow mapWindow = new MapWindow();
        public TechsWindow techsWindow = new TechsWindow();
        public static int UseId = -1;

        public static void GetUserId (int i)
        {
            UseId = i;
        }

        public Main()
        {
            InitializeComponent();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Turn_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Requests_btnClck(object sender, RoutedEventArgs e)
        {
            requestsWindow.Show();
        }


        private void Receipts_btnClck(object sender, RoutedEventArgs e)
        {
            receiptsWindow.Show();
        }

        private void Map_btnClck(object sender, RoutedEventArgs e)
        {
            mapWindow.Show();
        }

        private void Techs_btnClck(object sender, RoutedEventArgs e)
        {
            techsWindow.Show();
        }
    }
}
