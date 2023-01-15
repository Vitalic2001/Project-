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

namespace Библиотека
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        bool ret = false;
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != ""
                && textBox4.Text != "" && textBox5.Text != "" && maskedTextBox1.Text != "")
            {
                string Datevud = maskedTextBox1.Text;
                string NameBook = textBox1.Text;
                string Avtor = textBox2.Text;
                string Kom = textBox3.Text;
                string KolvoSTR = textBox4.Text;
                string DateIzdan = textBox5.Text;
                dataGridView1.Rows.Add(Datevud, NameBook, Avtor, Kom, KolvoSTR, DateIzdan);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int tr, tc;
            int a;

            tc = dataGridView1.Columns.Count;
            tr = dataGridView1.RowCount;
            if ((tc > 0) && (tr > 1))
            {
                a = dataGridView1.CurrentRow.Index;
                if (a == tr - 2)
                {
                    ret = false;
                }
                if ((tc > 0) && (tr > 1) && (ret = true) && (a <= tr - 2))
                {
                    dataGridView1.Rows.Remove(dataGridView1.Rows[a]);
                }
            }
            string itog;
            int itog1 = 0;
            dataGridView1.MultiSelect = false;
            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
                if (dataGridView1.Rows[i].Cells[1].Value != null)
                {
                    int n;
                    itog = dataGridView1.Rows[i].Cells[1].Value.ToString();
                    if (int.TryParse(itog, out n))
                    {
                        itog1 = itog1 + int.Parse(itog);
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            ret = false;
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar) | (e.KeyChar == Convert.ToChar(",")) |
                e.KeyChar == '\b' | e.KeyChar == '-') return;
            else
                e.Handled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ret = false;
            String s;
            Stream myStream;
            string nh="";
            bool nl = false;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    dataGridView1.MultiSelect = false;
                    StreamWriter myWritet = new StreamWriter(myStream);
                    try
                    {
                        for (int i = 0; i < dataGridView1.RowCount - 1; i++)
                        {
                            for (int j = 0; j < dataGridView1.ColumnCount; j++)
                            {
                                switch (j)
                                {
                                    case 0:
                                        nh = "Дата выдачи: ";
                                    break;
                                    case 1:
                                        nh = "|Название книги: ";
                                    break;
                                    case 2:
                                        nh = "|Автор: ";
                                    break;
                                    case 3:
                                        nh = "|Кому выдать: ";
                                    break;
                                    case 4:
                                        nh = "|Количество страниц: ";
                                    break;
                                    case 5:
                                        nh = "|Дата издания: ";
                                    break;
                                }
                                dataGridView1.CurrentCell = dataGridView1.Rows[i].Cells[j];
                                dataGridView1.BeginEdit(false);
                                if (dataGridView1.Rows[i].Cells[j].Value != null)
                                {

                                }
                                else
                                {
                                    dataGridView1.Rows[i].Cells[j].Value = "null";
                                    nl = true;

                                }
                                if (j == dataGridView1.ColumnCount - 5 || j == dataGridView1.ColumnCount - 4 || j == dataGridView1.ColumnCount - 3 || j == dataGridView1.ColumnCount - 1)
                                {
                                    dataGridView1.Rows[i].Cells[j].Value = dataGridView1.Rows[i].Cells[j].Value.ToString().Replace(" ", "_");
                                    myWritet.Write(nh + dataGridView1.Rows[i].Cells[j].Value.ToString() + " ");
                                    dataGridView1.Rows[i].Cells[j].Value = dataGridView1.Rows[i].Cells[j].Value.ToString().Replace("_", " ");
                                }
                                else
                                {
                                    dataGridView1.Rows[i].Cells[j].Value = dataGridView1.Rows[i].Cells[j].Value.ToString().Replace(" ", "");
                                    myWritet.Write(nh + dataGridView1.Rows[i].Cells[j].Value.ToString() + " ");
                                }
                                if (nl == true)
                                {
                                    dataGridView1.Rows[i].Cells[j].Value = null;
                                    nl = false;
                                }
                            }
                            myWritet.WriteLine();
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        myWritet.Close();
                    }
                    myStream.Close();
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 Form1 = new Form1();
            Form1.Show();
        }
    }
}
