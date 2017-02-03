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
using bin_packing_a_etoile;
using System.Reflection;

namespace Pi_
{
    /// <summary>
    /// Logique d'interaction pour Parking_window.xaml
    /// </summary>
    public partial class Parking_window : Window
    {
        private SolidColorBrush _blackBrush = new SolidColorBrush(Colors.Black);
        private SolidColorBrush _redBrush = new SolidColorBrush(Colors.Red);
        private SolidColorBrush _greenBrush = new SolidColorBrush(Colors.Green);
        private SolidColorBrush _blueBrush = new SolidColorBrush(Colors.Blue);
        private List<Rectangle> _rectangles = new List<Rectangle>();
        private List<Rectangle> _rectangles_bis = new List<Rectangle>();
        public int width;
        public Parking_window ()
        {
            InitializeComponent();

            Main_bin_packing mainb = new Main_bin_packing();
            List<IMappedImageInfo> mapy = mainb.Map;
            int i = 0;

            foreach (IMappedImageInfo m in mapy)
            {


                Rectangle rect = new Rectangle(); //create the rectangle
                rect.StrokeThickness = 1;  //border to 1 stroke thick
                InitBrushes();
                rect.Stroke = _brushes[i]; //border color to black
                rect.Fill = _brushes[i];
                rect.Width = m.ImageInfo.Width * 10;
                rect.Height = m.ImageInfo.Height * 10;
                rect.Name = "box" + i.ToString();
                Canvas.SetLeft(rect, m.X * 10);
                Canvas.SetTop(rect, m.Y * 10);
                _rectangles.Add(rect);
                i++;
            }
            // var grid = this.Content as Grid;

            foreach (var rect in _rectangles)
            {
                can.Children.Add(rect);

            }
            Main_AStar mainas = new Main_AStar();
            List<Coordonnee> liste = mainas.Liste;
            this.width = 80;
            int p = 0;
            foreach (Coordonnee l in liste)
            {
                //   ConsoleManager.Show();
                // Console.WriteLine(l.X);
                //Console.WriteLine(l.Y);
                Rectangle point = new Rectangle(); //create the rectangle
                point.StrokeThickness = 1;  //border to 1 stroke thick
                InitBrushes();
                point.Stroke = _redBrush; //border color to black
                point.Fill = _redBrush;
                point.Width = 1 * 10;
                point.Height = 1 * 10;
                point.Name = "bo" + p.ToString();
                Canvas.SetLeft(point, 10 * l.X);
                Canvas.SetTop(point, 10 * l.Y);
                _rectangles_bis.Add(point);
                p++;
            }
            // var grid = this.Content as Grid;

            foreach (var point in _rectangles_bis)
            {
                can.Children.Add(point);

            }

            Canvas.SetLeft(start, mainas.Start.X * 10);
            Canvas.SetTop(start, mainas.Start.Y * 10);
            Canvas.SetLeft(stop, mainas.Goal.X * 10);
            Canvas.SetTop(stop, mainas.Goal.Y * 10);
        }

        private Brush PickBrush(Random rnd)
        {
            Brush result = Brushes.Transparent;



            Type brushesType = typeof(Brushes);

            PropertyInfo[] properties = brushesType.GetProperties();

            int random = rnd.Next(properties.Length);
            result = (Brush)properties[random].GetValue(null, null);

            return result;
        }
        private List<Brush> _brushes;
        private void InitBrushes()
        {
            _brushes = new List<Brush>();
            var props = typeof(Brushes).GetProperties(BindingFlags.Public | BindingFlags.Static);
            foreach (var propInfo in props)
            {
                _brushes.Add((Brush)propInfo.GetValue(null, null));
            }
        }
    }
}
