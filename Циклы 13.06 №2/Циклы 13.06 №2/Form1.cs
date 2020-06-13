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
            listBox1.Items.Clear();
            // обьявление переменных
            try
            {
                TimeSpan startDay = TimeSpan.Parse(maskedTextBox1.Text);
                TimeSpan lessonDuration = TimeSpan.Parse(maskedTextBox2.Text);
                TimeSpan StandartInterval = TimeSpan.Parse(maskedTextBox3.Text);
                TimeSpan BigInterval = TimeSpan.Parse(maskedTextBox4.Text);
                int indexBigInterval = (int)numericUpDown1.Value;
                int countLessons = (int)numericUpDown2.Value;


                if (startDay >= TimeSpan.Parse("17:00") || startDay <= TimeSpan.Parse("07:00"))
                {
                    MessageBox.Show("По рекомаендациям Министерства Образования РФ начало занятий до 7 часов утра запрещено, также как и занятия после 17:00", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (StandartInterval <= TimeSpan.Parse("00:05") || BigInterval <= TimeSpan.Parse("00:30"))
                {
                    MessageBox.Show("По рекомаендациям Министерства Образования РФ продолжительность большого и обычного перерыва должна быть не меньше 5 и 30 минут соответсвенно.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (countLessons >= 8)
                {
                    MessageBox.Show("По рекомаендациям Министерства Образования РФ кол-во занятий не должно превышать 7.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
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
                        if (time > TimeSpan.Parse("17:00"))
                        {
                            MessageBox.Show("Внимание! Занятия проходят после 17:00.\nПересмотрите расписание.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch {
                MessageBox.Show("Проверьте правильность ввода данных.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Расписание звонков. В учебном заведении задается начало учебного дня, продолжительность «пары» или урока, продолжительность обычного и большого перерывов (и их «место» в расписании), количество пар (уроков). Получить расписание звонков на весь учебный день.", "Задание", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
