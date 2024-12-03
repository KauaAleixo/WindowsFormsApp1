using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
    
{
    internal class Broker
    {
        internal object BrokerSuite;
        internal object BrokerChale;
        internal object BrokerPreco;

        public int Id { get; set; }
        public string Brokerchale { get; private set; }
        public string BrokerCode { get; private set; }
        public string Brokersuite { get; private set; }
        public string Brokerpreco { get; private set; }

        public Broker(int v, string brokerCode, string BrokerChale, string v1)
        {
            BrokerCode = brokerCode;
            Brokerchale = BrokerChale;
            Brokersuite= (string)BrokerSuite;
            Brokerpreco = (string)BrokerPreco;


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
            
            BrokerCode = brokerCode;
            
            
        }
    }
}