using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CLAB2
{
    public class Studio : ICloneable
    {
        public string name;
        public string address;
        public int workers => d_worker.Count;
        public double track_cost;
        public double track_time;
        public double one_worker_salary, all_workers_salary;
        public int instruments => l_instrument.Count;
        public int audiorooms => l_rooms.Count;
        public List<Room> l_rooms;
        public List<Instrument> l_instrument;
        public Dictionary<string, Worker> d_worker;

        public Studio(string name, string address, double track_cost, double track_time, double one_worker_salary, double all_workers_salary)
        {
            this.name = name;
            this.address = address;
            this.track_cost = track_cost;
            this.track_time = track_time;
            this.one_worker_salary = one_worker_salary;
            this.all_workers_salary = all_workers_salary;
            l_rooms = new List<Room>();
            l_instrument = new List<Instrument>();
            d_worker = new Dictionary<string, Worker>();
        }

        public Studio() { }

        public object Clone()
        {
            return new Studio { name = name, address = address, track_cost = track_cost, track_time = track_time, one_worker_salary = one_worker_salary, all_workers_salary = all_workers_salary };
        }

        public double this[int index]
        {
            get
            {
                if (index == 0)
                {
                    return this.one_worker_salary;
                }
                if (index == 1)
                {
                    return this.all_workers_salary;
                }
                throw new IndexOutOfRangeException("Неверный формат данных");
            }
        }
    }
}
