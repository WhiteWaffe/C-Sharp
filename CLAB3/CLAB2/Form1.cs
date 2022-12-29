using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CLAB2
{
    public partial class Form1 : Form
    {
        public Studio AUDIO = new Studio("D&G Audio", "ул.Тараса Шевченка, 23", 200000, 7, 10000, 300000);
        public List<Room> Rooms { get; set; }
        public List<Instrument> Instruments { get; set; }
        public List<Worker> Workers { get; set; }

        public Form1()
        {
            Rooms = new List<Room>();
            Instruments = new List<Instrument>();
            Workers = new List<Worker>();
            InitializeComponent();
        }

        private void PrintAll()
        {
            AUDIO.l_rooms = Rooms;
            AUDIO.l_instrument = Instruments;
            AUDIO.d_worker = Workers.ToDictionary(x => x.number);
            dataGridView1.Rows.Clear();
            dataGridView1.Rows.Add(AUDIO.name, AUDIO.address, AUDIO.workers, AUDIO.track_cost, AUDIO.track_time, AUDIO.one_worker_salary, AUDIO.all_workers_salary, AUDIO.instruments, AUDIO.audiorooms);
        }

        private void RoomToFile()
        {
            foreach (var room in Rooms)
            {
                File.AppendAllText($"Studio\\{AUDIO.name}.txt", $"{room.number}");
                foreach (var inst in room.instrument)
                {
                    File.AppendAllText($"Studio\\{AUDIO.name}.txt", $"{inst} ");
                }
                File.AppendAllText($"Studio\\{AUDIO.name}.txt", $"\n");
                foreach (var num in room.worker_number)
                {
                    File.AppendAllText($"Studio\\{AUDIO.name}.txt", $"{num} ");
                }
                File.AppendAllText($"Studio\\{AUDIO.name}.txt", $"\n");
                File.AppendAllText($"Studio\\{AUDIO.name}.txt", $"{Room.max_instrument} " + $"{Room.min_instrument} " + $"{Room.max_workers} " + $"{Room.min_workers} " + $"{Room.track_price} " + $"{room.now_instrument} " + $"{room.now_worker} ");
                File.AppendAllText($"Studio\\{AUDIO.name}.txt", $"\n");
            }
        }

        private void WorkerToFile()
        {
            foreach (var worker in Workers)
            {
                File.AppendAllText($"Studio\\Workers.txt",
                $"{worker.number} " +
                $"{worker.fullname} " +
                $"{worker.salary} " +
                $"{worker.took_part}");
                File.AppendAllText($"Studio\\Workers.txt", $"\n");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Directory.CreateDirectory($"Studio");
            File.AppendAllText($"{AUDIO.name}.txt", $"{AUDIO.name} | {AUDIO.address} | {AUDIO.workers} | {AUDIO.track_cost} | {AUDIO.track_time} | {AUDIO.one_worker_salary} | {AUDIO.all_workers_salary} | {AUDIO.instruments} | {AUDIO.audiorooms}");
            RoomToFile();
            WorkerToFile();
            PrintAll();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 form2 = new Form3(this, AUDIO, Rooms, Instruments, Workers);
            form2.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Studio AUDIO_Clone = (Studio)AUDIO.Clone();
            AUDIO_Clone.l_rooms = AUDIO.l_rooms;
            AUDIO_Clone.d_worker = AUDIO.d_worker;
            AUDIO_Clone.l_instrument = AUDIO.l_instrument;
            dataGridView1.Rows.Add(AUDIO_Clone.name, AUDIO_Clone.address, AUDIO_Clone.workers, AUDIO_Clone.track_cost, AUDIO_Clone.track_time, AUDIO_Clone.one_worker_salary, AUDIO_Clone.all_workers_salary, AUDIO_Clone.instruments, AUDIO_Clone.audiorooms);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            label1.Text = AUDIO[0].ToString();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            label1.Text = AUDIO[1].ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PrintAll();
        }
    }
}
