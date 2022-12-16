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

namespace лаба9_2wf
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StreamReader fileIn = new StreamReader("t.txt");
            string text = fileIn.ReadToEnd();
            richTextBox1.Text = "Исходный текст файла t.txt:\n" + text;
            richTextBox1.Text += "\nНечётные строки текста файла:\n";
            string[] lines = File.ReadAllLines("t.txt");
            int n = 0;
            while (n < lines.Length)
            {
                richTextBox1.Text += lines[n] + Environment.NewLine;
                n += 2;
            }
        }
    }
}
