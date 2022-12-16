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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        DataTable dt = new DataTable();
        int n;
        double b;
        int i = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (numericUpDown1.Value <= 0) MessageBox.Show("Некорректный ввод данных!");
            else
            {
                n = int.Parse(numericUpDown1.Text);
                b = double.Parse(numericUpDown2.Text);
                numericUpDown1.Enabled = false;
                numericUpDown2.Enabled = false;
                button2.Enabled = false;
                label3.Visible = true;
                numericUpDown3.Visible = true;
                dt.Rows.Add(dt.NewRow());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (i == n - 1)
            {
                dt.Columns.Add(i.ToString(), typeof(double));
                dt.Rows[0][i] = double.Parse(numericUpDown3.Text);
                label3.Text = "Всё";
                button3.Enabled = false;
                button1.Visible = true;
            }
            else
            {
                dt.Columns.Add(i.ToString(), typeof(double));
                dt.Rows[0][i] = double.Parse(numericUpDown3.Text);
                i++;
                label3.Text = "n" + (i + 1);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FileStream f = File.Create("t.dat");
            BinaryWriter fOut = new BinaryWriter(f);
            double[] mas = new double[n];
            richTextBox1.Text = "Исходные числа:\n";
            for (int i = 0; i < n; i++)
            {
                double temp = double.Parse(dt.Rows[0][i].ToString());
                richTextBox1.Text += $"{temp}\n";
                mas[i] = temp;
                fOut.Write(temp); ;
            }
            fOut.Close();
            f = new FileStream("t.dat", FileMode.Open);
            BinaryReader fIn = new BinaryReader(f);
            long m = f.Length;
            richTextBox1.Text += "Результат:\n";
            for (long i = 0; i < m; i += 16)
            {
                f.Seek(i, SeekOrigin.Begin);
                double a = fIn.ReadDouble();
                if (a > b) richTextBox1.Text += $"{a}\n";
            }
            fIn.Close();
            f.Close();
            FileStream ff = File.Create("text.txt");
            StreamWriter fWrt = new StreamWriter(ff);
            for (int i = 0; i < n; i++)
            {
                double temp = mas[i];
                fWrt.Write(temp + " "); ;
            }
            fWrt.Close();
            ff.Close();
        }
    }
}
