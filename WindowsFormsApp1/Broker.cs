using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
    
{
    internal class Broker
    {
        public int Id { get; set; }
        public string BrokerName { get; private set; }
        public string BrokerCode { get; private set; }
        public string Password { get; private set; }

        public Broker(int v, string brokerCode, string password, string v1)
        {
            BrokerCode = brokerCode;
            Password = password;
        }

        public Broker(int id, string brokerName, string brokerCode,
            string state, int codeArea, string telephone, string email,
            string password) : this(brokerName, brokerCode, state, codeArea,
            telephone, email, password)
        {
            Id = id;
        }

        public Broker(string brokerName, string brokerCode,
            string state, int codeArea, string telephone, string email, string password)
        {
            BrokerName = brokerName;
            BrokerCode = brokerCode;
            
            Password = password;
        }
    }
}