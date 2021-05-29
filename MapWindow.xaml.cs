﻿using System;
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
using System.Net;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsPresentation;

namespace Kurs
{
    /// <summary>
    /// Логика взаимодействия для MapWindow.xaml
    /// </summary>
    public partial class MapWindow : Window
    {
        public TRPO_KURSEntities db = new TRPO_KURSEntities();
        public MapWindow()
        {
            InitializeComponent();
            for(int i = 1; i < db.Addresses.Count(); i++)
            {
                var row = db.Addresses.Where(w => w.Id == i).FirstOrDefault();
                FindBox.Items.Add(row.Name);
            }
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void AddPoint_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RemovePoint_Click(object sender, RoutedEventArgs e)
        {

        }

        private void map_load(object sender, RoutedEventArgs e)
        {
            //Настройка карты
            gmap.Bearing = 0;
            gmap.CanDragMap = true;
            gmap.DragButton = MouseButton.Left;
            gmap.MaxZoom = 17;
            gmap.MinZoom = 11;
            gmap.MouseWheelZoomType = MouseWheelZoomType.MousePositionWithoutCenter;
            gmap.ShowTileGridLines = false;
            gmap.Zoom = 12;
            gmap.ShowCenter = false;
            gmap.MapProvider = GMapProviders.YandexMap;
            GMaps.Instance.Mode = AccessMode.ServerOnly;
            gmap.Position = new PointLatLng(56.484646, 84.981408);

            //Добавление маркеров
            for (int i = 1; i <= db.Addresses.Count(); i++)
            {
                var row = db.Addresses.Where(w => w.Id == i).FirstOrDefault();
                if (row.IsDeleted != true)
                {
                    GMap.NET.WindowsPresentation.GMapMarker marker = new GMap.NET.WindowsPresentation.GMapMarker(new PointLatLng(row.PointX, row.PointY));
                    marker.Shape = new Image()
                    {
                        Source = new BitmapImage(new Uri("pack://application:,,,/Images/geometka.png")),
                        Width = 30,
                        Height = 60,
                        ToolTip = row.Name,
                        Visibility = Visibility.Visible
                    };
                    gmap.Markers.Add(marker);
                }
            }
        }

        private void FindBtn_Click(object sender, RoutedEventArgs e)
        {
            if (FindBox.SelectedItem.ToString() != "")
            {
                var row = db.Addresses.Where(w => w.Name == FindBox.SelectedItem.ToString()).FirstOrDefault();
                gmap.Position = new PointLatLng(row.PointX, row.PointY);
                gmap.Zoom = 17;
            }
        }
    }
}
