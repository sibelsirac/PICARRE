using System;
using System.Collections;
using Tanis.Collections;
using bin_packing_a_etoile;
using System.Collections.Generic;

namespace Games.Pathfinding.AStar2DTest
{

    /// <summary>
    /// A node class for doing pathfinding on a 2-dimensional map
    /// </summary>
    public class AStarNode2D:AStarNode
    {
        #region Properties

        /// <summary>
        /// The X-coordinate of the node
        /// </summary>
        public int X
        {
            get
            {
                return FX;
            }

        }
       
        private int FX;

        /// <summary>
        /// The Y-coordinate of the node
        /// </summary>
        public int Y
        {
            get
            {
                return FY;
            }
        }
        private int FY;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor for a node in a 2-dimensional map
        /// </summary>
        /// <param name="AParent">Parent of the node</param>
        /// <param name="AGoalNode">Goal node</param>
        /// <param name="ACost">Accumulative cost</param>
        /// <param name="AX">X-coordinate</param>
        /// <param name="AY">Y-coordinate</param>
        public AStarNode2D(AStarNode AParent, AStarNode AGoalNode, double ACost, int AX, int AY) : base(AParent, AGoalNode, ACost)
        {
            FX = AX;
            FY = AY;
        }
        public AStarNode P
        {
            get
            {
                return base.Parent;
            }
        }
        #endregion

        #region Private Methods

        /// <summary>
        /// Adds a successor to a list if it is not impassible or the parent node
        /// </summary>
        /// <param name="ASuccessors">List of successors</param>
        /// <param name="AX">X-coordinate</param>
        /// <param name="AY">Y-coordinate</param>
        private void AddSuccessor(ArrayList ASuccessors, int AX, int AY)
        {
            int CurrentCost = MainClass.GetMap(AX, AY);
            if (CurrentCost == -1)
            {
                return;
            }
            AStarNode2D NewNode = new AStarNode2D(this, GoalNode, Cost + CurrentCost, AX, AY);
            if (NewNode.IsSameState(Parent))
            {
                return;
            }
            ASuccessors.Add(NewNode);
        }

        #endregion

        #region Overidden Methods

        /// <summary>
        /// Determines wheather the current node is the same state as the on passed.
        /// </summary>
        /// <param name="ANode">AStarNode to compare the current node to</param>
        /// <returns>Returns true if they are the same state</returns>
        public override bool IsSameState(AStarNode ANode)
        {
            if (ANode == null)
            {
                return false;
            }
            return ((((AStarNode2D)ANode).X == FX) &&
                (((AStarNode2D)ANode).Y == FY));
        }

        /// <summary>
        /// Calculates the estimated cost for the remaining trip to the goal.
        /// </summary>
        public override void Calculate()
        {
            if (GoalNode != null)
            {
                double xd = FX - ((AStarNode2D)GoalNode).X;
                double yd = FY - ((AStarNode2D)GoalNode).Y;
                // "Euclidean distance" - Used when search can move at any angle.
                //GoalEstimate = Math.Sqrt((xd*xd) + (yd*yd));
                // "Manhattan Distance" - Used when search can only move vertically and 
                // horizontally.
                //GoalEstimate = Math.Abs(xd) + Math.Abs(yd); 
                // "Diagonal Distance" - Used when the search can move in 8 directions.
                GoalEstimate = Math.Max(Math.Abs(xd), Math.Abs(yd));
            }
            else
            {
                GoalEstimate = 0;
            }
        }

        /// <summary>
        /// Gets all successors nodes from the current node and adds them to the successor list
        /// </summary>
        /// <param name="ASuccessors">List in which the successors will be added</param>
        public int GetMap(int x, int y)
        {
            if ((x < 0) || (x > Map.GetLength(0)))

                return (-1);
            if ((y < 0) || (y > Map.GetLength(1)))
                return (-1);
            return (Map[y, x]);
        }
        public static Main_bin_packing mainb = new Main_bin_packing();
        int[,] Map = mainb.Transformed();
        public bool arround_occupied(int x, int y, int width, int height)
        {
            bool booln = false;
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (x > 0 && y - j > 0 && x < Map.GetLength(0) && y - j < Map.GetLength(1))
                    {
                        if (GetMap(x, y - j) == -1)
                        {
                            booln = true;
                        }
                    }
                    if (x > 0 && y + j > 0 && x < Map.GetLength(0) && y + j < Map.GetLength(1))
                    {
                        if (GetMap(x, y + j) == -1)
                        {
                            booln = true;
                        }
                    }
                    if (x - i > 0 && y > 0 && x - i < Map.GetLength(0) && y < Map.GetLength(1))
                    {
                        if (GetMap(x - i, y) == -1)
                        {
                            booln = true;
                        }
                    }
                    if (x + i > 0 && y > 0 && x + i < Map.GetLength(0) && y < Map.GetLength(1))
                    {
                        if (GetMap(x + i, y) == -1)
                        {
                            booln = true;
                        }
                    }
                    if (x - i > 0 && y - j > 0 && x - i < Map.GetLength(0) && y - j < Map.GetLength(1))
                    {
                        if (GetMap(x - i, y - j) == -1)
                        {
                            booln = true;
                        }
                    }
                    if (x - i > 0 && y + j > 0 && x - i < Map.GetLength(0) && y + j < Map.GetLength(1))
                    {
                        if (GetMap(x - i, y + j) == -1)
                        {
                            booln = true;
                        }
                    }
                    if (x + i > 0 && y - j > 0 && x + i < Map.GetLength(0) && y - j < Map.GetLength(1))
                    {
                        if (GetMap(x + i, y - j) == -1)
                        {
                            booln = true;
                        }
                    }
                    if (x + i > 0 && y + j > 0 && x + i < Map.GetLength(0) && y + j < Map.GetLength(1))
                    {
                        if (GetMap(x + i, y + j) == -1)
                        {
                            booln = true;
                        }
                    }


                }

            }

