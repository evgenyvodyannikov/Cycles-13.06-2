using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Циклы_13._06__2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            // обьявление переменных
            TimeSpan startDay = TimeSpan.Parse(maskedTextBox1.Text);
            TimeSpan lessonDuration = TimeSpan.Parse(maskedTextBox2.Text);
            TimeSpan StandartInterval = TimeSpan.Parse(maskedTextBox3.Text);
            TimeSpan BigInterval = TimeSpan.Parse(maskedTextBox4.Text);
            int indexBigInterval = (int)numericUpDown1.Value;
            int countLessons = (int)numericUpDown2.Value;
            Console.WriteLine();

            TimeSpan time = startDay;
            for (int i = 1; i <= countLessons; i++) // цикл с 1 по последний урок
            {
                listBox1.Items.Add("Урок " + i); // записываем № урока
                listBox1.Items.Add(time); // время нач. урока
                time = time.Add(lessonDuration); // добавляем к переменной time продолжительность урока
                listBox1.Items.Add(time); // теперь уже будет выведено нач. урока + продолжительность, то есть конец урока
                if (i != countLessons) // проверяем не последний ли урок?
                {
                    listBox1.Items.Add("Перерыв:"); // добавляем надпись "перерыв"
                    listBox1.Items.Add(time); // записываем время начала
                    if (i != indexBigInterval) // проверяем большой ли сейчас перерыв?
                    {
                        time = time.Add(StandartInterval); // добавляем продолжительность обычного перерыва
                        listBox1.Items.Add(time); // записываем конец перерыва
                    }
                    else // то же самое, но для большого перерыва
                    {
                        time = time.Add(BigInterval);
                        listBox1.Items.Add(time);
                    }
                }
            }
        }
    }
}
