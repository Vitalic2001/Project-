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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        bool ret = false;
        private void button1_Click(object sender, EventArgs e)
        {
            Stream mystr = null;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((mystr = openFileDialog1.OpenFile()) != null)
                {
                    StreamReader myread = new StreamReader(mystr);
                    string[] str;
                    int num = 0;
                    int ul = 0;
                    try
                    {
                        string[] str1 = myread.ReadToEnd().Split('\n');
                        num = str1.Count();
                        dataGridView1.RowCount = num;
                        for (int i = 0; i < num; i++)
                        {
                            str = str1[i].Split();
                            for (int j = 0; j < 17; j++)
                            {
                                try
                                {
                                    switch (j)
                                    {
                                        case 2:
                                            ul =0;
                                            break;
                                        case 5:
                                            ul = 1;
                                            break;
                                        case 7:
                                            ul = 2;
                                            break;
                                        case 10:
                                            ul = 3;
                                            break;
                                        case 13:
                                            ul = 4;
                                            break;
                                        case 16:
                                            ul = 5;
                                            break;
                                    }
                                    if (j == 2 || j == 5 || j == 7 || j == 10 || j == 13 || j == 16)
                                    {
                                        dataGridView1.Rows[i].Cells[ul].Value = str[j].Replace("_", " ").Replace("null", null);
                                    }
                                }
                                catch { }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        myread.Close();
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ret = false;
            String s;
            Stream myStream;
            string nh = "";
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

        private void button3_Click(object sender, EventArgs e)
        {
            int nr, nc;
            int a;

            nc = dataGridView1.Columns.Count;
            nr = dataGridView1.RowCount;
            if ((nc > 0) && (nr > 1))
            {
                a = dataGridView1.CurrentRow.Index;
                if (a == nr - 2)
                {
                    ret = false;
                }
                if ((nc > 0) && (nr > 1) && (ret = true) && (a <= nr - 2))
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

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            ret = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 Form1 = new Form1();
            Form1.Show();
        }
    }
}