            return booln;
        }
        public override void GetSuccessors(ArrayList ASuccessors)
        {// espace
            int x = 3;
            int y = 3;
            ASuccessors.Clear();
            if(arround_occupied(FX-1, FY, x, y) == false)
            {
                AddSuccessor(ASuccessors, FX - 1, FY);
            }
           
            if (arround_occupied(FX - 1, FY-1, x, y) == false)
            {
                AddSuccessor(ASuccessors, FX - 1, FY - 1);
            }
            if (arround_occupied(FX, FY - 1, x, y) == false)
            {
                AddSuccessor(ASuccessors, FX, FY - 1);
            }
            if (arround_occupied(FX + 1, FY-1, x, y) == false)
            {
                AddSuccessor(ASuccessors, FX + 1, FY - 1);
            }
            if (arround_occupied(FX + 1, FY, x, y) == false)
            {
                AddSuccessor(ASuccessors, FX + 1, FY);
            }
            if (arround_occupied(FX + 1, FY+1, x, y) == false)
            {
                AddSuccessor(ASuccessors, FX + 1, FY + 1);
            }
            if (arround_occupied(FX, FY+1, x, y) == false)
            {
                AddSuccessor(ASuccessors, FX, FY + 1);
            }
            if (arround_occupied(FX - 1, FY+1, x, y) == false)
            {
                AddSuccessor(ASuccessors, FX - 1, FY + 1);
            }
        }

        /// <summary>
        /// Prints information about the current node
        /// </summary>
        public override void PrintNodeInfo()
        {
            Console.WriteLine("X:\t{0}\tY:\t{1}\tCost:\t{2}\tEst:\t{3}\tTotal:\t{4}", FX, FY, Cost, GoalEstimate, TotalCost);
        }

        #endregion
    }

    /// <summary>
    /// Test class for doing A* pathfinding on a 2D map.
    /// </summary>
    class MainClass
    {
        #region Test Maps
        public static Main_bin_packing mainb = new Main_bin_packing();
      static  int[,] Map = mainb.Transformed();

        static int[,] Mapb = {
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
        //		static int[,] Map = {
        //			{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
        //			{ 1, 1, 1, 1, 1, 1, 1, 1,-1, 1 },
        //			{ 1, 1, 1, 1, 1, 1, 1, 1,-1, 1 },
        //			{ 1, 1, 1, 1, 1, 1, 1, 1,-1, 1 },
        //			{ 1, 1, 1, 1, 1, 1, 1, 1,-1, 1 },
        //			{ 1, 1, 1, 1, 1, 1, 1, 1,-1, 1 },
        //			{ 1, 1, 1, 1, 1, 1, 1, 1,-1, 1 },
        //			{ 1, 1, 1, 1, 1, 1, 1, 1,-1, 1 },
        //			{ 1,-1,-1,-1,-1,-1,-1,-1,-1, 1 },
        //			{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }
        //		};
        //		static int[,] Map = {
        //			{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
        //			{ 1, 1, 1, 1, 1, 2, 1, 1, 1, 1 },
        //			{ 1, 1, 1, 1, 2, 3, 2, 1, 1, 1 },
        //			{ 1, 1, 1, 2, 3, 4, 3, 2, 1, 1 },
        //			{ 1, 1, 2, 3, 4, 5, 4, 3, 2, 1 },
        //			{ 1, 1, 1, 2, 3, 4, 3, 2, 1, 1 },
        //			{ 1, 1, 1, 1, 2, 3, 2, 1, 1, 1 },
        //			{ 1, 1, 1, 1, 1, 2, 1, 1, 1, 1 },
        //			{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
        //			{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }
        //		};

        #endregion

        #region Public Methods

        /// <summary>
        /// Gets movement cost from the 2-dimensional map
        /// </summary>
        /// <param name="x">X-coordinate</param>
        /// <param name="y">Y-coordinate</param>
        /// <returns>Returns movement cost at the specified point in the map</returns>
        static public int GetMap(int x, int y)
        {
            if ((x < 0) || (x > Map.GetLength(0)))
                return (-1);
            if ((y < 0) || (y > Map.GetLength(1)))
                return (-1);
            return (Map[y, x]);
        }

        /// <summary>
        /// Prints the solution
        /// </summary>
        /// <param name="ASolution">The list that holds the solution</param>
    
        static public  List<Coordonnee>  PrintSolution(ArrayList ASolution)
        {
            List<Coordonnee> liste= new List<Coordonnee>();
            ConsoleManager.Show();
            Console.WriteLine(Map.GetLength(0));
            ConsoleManager.Show();
           
            for (int j = 0; j < Map.GetLength(0); j++)
            {
                for (int i = 0; i <Map.GetLength(1); i++)
                {
                  
                    bool solution = false;
                    foreach (AStarNode2D n in ASolution)
                    {
                        AStarNode2D tmp = new AStarNode2D(null, null, 0, i, j);
                        solution = n.IsSameState(tmp);
                        if (solution)
                            break;
                    }
                    if (solution)
                    {
                        ConsoleManager.Show();
                        Console.Write("o ");
                        Coordonnee c = new Coordonnee(i, j);
                        liste.Add(c);

                    } //montre le chemin


                    else
                        if (MainClass.GetMap(i, j) == -1)
                    {// si le noeud est occupé
                        ConsoleManager.Show();
                        Console.Write("X ");
                    }
                    else
                    {
                        ConsoleManager.Show();
                        Console.Write(". ");
                    }// le reste libre
                }
                Console.WriteLine("");
            }
            return liste;
        }

        
      

      
    }
}
#endregion