using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
namespace Pi_
{
    /// <summary>
    /// Logique d'interaction pour Optimisation.xaml
    /// </summary>
    public partial class Optimisation : Window
    {
      
          private SolidColorBrush _blackBrush = new SolidColorBrush(Colors.Black);
        private SolidColorBrush _redBrush = new SolidColorBrush(Colors.Red);
        private SolidColorBrush _greenBrush = new SolidColorBrush(Colors.Green);
        private SolidColorBrush _blueBrush = new SolidColorBrush(Colors.Blue);
        private SolidColorBrush _pinkBrush = new SolidColorBrush(Colors.Pink);
        private List<Rectangle> _rectangles = new List<Rectangle>();
        private List<Rectangle> _rectangles_bis = new List<Rectangle>();
        public int width;

        public Optimisation()
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
           
          

            foreach (var point in _rectangles_bis)
            {
                can.Children.Add(point);

            }

         
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

        private void button_Click(object sender, RoutedEventArgs e)
        {
            string id=id_hangar.Text;
            int id_h = Int32.Parse(id);
            MV_Add ajout = new MV_Add(id);
           List<IImageInfo> liste= ajout.Recherche_avion();
            Main_bin_packing main =new Main_bin_packing(liste,id_h);

                       //ajout.Add_opti();
        }
    }
    }

