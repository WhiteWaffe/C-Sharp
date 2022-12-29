using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace CLAB2
{
    public class Room
    {
        public int number { get; set; }
        public List<string> instrument { get; set; }
        public List<string> worker_number { get; set; }
        public const int max_instrument = 10;
        public const int min_instrument = 0;
        public const int max_workers = 20;
        public const int min_workers = 0;
        public const double track_price = 80000;
        public int now_instrument { get; set; }
        public int now_worker { get; set; }

        public Room()
        {
        }

        public Room(int number, string instrument, string worker_number, int now_instrument, int now_worker)
        {
            this.number = number;
            this.instrument = new List<string>();
            this.worker_number = new List<string>();
            this.now_instrument = now_instrument;
            this.now_worker = now_worker;
            this.instrument.Add(instrument);
            this.worker_number.Add(worker_number);
        }
    }
}
