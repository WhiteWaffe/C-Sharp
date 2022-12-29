using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLAB2
{
    public class Worker
    {
        public string number { get; set; }
        public string fullname { get; set; }
        public double salary { get; set; }
        public int took_part { get; set; }

        public Worker()
        {
        }

        public Worker(string number, string fullname, double salary, int took_part)
        {
            this.number = number;
            this.fullname = fullname;
            this.salary = salary;
            this.took_part = took_part;
        }
    }
}
