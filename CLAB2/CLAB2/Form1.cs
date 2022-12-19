using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CLAB2
{
    public partial class Form1 : Form
    {
        Studio AUDIO = new Studio("D&G Audio", "ул.Тараса Шевченка, 23", 30, 200000, 7, 10000, 300000, 80, 12);

        public Form1()
        {
            InitializeComponent();
        }

        private void PrintAll()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Rows.Add(AUDIO.name, AUDIO.address, AUDIO.workers, AUDIO.track_cost, AUDIO.track_time, AUDIO.one_worker_salary, AUDIO.all_workers_salary, AUDIO.instruments, AUDIO.audiorooms);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PrintAll();
        }

        private void AddRoom()
        {
            try
            {
                int rooms = Convert.ToInt32(textBox2.Text);
                if (rooms <= 0)
                {
                    MessageBox.Show("Кол-во комнат не может быть отрицательным (либо быть равным ему)!", "Ошибка!");
                    return;
                }
                AUDIO.audiorooms += rooms;
                textBox2.Clear();
                PrintAll();
            }
            catch
            {
                MessageBox.Show("Неверный формат введённых данных!", "Ошибка!");
            }
        }

        private void RemoveRoom()
        {
            try
            {
                int rooms = Convert.ToInt32(textBox2.Text);
                if (rooms <= 0)
                {
                    MessageBox.Show("Кол-во комнат не может быть отрицательным (либо быть равным ему)!", "Ошибка!");
                    return;
                }
                if (rooms > AUDIO.audiorooms)
                {
                    MessageBox.Show("В студии нет такого кол-ва комнат!", "Ошибка!");
                    return;
                }
                AUDIO.audiorooms -= rooms;
                textBox2.Clear();
                PrintAll();
            }
            catch
            {
                MessageBox.Show("Неверный формат введённых данных!", "Ошибка!");
            }
        }

        private void AddWorker()
        {
            try
            {
                int worker = Convert.ToInt32(textBox1.Text);
                if (worker <= 0)
                {
                    MessageBox.Show("Кол-во работников не может быть отрицательным (либо быть равным ему)!", "Ошибка!");
                    return;
                }
                AUDIO.workers += worker;
                AUDIO.all_workers_salary = AUDIO.workers * AUDIO.one_worker_salary;
                textBox1.Clear();
                PrintAll();
            }
            catch
            {
                MessageBox.Show("Неверный формат введённых данных!", "Ошибка!");
            }
        }

        private void RemoveWorker()
        {
            try
            {
                int worker = Convert.ToInt32(textBox1.Text);
                if (worker <= 0)
                {
                    MessageBox.Show("Кол-во работников не может быть отрицательным (либо быть равным ему)!", "Ошибка!");
                    return;
                }
                if (worker > AUDIO.workers)
                {
                    MessageBox.Show("В студии нет такого кол-ва работников!", "Ошибка!");
                    return;
                }
                AUDIO.workers -= worker;
                AUDIO.all_workers_salary = AUDIO.workers * AUDIO.one_worker_salary;
                textBox1.Clear();
                PrintAll();
            }
            catch
            {
                MessageBox.Show("Неверный формат введённых данных!", "Ошибка!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddRoom();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RemoveRoom();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddWorker();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            RemoveWorker();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Studio AUDIO_Clone = (Studio)AUDIO.Clone();
            dataGridView1.Rows.Add(AUDIO_Clone.name, AUDIO_Clone.address, AUDIO_Clone.workers, AUDIO_Clone.track_cost, AUDIO_Clone.track_time, AUDIO_Clone.one_worker_salary, AUDIO_Clone.all_workers_salary, AUDIO_Clone.instruments, AUDIO_Clone.audiorooms);
        }
    }
}
