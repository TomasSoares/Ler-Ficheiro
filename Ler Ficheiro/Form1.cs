using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Ler_Ficheiro
{
    public partial class Form1 : Form
    {
        public static string dirParameter = AppDomain.CurrentDomain.BaseDirectory + @"\file.txt";
        public Form1()
        {
            InitializeComponent();
            openFileDialog1.FileOk += OpenFileDialog1_FileOk;
        }

        private void OpenFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            string ola;
            OpenFileDialog arquivo = (OpenFileDialog)sender;
            ola = System.IO.File.ReadAllText(arquivo.FileName);
            caixatxt.Text = ola;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Selecionar Ficheiro:";
            openFileDialog1.Filter = "Ficheiros do tipo (*.txt)|*.txt";
            openFileDialog1.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string texto = caixatxt.Text;

            char[] separator = {' '};
            
            text = text.Replace(Environment.NewLine, " ");

            int contawords = texto.Split(separator, StringSplitOptions.RemoveEmptyEntries).Length;
            label1.Text = contawords.ToString();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            label2.Text = caixatxt.Text.Length.ToString();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string numero = caixatxt.Text;
            int count = 0;

            for (int i = 0; i < numero.Length; i++)
            {
                if (numero[i] == '.' || numero[i] == '?' || numero[i] == '!')
                {
                    count++;
                }
            }
            label3.Text = "" + count;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Ficheiros do tipo (*.txt)|*.txt";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (Stream s = File.Open(saveFileDialog1.FileName, FileMode.OpenOrCreate))
                using (StreamWriter sw = new StreamWriter(s))
                {
                    sw.Write(caixatxt.Text);
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

