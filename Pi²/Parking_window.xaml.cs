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
        private SolidColorBrush _blackBrush = new SolidColorBrush(Colors.Violet);
        private SolidColorBrush _redBrush = new SolidColorBrush(Colors.Red);
        private SolidColorBrush _greenBrush = new SolidColorBrush(Colors.Green);
        private SolidColorBrush _blueBrush = new SolidColorBrush(Colors.Blue);
        private SolidColorBrush _pinkBrush = new SolidColorBrush(Colors.Pink);
        private List<Rectangle> _rectangles = new List<Rectangle>();
        private List<Image> _image = new List<Image>();
        private List<Rectangle> _rectangles_bis = new List<Rectangle>();
        public int width;
        public Parking_window ()
        {
            InitializeComponent();
            MV_Add ajout = new MV_Add("1");
            List<IImageInfo> list = ajout.Recherche_avion();
            Main_bin_packing main = new Main_bin_packing(list, 1);
            List<IMappedImageInfo> mapy = main.Map;
            int i = 0;

            foreach (IMappedImageInfo m in mapy)
            {
//rectangle
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
                //avion
                Image image1 = new Image();
                var uri = new Uri("C://Users/sibel/Source/Repos/PICARRE/Pi²/avion.png");
                var bitmap = new BitmapImage(uri);
                image1.Source = bitmap;
                image1.Height = m.ImageInfo.Height * 10;
                image1.Width = m.ImageInfo.Width * 10;
                Canvas.SetLeft(image1, m.X * 10);
                Canvas.SetTop(image1, m.Y * 10);
                _image.Add(image1);
                i++;
            }
            // var grid = this.Content as Grid;
            int h = 0;
            foreach (var rect in _rectangles)
            {
              
                can.Children.Add(rect);
                can.Children.Add(_image[h]);
                h++;
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

      
        private List<Brush> _brushes;
        private void InitBrushes()
        {
    
           
       _brushes = new List<Brush>();
            var props = typeof(Brushes).GetProperties(BindingFlags.Public | BindingFlags.Static);
            _brushes.Add(_blackBrush);
            _brushes.Add(_blueBrush);
            _brushes.Add(_greenBrush);
            _brushes.Add(_redBrush);
            _brushes.Add(_pinkBrush);
            foreach (var propInfo in props)
            {
                _brushes.Add((Brush)propInfo.GetValue(null, null));
            }
        }
    }
}
