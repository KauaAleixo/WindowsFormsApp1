using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Controller
{
    internal class Conection
    {
        private SqlConnection con;
        private string DataBase = "Diamond";
        private string Server = "sqlexpress";
        private string Username = "aluno";
        private string Password = "aluno";

        public Conection()
        {
            string stringConection =
                @"Data Source = " + Server
                + "; Initial Catalog = " + DataBase
                + "; User Id = " + Username
                + "; Password =" + Password
                + "; Encrypt = false";

            con = new SqlConnection(stringConection);
            con.Open(); //Abrir a aconexão com o banco



        }

        // Tentafechar a aconexão com o banco 

        public void CloseConection()
        {
            if (con.State == System.Data.ConnectionState.Open)
                con.Close();

        }
        // Retorna a conexão que foi aberta 
        public SqlConnection ReturnConection()
        {
            return con;
        }
        }
    }

