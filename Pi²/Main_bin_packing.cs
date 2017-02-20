using Pi_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bin_packing_a_etoile
{
    public class Main_bin_packing
    {
        public List<IMappedImageInfo> map;
        Canvas_bis _canvas;
        public Main_bin_packing()
        {


            _canvas = new Canvas_bis();
            _canvas.SetCanvasDimensions(40, 40);
            _canvas.PlaceOccupied(0, 0, 5, 5);

            /*  for(int i = 0; i < 10; i++)
              {
                  for(int m = 0; m <10; m++)
                  {
                      Console.Write(_canvas.CanvasCells.Item(i, m).ToString());
                  }
                  Console.WriteLine();
              }
             Console.WriteLine( _canvas.CanvasCells.ToString());*/
            MapperOptimalEfficiency<Sprite> mapper = new MapperOptimalEfficiency<Sprite>(_canvas);

            ImageInfo a = new ImageInfo( 5,10);
            ImageInfo b = new ImageInfo(4,12);
            ImageInfo c = new ImageInfo( 8,15);
            ImageInfo d = new ImageInfo( 6,15);
            ImageInfo j = new ImageInfo(4,10);
            ImageInfo f = new ImageInfo(3,7);
            List<IImageInfo> list = new List<IImageInfo>();
            list.Add(a);
            list.Add(b);
            list.Add(c);
          list.Add(d);
            list.Add(j);
          // list.Add(f);
            //si la place n'est pas disponible gros BEUGGGG

            IEnumerable<IImageInfo> rectangles = list;

            Sprite sprite = mapper.Mapping(rectangles);

            Console.WriteLine(_canvas.CanvasCells.ToString());
            map = sprite.MappedImages;
 
            foreach (IMappedImageInfo e in map)
            {
                ConsoleManager.Show();
                System.Console.WriteLine("plece en X : " + e.X + " ");
                ConsoleManager.Show();
                System.Console.Write("Place en Y : " + e.Y + " ");
                ConsoleManager.Show();
                System.Console.Write("height : " + e.ImageInfo.Height + " ");
                ConsoleManager.Show();
                System.Console.Write("width : " + e.ImageInfo.Width + " ");
             
            }
         
            ConsoleManager.Show();
            Console.ReadLine();



        }
        //constructeur avec liste en parametres
        public Main_bin_packing(List<IImageInfo> list,int id_hangar)
        {


            _canvas = new Canvas_bis();
            _canvas.SetCanvasDimensions(40, 40);
            _canvas.PlaceOccupied(0, 0, 5, 5);

            /*  for(int i = 0; i < 10; i++)
              {
                  for(int m = 0; m <10; m++)
                  {
                      Console.Write(_canvas.CanvasCells.Item(i, m).ToString());
                  }
                  Console.WriteLine();
              }
             Console.WriteLine( _canvas.CanvasCells.ToString());*/
            MapperOptimalEfficiency<Sprite> mapper = new MapperOptimalEfficiency<Sprite>(_canvas);

            ImageInfo a = new ImageInfo(5, 10);
            ImageInfo b = new ImageInfo(4, 12);
            ImageInfo c = new ImageInfo(8, 15);
            ImageInfo d = new ImageInfo(6, 15);
            ImageInfo j = new ImageInfo(4, 10);
            ImageInfo f = new ImageInfo(3, 7);
          /*  List<IImageInfo> list = new List<IImageInfo>();
            list.Add(a);
            list.Add(b);
            list.Add(c);
            list.Add(d);
            list.Add(j);*/
            // list.Add(f);
            //si la place n'est pas disponible gros BEUGGGG

            IEnumerable<IImageInfo> rectangles = list;

            Sprite sprite = mapper.Mapping(rectangles);

            Console.WriteLine(_canvas.CanvasCells.ToString());
            map = sprite.MappedImages;
            int[,] tableau = new int[map.Count, 3];
            int i = 0;
            foreach (IMappedImageInfo e in map)
            {
                ConsoleManager.Show();
                System.Console.WriteLine("plece en X : " + e.X + " ");
                ConsoleManager.Show();
                System.Console.Write("Place en Y : " + e.Y + " ");
                ConsoleManager.Show();
                System.Console.Write("height : " + e.ImageInfo.Height + " ");
                ConsoleManager.Show();
                System.Console.Write("width : " + e.ImageInfo.Width + " ");
                tableau[i, 0] = e.ImageInfo.Id;
                tableau[i, 1] = e.X;
                tableau[i, 2] = e.Y;
                i++;

            }
            M_BDD basedd = new M_BDD();
            basedd.Add_optimisation(tableau,id_hangar);
            ConsoleManager.Show();
            Console.ReadLine();



        }
        public int[,] Transformed()
        {

            //int[] tab = size_tab();
            int[] tab = { 40, 40 };

            int[,] tableau = new int[40, 40];
            ConsoleManager.Show();

            for (int i = 0; i < tableau.GetLength(0); i++)
            {
                for (int j = 0; j < tableau.GetLength(1); j++)
                {
                    tableau[i, j] = 1;
                }
            }
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    tableau[i, j] = -1;
                }
            }

            foreach (IMappedImageInfo e in map)
            {

                for (int y = 0; y < e.ImageInfo.Height; y++)
                {
                    for (int x = 0; x < e.ImageInfo.Width; x++)
                    {

                        tableau[y + e.Y, x + e.X] = -1;
                        ////probleme d'inexation commen tretrouver l'indexe en fonction de la largeur de colomne et le reste 
                    }
                }

            }

            return tableau;
        }
        public List<IMappedImageInfo> Map
        {
            get
            {
                return this.map;
            }
            set
            {
                this.map = value;
            }
        }
        public Canvas_bis Canvas_b
        {
            get
            {
                return this._canvas;
            }
            set
            {
                this._canvas = value;
            }
        }
    }
}
