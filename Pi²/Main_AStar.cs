using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Games.Pathfinding.AStar2DTest;
using Tanis.Collections;
using System.Collections;
namespace bin_packing_a_etoile
{
    public class Main_AStar
    {
        int[,] Mapb = {
            { 1,-1, 1, 1, 1,-1, 1, 1, 1, 1 },
            { 1,-1, 1,-1, 1,-1, 1, 1, 1, 1 },
            { 1,-1, 1,-1, 1,-1, 1, 1, 1, 1 },
            { 1,-1, 1,-1, 1,-1, 1, 1, 1, 1 },
            { 1,-1, 1,-1, 1,-1, 1, 1, 1, 1 },
            { 1,-1, 1,-1, 1,-1, 1, 1, 1, 1 },
            { 1,-1, 1,-1, 1,-1, 1, 1, 1, 1 },
            { 1,-1, 1,-1, 1,-1, 1, 1, 1, 1 },
            { 1,-1, 1,-1, 1,-1, 1, 2, 1, 1 },
            { 1, 1, 1,-1, 1, 1, 2, 3, 2, 1 }
        };

        public static Main_bin_packing mainb = new Main_bin_packing();
        int[,] Map = mainb.Transformed();
       
        List<Coordonnee> listeb;
        AStarNode2D GoalNode;
        AStarNode2D StartNode;
        public Main_AStar()
        {


            ConsoleManager.Show();

            Console.WriteLine("Starting...");

            Games.Pathfinding.AStar astar = new Games.Pathfinding.AStar();

            this.GoalNode = new AStarNode2D(null, null, 0, 30, 2);
            this.StartNode = new AStarNode2D(null, GoalNode, 0, 5, 15);
            StartNode.GoalNode = GoalNode;
            astar.FindPath(StartNode, GoalNode);

          List<Coordonnee> listeb=  PrintSolution(astar.Solution);
            this.listeb = listeb;

            Console.ReadLine();

        }
        public List<Coordonnee> Liste
        {
            get
            {
                return this.listeb;
            }
            set
            {
                this.listeb = value;
            }
        }
        public AStarNode2D Start
        {
            get
            {
                return this.StartNode;
            }
            set
            {
                this.StartNode = value;
            }
        }
        public AStarNode2D Goal
        {
            get
            {
                return this.GoalNode;
            }
            set
            {
                this.GoalNode = value;
            }
        }
        public int GetMap(int x, int y)
        {
            if ((x < 0) || (x > Map.GetLength(0) ))

            return (-1); 
            if ((y < 0) || (y > Map.GetLength(1)))
                return (-1);
            return (Map[y, x]);
        }
       
        /// <summary>
        /// Prints the solution
        /// </summary>
        /// <param name="ASolution">The list that holds the solution</param>
        public List<Coordonnee> PrintSolution(ArrayList ASolution)
        {
            Console.WriteLine("++++++++++++++++++++" + Map.GetLength(0));
            List<Coordonnee> liste = new List<Coordonnee>();
            ConsoleManager.Show();
            for (int j = 0; j < Map.GetLength(0); j++)
            {
                for (int i = 0; i <Map.GetLength(1); i++)
                {
                    ConsoleManager.Show();
        
                    bool solution = false;
                    foreach (AStarNode2D n in ASolution)
                    {
                        AStarNode2D tmp = new AStarNode2D(null, null, 0, i, j);
                        solution = n.IsSameState(tmp);
                      
                        if (solution)
                            break;
                    }
                    if (solution) {
                        ConsoleManager.Show();
                        Console.Write("o "); //montre le chemin
                        Coordonnee c = new Coordonnee(i, j);
                        liste.Add(c);
                    }
                    else {
                        if (GetMap(i, j) == -1) // si le noeud est occupé  || arround_occupied(i, j, 5, 5))
                        {
                            ConsoleManager.Show();
                            Console.Write("X ");
                        }
                        else
                        {
                            ConsoleManager.Show();
                            Console.Write(". ");// le reste libre
                        }
                    }
                }
                ConsoleManager.Show();
                Console.WriteLine("");
            }
            return liste;
        }
    }
}