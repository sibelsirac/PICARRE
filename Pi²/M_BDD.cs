using bin_packing_a_etoile;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pi_

{
    /// <summary>
    /// //sibel
    /// </summary>
    //lien entre visual et la base de donnée
    class M_BDD
    {
        MySqlConnection connection;
        string connectionString = "SERVER=localhost;PORT=3306;DATABASE=pi;UID=root;PASSWORD=root;";
        //connexion au serveur sql dans la base de donnée choisie 
        public M_BDD()
        {
            this.connection = new MySqlConnection(connectionString);
        }
     /*   public List<M_Plane> Verif(string Name)
        {
            connection.Open();
            List<M_Plane> liste = new List<M_Plane>();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "select * from Pilot where name=@ln"; // exemple de requete bien-sur !
            command.Parameters.AddWithValue("@ln", Name);
            MySqlDataReader reader1;
            reader1 = command.ExecuteReader();
            //parcours deux fois la ligne donc va au resultat de la deuxieme ligne de la colonne 0
            while (reader1.Read())                           // parcours ligne par ligne
            {
                int id = reader1.GetInt32(0);
                string name = reader1.GetString(1);
                string plane = reader1.GetString(2);
                int length = reader1.GetInt32(3);
                int width = reader1.GetInt32(4);
                M_Plane avion = new M_Plane(id,name, plane, length,width);
                liste.Add(avion);
            }
            connection.Close();
            return liste;
        }*/

        public M_Pilot Verif_name(string Name)
        {// cette methode est utilisé dans MV_Recherche pour rechercher un pilot associé à un nom dans la base de donnée

            connection.Open();
            
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "select * from Pilot where name=@ln"; // exemple de requete bien-sur !
            command.Parameters.AddWithValue("@ln", Name);

            MySqlDataReader reader1;
            reader1 = command.ExecuteReader();
            //parcours deux fois la ligne donc va au resultat de la deuxieme ligne de la colonne 0
            /* exemple de manipulation du resultat */
            int id = 0;
            string name = "";
            string plane = "";
            int length = 0;
            int width = 0;
            while (reader1.Read())
            {

                 id = reader1.GetInt32(0);
                 name = reader1.GetString(1);
                 plane = reader1.GetString(2);
                 length = reader1.GetInt32(3);
                 width = reader1.GetInt32(4);
            }
            M_Pilot   avion = new M_Pilot(id, name, plane, length, width);
              
            connection.Close();
            return avion;

        }
        public M_Plane Recherche_plane(int id)
        {//recherche les données ad'un avion associé à son id donné en parametre

            connection.Open();

            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "select * from Plane where id=@ln"; // exemple de requete bien-sur !
            command.Parameters.AddWithValue("@ln", id);

            MySqlDataReader reader1;
            reader1 = command.ExecuteReader();
            //parcours deux fois la ligne donc va au resultat de la deuxieme ligne de la colonne 0
            /* exemple de manipulation du resultat */
            int ido = 0;
            string name = "";
            string avion = "";
            int length = 0;
            int width = 0;
            while (reader1.Read())
            {

                ido = reader1.GetInt32(0);
                name = reader1.GetString(1);
                avion = reader1.GetString(2);
                length = reader1.GetInt32(3);
                width = reader1.GetInt32(4);
            }
            M_Plane plane = new M_Plane(ido, name, avion, length, width);

            connection.Close();
            return plane;

        }
        public M_Optimisation Recherche_Optimisation_plane(int id_plane)
        {//recherche les données ad'un avion associé à son id donné en parametre

            connection.Open();

            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "select * from Optimisation where id=@ln"; 
            command.Parameters.AddWithValue("@ln", id_plane);

            MySqlDataReader reader1;
            reader1 = command.ExecuteReader();
            //parcours deux fois la ligne donc va au resultat de la deuxieme ligne de la colonne 0
            /* exemple de manipulation du resultat */
            int x = 0;
            int y = 0;
            while (reader1.Read())
            {

                x = reader1.GetInt32(0);
               y = reader1.GetInt32(1);
              
            }
            M_Optimisation plane = new M_Optimisation(id_plane,x,y);

            connection.Close();
            return plane;

        }

        public void Add_plane(string name, string plane, int length, int width,int id_hangar)
        {//insere un avion dans la table avion
            connection.Open();
         
                string sql = "INSERT INTO plane(id,name,plane,length,width,id_hangar) VALUES('',@ln,@ln2,@ln3,@ln4,@ln5)";
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@ln", name);
                cmd.Parameters.AddWithValue("@ln2", plane);
                cmd.Parameters.AddWithValue("@ln3", length);
                cmd.Parameters.AddWithValue("@ln4", width);
            cmd.Parameters.AddWithValue("@ln5", id_hangar);
            cmd.ExecuteNonQuery();
            connection.Close();
        }
     public   int[,] tableau_avion(int id_hangar)
        {
            int x=0;
            connection.Open();

            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "select id, width, length from plane where id_hangar=@ln";
            command.Parameters.AddWithValue("@ln", id_hangar);

            MySqlDataReader reader1;
            reader1 = command.ExecuteReader();
            //parcours deux fois la ligne donc va au resultat de la deuxieme ligne de la colonne 0
            /* exemple de manipulation du resultat */
         
            while (reader1.Read())
            {
               x++;
            }
            connection.Close();
            connection.Open();

            MySqlCommand commandb = connection.CreateCommand();
            commandb.CommandText = "select id, width, length from plane where id_hangar=@ln";
            commandb.Parameters.AddWithValue("@ln", id_hangar);

            int[,] tableau = new int[x, 3];
            MySqlDataReader reader2 = commandb.ExecuteReader();
           
            int i = 0;
            while (reader2.Read())
            {
                tableau[i, 0] =reader2.GetInt32(0);
                tableau[i, 1] = reader2.GetInt32(1);
                tableau[i, 2] = reader2.GetInt32(2);
                i++;
            }


            return tableau;
        }
        public List<IMappedImageInfo> Liste_avion(int id_hangar)
        {
            int x = 0;
            ConsoleManager.Show();
            Console.WriteLine("connection non open");
            connection.Open();
            ConsoleManager.Show();
            Console.WriteLine("connection open");
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "select id, width, length from plane where id_hangar=@ln";
            command.Parameters.AddWithValue("@ln", id_hangar);

            MySqlDataReader reader1;
            reader1 = command.ExecuteReader();
            ConsoleManager.Show();
            Console.WriteLine("commande executé");
            //parcours deux fois la ligne donc va au resultat de la deuxieme ligne de la colonne 0
            /* exemple de manipulation du resultat */

            while (reader1.Read())
            {
                x++;
            }
            ConsoleManager.Show();
            Console.WriteLine(x);
            connection.Close();
            connection.Open();

            MySqlCommand commandb = connection.CreateCommand();
            commandb.CommandText = "select id, width, length, x, y from plane INNER JOIN  optimisation ON plane.id=optimisation.id_plane where optimisation.id_hangar=@ln";
            commandb.Parameters.AddWithValue("@ln", id_hangar);

            List<IMappedImageInfo> liste=new List<IMappedImageInfo>();
            MySqlDataReader reader2 = commandb.ExecuteReader();
            int l = 0;
            while (l!=x)
            {
                reader2.Read();
                ImageInfo image = new ImageInfo(reader2.GetInt32(0), reader2.GetInt32(1), reader2.GetInt32(2));
                MappedImageInfo maped = new MappedImageInfo(reader2.GetInt32(3), reader2.GetInt32(4), image);
                liste.Add(maped);
                ConsoleManager.Show();
                Console.WriteLine(reader2.GetInt32(0));
                l++;
            }


            return liste;
        }
        public void Add_optimisation(int[,] tableau , int id_hangar )
        {//
         /*  connection.Open();
           MySqlCommand command = connection.CreateCommand();
           command.CommandText = "select * from optimisation where id_hangar=@ln";
           command.Parameters.AddWithValue("@ln", id_hangar);

           MySqlDataReader reader1;
           reader1 = command.ExecuteReader();


           //rechercher l'id si il existe 


               connection.Close();*/

            // string sql = "";
            //  MySqlCommand cmd = new MySqlCommand(sql, connection);
            // si il n'existe pas le créer
            Update_Plane_Opti(id_hangar);
            for (int i = 0; i < tableau.GetLength(0); i++)
                {
                    int id_plane = tableau[i, 0];
                    int x = tableau[i, 1];
                    int y = tableau[i, 2];
                
                //System.Threading.Thread.Sleep(5000);
                Add_Plane_Opti(id_hangar, id_plane, x, y);
             /*       sql = "INSERT INTO Optimisation(id_hangar,id_plane,x,y) VALUES(@ln,@ln2,@ln3,@ln4)";
                    cmd.Parameters.AddWithValue("@ln2", id_plane);
                    cmd.Parameters.AddWithValue("@ln3", x);
                    cmd.Parameters.AddWithValue("@ln4", y);
                    cmd.ExecuteNonQuery();*/
                }
            


          
    
        }
        public void Add_Plane_Opti(int id_hangar,int id_plane ,int x, int y)
        {//insere un hangar dans la table hangar
            connection.Open();

            string sql = "INSERT INTO Optimisation(id_hangar,id_plane,x,y) VALUES(@ln,@ln2,@ln3,@ln4)";
            MySqlCommand cmd = new MySqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@ln", id_hangar);
            cmd.Parameters.AddWithValue("@ln2", id_plane);
            cmd.Parameters.AddWithValue("@ln3", x);
            cmd.Parameters.AddWithValue("@ln4", y);
   
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        public void Update_Plane_Opti(int id_hangar)
        {//insere un hangar dans la table hangar
            connection.Open();

            string sql = "DELETE from  Optimisation  WHERE id_hangar=@ln";
            MySqlCommand cmd = new MySqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@ln", id_hangar);
  

            cmd.ExecuteNonQuery();
            connection.Close();
        }
        public void Add_Hangar(string name, string city, int length, int width)
        {//insere un hangar dans la table hangar
            connection.Open();

            string sql = "INSERT INTO hangar(id,name,city,length,width) VALUES('',@ln,@ln2,@ln3,@ln4)";
            MySqlCommand cmd = new MySqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@ln", name);
            cmd.Parameters.AddWithValue("@ln2", city);
            cmd.Parameters.AddWithValue("@ln3", length);
            cmd.Parameters.AddWithValue("@ln4", width);

            cmd.ExecuteNonQuery();
            connection.Close();
        }
        public void Add_pilot(string name, string firstname, int license, int planeid)
        {//insere un pilot dans la table Pilot
            connection.Open();

            string sql = "INSERT INTO pilot(id,name,firstname,license,planeid) VALUES('',@ln,@ln2,@ln3,@ln4)";
            MySqlCommand cmd = new MySqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@ln", name);
            cmd.Parameters.AddWithValue("@ln2", firstname);
            cmd.Parameters.AddWithValue("@ln3", license);
            cmd.Parameters.AddWithValue("@ln4", planeid);

            cmd.ExecuteNonQuery();
            connection.Close();
        }



    }
}
