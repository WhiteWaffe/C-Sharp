using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CLAB2
{
    public partial class Form3 : Form
    {
        public Form1 oneform { get; set; }
        public Studio AUDIO1 { get; set; }
        public List<Room> Rooms { get; set; }
        public List<Instrument> Instruments { get; set; }
        public List<Worker> Workers { get; set; }

        public Form3(Form1 form1, Studio AUDIO, List<Room> Rooms, List<Instrument> Instruments, List<Worker> Workers)
        {
            this.oneform = form1;
            this.AUDIO1 = this.oneform.AUDIO;
            this.Rooms = this.oneform.Rooms;
            this.Instruments = this.oneform.Instruments;
            this.Workers = this.oneform.Workers;
            InitializeComponent();
        }

        private void Form3_Load_1(object sender, EventArgs e)
        {
            PrintAll1();
        }

        private void PrintAll1()
        {
            dataGridView1.Rows.Clear();
            foreach (var instrument in Instruments)
            {
                dataGridView1.Rows.Add(instrument.number, instrument.type, instrument.price);
            }
            dataGridView2.Rows.Clear();
            foreach (var worker in Workers)
            {
                dataGridView2.Rows.Add(worker.number, worker.fullname, worker.salary, worker.took_part);
            }
            dataGridView3.Rows.Clear();
            foreach (var room in Rooms)
            {
                string str = "";
                foreach (var inst in room.instrument)
                {
                    str += inst + " , ";
                }
                string str1 = "";
                foreach (var worknum in room.worker_number)
                {
                    str1 += worknum + " , ";
                }
                dataGridView3.Rows.Add(room.number, str, str1, Room.max_instrument, Room.min_instrument, Room.max_workers, Room.min_workers, room.now_instrument, room.now_worker);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Instrument instrument1 = new Instrument();
            try
            {
                if (String.IsNullOrWhiteSpace(TBinstrumentnumber.Text.ToString()) || String.IsNullOrWhiteSpace(CBtype.Text.ToString()) || String.IsNullOrWhiteSpace(TBprice.Text.ToString()) ||
                    Convert.ToInt32(TBprice.Text) < 0 || !TBinstrumentnumber.Text.All(char.IsNumber))
                {
                    MessageBox.Show("Ошибка!", "Ошибка");
                    return;
                }
                switch (CBtype.Text)
                {
                    case "Барабан":
                        instrument1.type = InstrumentType.Барабан;
                        break;
                    case "Басс_гитара":
                        instrument1.type = InstrumentType.Басс_гитара;
                        break;
                    case "Ритм_гитара":
                        instrument1.type = InstrumentType.Ритм_гитара;
                        break;
                    case "Соло_гитара":
                        instrument1.type = InstrumentType.Соло_гитара;
                        break;
                    case "Синтезатор":
                        instrument1.type = InstrumentType.Синтезатор;
                        break;
                    case "Фортепиано":
                        instrument1.type = InstrumentType.Фортепиано;
                        break;
                    case "Саксофон":
                        instrument1.type = InstrumentType.Саксофон;
                        break;
                    case "Виолончель":
                        instrument1.type = InstrumentType.Виолончель;
                        break;
                    case "Скрипка":
                        instrument1.type = InstrumentType.Скрипка;
                        break;
                    case "Баян":
                        instrument1.type = InstrumentType.Баян;
                        break;
                    default:
                        MessageBox.Show("Ошибка!", "Ошибка");
                        break;
                }
                instrument1.number = TBinstrumentnumber.Text;
                instrument1.price = Convert.ToDouble(TBprice.Text);
                instrument1.number = TBinstrumentnumber.Text;
                foreach (var instrument in Instruments)
                {
                    if (instrument1.number == instrument.number)
                    {
                        MessageBox.Show("Номер занят!", "Ошибка");
                        return;
                    }
                }
                Instruments.Add(instrument1);
                PrintAll1();
            }
            catch
            {
                MessageBox.Show("Ошибка!", "Ошибка");
            }
        }

        private void GetInstrument(string number)
        {
            try
            {
                foreach (var instrument in Instruments)
                {
                    if (TBinstrumentnumber.Text == instrument.number)
                    {
                        label11.Text = instrument.type + " номер " + instrument.number + " стоимостью " + instrument.price;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Ошибка!", "Ошибка");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            GetInstrument(TBinstrumentnumber.Text);
        }

        private void WorkerToFile1()
        {
            File.CreateText($"Studio\\Workers.txt").Close();
            foreach (var worker2 in Workers)
            {
                File.AppendAllText($"Studio\\Workers.txt",
                $"{worker2.number} " +
                $"{worker2.fullname} " +
                $"{worker2.salary} " +
                $"{worker2.took_part}");
                File.AppendAllText($"Studio\\Workers.txt", $"\n");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Worker worker1 = new Worker();
            try
            {
                if (String.IsNullOrWhiteSpace(TBpersonnumber.Text.ToString()) || String.IsNullOrWhiteSpace(TBfio.Text.ToString()) || String.IsNullOrWhiteSpace(TBsalary.Text.ToString()) ||
                    Convert.ToInt32(TBsalary.Text) < 0 || String.IsNullOrWhiteSpace(TBtookpart.Text.ToString()) || Convert.ToInt32(TBtookpart.Text) < 0 || !TBpersonnumber.Text.All(char.IsNumber) || TBpersonnumber.Text.Length != 12)
                {
                    MessageBox.Show("Ошибка!", "Ошибка");
                    return;
                }
                worker1.number = TBpersonnumber.Text;
                worker1.fullname = TBfio.Text;
                worker1.salary = Convert.ToDouble(TBsalary.Text);
                worker1.took_part = Convert.ToInt32(TBtookpart.Text);
                foreach (var worker in Workers)
                {
                    if (worker1.number == worker.number)
                    {
                        MessageBox.Show("Номер занят!", "Ошибка");
                        return;
                    }
                }
                Workers.Add(worker1);
                WorkerToFile1();
                PrintAll1();
            }
            catch
            {
                MessageBox.Show("Ошибка!", "Ошибка");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (var worker in Workers)
                {
                    if (TBpersonnumber.Text == worker.number)
                    {
                        Workers.Remove(worker);
                        PrintAll1();
                        return;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Ошибка!", "Ошибка");
            }
        }

        private void GetWorker()
        {
            try
            {
                foreach (var worker in Workers)
                {
                    if (TBpersonnumber.Text == worker.number)
                    {
                        label12.Text = worker.fullname + " номер " + worker.number + " зарплата " + worker.salary + " участий в треках " + worker.took_part;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Ошибка!", "Ошибка");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            GetWorker();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (var room in Rooms)
                {
                    if (Convert.ToInt32(TBroomnumber.Text) == room.number)
                    {
                        Rooms.Remove(room);
                        PrintAll1();
                        return;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Ошибка!", "Ошибка");
            }
        }

        private void RoomToFile1()
        {
            File.CreateText($"{AUDIO1.name}.txt").Close();
            File.AppendAllText($"{AUDIO1.name}.txt", $"{AUDIO1.name} | {AUDIO1.address} | {AUDIO1.workers} | {AUDIO1.track_cost} | {AUDIO1.track_time} | {AUDIO1.one_worker_salary} | {AUDIO1.all_workers_salary} | {AUDIO1.instruments} | {AUDIO1.audiorooms}");
            foreach (var room in Rooms)
            {
                File.AppendAllText($"{AUDIO1.name}.txt", $"\n{room.number}\n");
                foreach (var inst in room.instrument)
                {
                    File.AppendAllText($"{AUDIO1.name}.txt", $"{inst} ");
                }
                File.AppendAllText($"{AUDIO1.name}.txt", $"\n");
                foreach (var num in room.worker_number)
                {
                    File.AppendAllText($"{AUDIO1.name}.txt", $"{num} ");
                }
                File.AppendAllText($"{AUDIO1.name}.txt", $"\n");
                File.AppendAllText($"{AUDIO1.name}.txt", $"{Room.max_instrument} " + $"{Room.min_instrument} " + $"{Room.max_workers} " + $"{Room.min_workers} " + $"{Room.track_price} " + $"{room.now_instrument} " + $"{room.now_worker} ");
                File.AppendAllText($"{AUDIO1.name}.txt", $"\n");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Room room1 = new Room();
            try
            {
                if (String.IsNullOrWhiteSpace(TBroomnumber.Text.ToString()))
                {
                    MessageBox.Show("Ошибка!", "Ошибка");
                    return;
                }
                room1.number = Convert.ToInt32(TBroomnumber.Text);
                room1.instrument = new List<string>();
                room1.instrument.Add("");
                room1.worker_number = new List<string>();
                room1.worker_number.Add("");
                room1.now_instrument = 0;
                room1.now_worker = 0;
                Rooms.Add(room1);
                RoomToFile1();
                PrintAll1();
            }
            catch
            {
                MessageBox.Show("Ошибка!", "Ошибка");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            foreach (var room in Rooms)
            {
                foreach (var num in room.instrument)
                {
                    if (num == textBox1.Text)
                    {
                        MessageBox.Show("Этот инструмент уже есть в комнате!", "Ошибка");
                        return;
                    }
                }
            }
            foreach (var room in Rooms)
            {
                foreach (var instrument in Instruments)
                {
                    try
                    {
                        if (room.number == Convert.ToInt32(TBroomnumber.Text) && instrument.number == textBox1.Text)
                        {
                            if (room.now_instrument + 1 > Room.max_instrument)
                            {
                                MessageBox.Show("Нет места для инструментов!", "Ошибка");
                                return;
                            }
                            room.instrument.Add(instrument.number);
                            room.now_instrument++;
                            RoomToFile1();
                            PrintAll1();
                            return;
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка!", "Ошибка");
                    }
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            foreach (var room in Rooms)
            {
                foreach (var instrument in Instruments)
                {
                    try
                    {
                        if (room.number == Convert.ToInt32(TBroomnumber.Text) && textBox1.Text == instrument.number)
                        {
                            if (room.now_instrument - 1 < 0)
                            {
                                MessageBox.Show("В комнате нет инструментов!", "Ошибка");
                                return;
                            }
                            if (Room.max_instrument >= room.now_instrument)
                            {
                                room.now_instrument--;
                                room.instrument.Remove(instrument.number);
                                RoomToFile1();
                                PrintAll1();
                                return;
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка!", "Ошибка");
                    }
                }
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            foreach (var room in Rooms)
            {
                foreach (var num in room.worker_number)
                {
                    if (num == textBox2.Text)
                    {
                        MessageBox.Show("Этот работник уже есть в комнате!", "Ошибка");
                        return;
                    }
                }
            }
            foreach (var room in Rooms)
            {
                foreach (var worker in Workers)
                {
                    try
                    {
                        if (room.number == Convert.ToInt32(TBroomnumber.Text) && worker.number == textBox2.Text)
                        {
                            if (room.now_worker + 1 > Room.max_workers)
                            {
                                MessageBox.Show("Нет места для рабочих!", "Ошибка");
                                return;
                            }
                            room.worker_number.Add(worker.number);
                            room.now_worker++;
                            RoomToFile1();
                            PrintAll1();
                            return;
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка!", "Ошибка");
                    }
                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            foreach(var room in Rooms)
            {
                foreach (var worker in Workers)
                {
                    try
                    {
                        if (room.number == Convert.ToInt32(TBroomnumber.Text) && textBox2.Text == worker.number)
                        {
                            if (room.now_worker - 1 < 0)
                            {
                                MessageBox.Show("В комнате нет рабочих!", "Ошибка");
                                return;
                            }
                            if (Room.max_workers >= room.now_worker)
                            {
                                room.now_worker--;
                                room.worker_number.Remove(worker.number);
                                RoomToFile1();
                                PrintAll1();
                                return;
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка!", "Ошибка");
                    }
                }
            }
        }
    }
}
