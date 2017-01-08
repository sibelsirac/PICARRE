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


        public void Add_plane(string name, string plane, int length, int width)
        {//insere un avion dans la table avion
            connection.Open();
         
                string sql = "INSERT INTO plane(id,name,plane,length,width) VALUES('',@ln,@ln2,@ln3,@ln4)";
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@ln", name);
                cmd.Parameters.AddWithValue("@ln2", plane);
                cmd.Parameters.AddWithValue("@ln3", length);
                cmd.Parameters.AddWithValue("@ln4", width);
             
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
