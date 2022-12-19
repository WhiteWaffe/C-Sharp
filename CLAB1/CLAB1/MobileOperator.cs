using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLAB1
{
    internal class MobileOperator
    {
        public string title, number;
        public double cost, balance;
        public string[] history;
        public struct Services
        {
            public Service service_title;
            public double service_cost;

            public Services(Service service_title1, double service_cost1)
            {
                service_title = service_title1;
                service_cost = service_cost1;
            }
        };

        public MobileOperator()
        {
        }

        public MobileOperator(string title, string number, double cost, double balance)
        {
            this.title = title;
            this.number = number;
            this.cost = cost;
            this.balance = balance;
        }
    }
}
