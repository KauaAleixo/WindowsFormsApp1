using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class UsuárioDAO
    {
        private Connection Connect { get; set; }
        private SqlCommand Command { get; set; }
        public object Nome { get; private set; }
        public object Senha { get; private set; }

        //Sempre o nome da classe
        public UsuárioDAO(int v, string v1) //método construtor
        {
            Connect = new Connection();
            Command = new SqlCommand();
        }

        public UsuárioDAO(int v, string v1, string v2, float v3) : this(v, v1)
        {
        }

        public void Insert(UsuárioDAO prop)
        {
            Command.Connection = Connect.ReturnConnection();
            Command.CommandText =
            @"INSERT INTO 
            Property VALUES 
            (@nome @senha)";

            Command.Parameters.AddWithValue("@nome", prop.Nome);
            Command.Parameters.AddWithValue("@senha", prop.Senha);
       

            try
            {
                //Executa query definida acima.
                Command.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                throw new Exception("Erro: Problemas ao inserir " +
                    "imóvel no banco.\n" + err.Message);
            }
            finally
            {
                Connect.CloseConnection();
            }
        }


        public void Update(UsuárioDAO prop)
        {
            Command.Connection = Connect.ReturnConnection();
            Command.CommandText = @"UPDATE Property SET 
            (@nome @senha)";

            Command.Parameters.AddWithValue("@nome", prop.Nome);
            Command.Parameters.AddWithValue("@senha", prop.Senha);

            try
            {
                Command.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                throw new Exception("Erro: " +
                    "Problemas ao realizar atualização de " +
                    "imóvel no banco.\n" + err.Message);
            }
            finally
            {
                Connect.CloseConnection();
            }
        }

        public void Delete(int codProperty)
        {
            Command.Connection = Connect.ReturnConnection();
            Command.CommandText = @"DELETE FROM Property 
            WHERE CodProperty = @code";
            Command.Parameters.AddWithValue("@code", codProperty);
            try
            {
                Command.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                throw new Exception("Erro: Problemas ao excluir " +
                    "imóvel no banco.\n" + err.Message);
            }
            finally
            {
                Connect.CloseConnection();
            }
        }
        public List<UsuárioDAO> ListAllProperties()
        {

            Command.Connection = Connect.ReturnConnection();
            Command.CommandText = "SELECT * FROM Property";

            List<UsuárioDAO> props = new List<UsuárioDAO>(); //Instancio a list com o tamanho padrão.
            try
            {
                SqlDataReader rd = Command.ExecuteReader();

                //Enquanto for possível continuar a leitura das linhas que foram retornadas na consulta, execute.
                while (rd.Read())
                {
                    UsuárioDAO prop = new UsuárioDAO(
                        (int)rd["CodProperty"],
                        (string)rd["Objective"],
                        (string)rd["City"],
                        (float)rd["Price"]
                        );
                    props.Add(prop);
                }
                rd.Close();
            }
            catch (Exception err)
            {
                throw new Exception("Erro: Problemas ao realizar " +
                    "leitura de imóveis no banco.\n" + err.Message);
            }
            finally
            {
                Connect.CloseConnection();
            }

            return props;
        }

    }
}