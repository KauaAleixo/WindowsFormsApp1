﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1

    
{
    internal class BrokerDAO
    {
        private Connection Connect { get; set; }
        private SqlCommand Command { get; set; }
        //Sempre o nome da classe
        public BrokerDAO() //método construtor
        {
            Connect = new Connection();
            Command = new SqlCommand();
        }
        public bool Insert(Broker broker)
        {
            Command.Connection = Connect.ReturnConnection();
            Command.CommandText =
            @"INSERT INTO 
            Broker VALUES 
            ( @brokerCode,@brokerPreco,@brokerChale,@brokerSuite)";

            Command.Parameters.AddWithValue("@brokerSuite", broker.BrokerSuite);

            Command.Parameters.AddWithValue("@brokerChale", broker.BrokerChale);
            
            

            try
            {
                //Executa query definida acima.
                Command.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                throw new Exception("Erro: Problemas ao inserir " +
                    "corretor no banco.\n" + err.Message);
            }
            finally
            {
                Connect.CloseConnection();
            }
            return true;
        }


        public void Update(Broker broker)
        {
            Command.Connection = Connect.ReturnConnection();
            Command.CommandText = @"UPDATE Broker SET 
            BrokerChale = @brokerChale,
            BrokerCode = @brokerCode,
            BrokerSuite = @brokerSuite,
            BrokerPreco = @brokerPreco,
            WHERE Id = @id";

            Command.Parameters.AddWithValue("@id", broker.Id);
            Command.Parameters.AddWithValue("@brokerSuite", broker.BrokerSuite);
            Command.Parameters.AddWithValue("@brokerCode", broker.BrokerCode);
          
            Command.Parameters.AddWithValue("@brokerPreco", broker.BrokerPreco);

            try
            {
                Command.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                throw new Exception("Erro: " +
                    "Problemas ao realizar atualização dos dados do " +
                    "corretor no banco.\n" + err.Message);
            }
            finally
            {
                Connect.CloseConnection();
            }
        }

        public void Delete(int brokerCode)
        {
            Command.Connection = Connect.ReturnConnection();
            Command.CommandText = @"DELETE FROM Broker 
            WHERE Id = @brokerCode";
            Command.Parameters.AddWithValue("@brokerCode", brokerCode);
            try
            {
                Command.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                throw new Exception("Erro: Problemas ao excluir " +
                    "cadastro do corretor do banco.\n" + err.Message);
            }
            finally
            {
                Connect.CloseConnection();
            }
        }
        public List<Broker> ListAllBrokers()
        {

            Command.Connection = Connect.ReturnConnection();
            Command.CommandText = "SELECT * FROM Broker";

            List<Broker> brokers = new List<Broker>(); //Instancio a list com o tamanho padrão.
            try
            {
                SqlDataReader rd = Command.ExecuteReader();

                //Enquanto for possível continuar a leitura das linhas que foram retornadas na consulta, execute.
                while (rd.Read())
                {
                    Broker broker = new Broker(
                        (int)rd["Id"],
                        (string)rd["BrokerChale"],
                        (string)rd["BrokerSuite"],
                        (string)rd["BrokerPreco"]
                        );
                    brokers.Add(broker);
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

            return brokers;
        }
        public bool ValidateLogin(Broker broker)
        {

            Command.Connection = Connect.ReturnConnection();
            Command.CommandText = "SELECT * FROM Broker WHERE " +
                                  "BrokerCode = @brokerCode AND " +
                                  "Chale = @brokerChale" +"Suite = @brokerSuite" + "Preco = @brokerPreco";
            Command.Parameters.AddWithValue("@brokerCode", broker.BrokerCode);
            ;
            Command.Parameters.AddWithValue("@brokerChale", broker.BrokerChale);
            Command.Parameters.AddWithValue("@brokerSuite", broker.BrokerSuite);
            Command.Parameters.AddWithValue("@brokerPreco", broker.BrokerPreco);

            try
            {
                SqlDataReader rd = Command.ExecuteReader();
                if (rd.HasRows)
                {
                    rd.Close();
                    return true;
                }
            }
            catch (Exception err)
            {
                throw new Exception("Erro: Problemas ao realizar " +
                    "leitura de dados do corretor no banco.\n" + err.Message);
            }
            finally
            {
                Connect.CloseConnection();
            }

            return false;
        }
    }
}