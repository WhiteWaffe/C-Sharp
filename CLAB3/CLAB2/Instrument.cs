using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLAB2
{
    public class Instrument
    {
        public string number { get; set; }
        public InstrumentType type { get; set; }
        public double price { get; set; }

        public Instrument()
        {
        }

        public Instrument(string number, InstrumentType type, double price)
        {
            this.number = number;
            this.type = type;
            this.price = price;
        }
    }

    public enum InstrumentType
    {
        Барабан,
        Басс_гитара,
        Ритм_гитара,
        Соло_гитара,
        Синтезатор,
        Фортепиано,
        Саксофон,
        Виолончель,
        Скрипка,
        Баян
    }
}
