using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace Lab4
{
    public partial class Form1 : Form
    {
        //Список слов, которые обработчик найдёт
        List<String> list = new List<String>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonReadText_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "текстовый файл|*.txt";

            if (fd.ShowDialog() == DialogResult.OK)
            {
                //Объявление и запуск таймера
                Stopwatch t = new Stopwatch();
                t.Start();

                //Чтение файла в виде строки
                string text = File.ReadAllText(fd.FileName);

                //Разделительные символы для чтения из файла
                char[] separators = new char[] {' ', '.', ',', '!', '?', '/', '\t', '\n'};

                //Создание массива слов, разделенных по указанным выше разделителям
                string[] textArray = text.Split(separators);

                foreach (string strTemp in textArray)
                {
                    //Удаление пробелов в начале и конце строки
                    string str = strTemp.Trim();

                    //Добавление строки в список, если строка не содержится в списке
                    //т.е. идет поиск уникальных слов файла
                    if (!list.Contains(str)) list.Add(str);
                }

                t.Stop();
                this.textBoxReadTime.Text = t.Elapsed.ToString();
                this.textBoxReadTime.ReadOnly = true;
            }

            else
            {
                MessageBox.Show("Необходимо выбрать файл");
            }
        }

        private void buttonSearchWord_Click(object sender, EventArgs e)
        {
            //Слово для поиска
            string word = this.textBoxSearchWord.Text.Trim();

            //Если слово для поиска не пусто
            if (!string.IsNullOrWhiteSpace(word) && list.Count > 0)
            {
                //Слово для поиска в верхнем регистре
                string wordUpper = word.ToUpper();

                //Временные результаты поиска
                List<string> tempList = new List<string>();

                //Объявление и старт таймера
                Stopwatch t = new Stopwatch();
                t.Start();

                foreach (string str in list)
                {
                    if (str.ToUpper().Contains(wordUpper))
                    {
                        tempList.Add(str);
                    }
                }
                t.Stop();
                this.textBoxSearchTime.Text = t.Elapsed.ToString();

                this.listBoxFoundWords.BeginUpdate();

                //Очистка списка от результатов предыдущего поиска
                this.listBoxFoundWords.Items.Clear();

                foreach (string str in tempList)
                {
                    this.listBoxFoundWords.Items.Add(str);
                }
                this.listBoxFoundWords.EndUpdate();
            }
            else
            {
                MessageBox.Show("Необходимо выбрать файл и ввести слово для поиска");
            }
        }
    }
}
