using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    internal class Usuário

    {
        public int CodClientes { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }


        public Usuário(int codClientes, string nome,
            string senha) : this(nome, senha)
        {
            CodClientes = codClientes;
        }

        public Usuário(string nome,
                        string senha)
                        
        {
            Nome = nome;
            Senha = senha ?? throw new ArgumentNullException(nameof(senha));
           
        }

        public Usuário (int codProperty, string city)
        {
            CodClientes = codProperty;
           
        }
    }
}
