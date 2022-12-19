using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CLAB2
{
    public class Studio : ICloneable
    {
        public string name;
        public string address;
        public int workers;
        public double track_cost;
        public double track_time;
        public double one_worker_salary, all_workers_salary;
        public int instruments;
        public int audiorooms;

        public Studio(string name, string address, int workers, double track_cost, double track_time, double one_worker_salary, double all_workers_salary, int instruments, int audiorooms)
        {
            this.name = name;
            this.address = address;
            this.workers = workers;
            this.track_cost = track_cost;
            this.track_time = track_time;
            this.one_worker_salary = one_worker_salary;
            this.all_workers_salary = all_workers_salary;
            this.instruments = instruments;
            this.audiorooms = audiorooms;
        }

        public Studio() { }

        public object Clone()
        {
            return new Studio { name = name, address = address, workers = workers, track_cost = track_cost, track_time = track_time, one_worker_salary = one_worker_salary, all_workers_salary = all_workers_salary, instruments = instruments, audiorooms = audiorooms };
        }
    }
}
