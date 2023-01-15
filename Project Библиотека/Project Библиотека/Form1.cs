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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form3 Form3 = new Form3();
            Form3.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form2 Form2 = new Form2();
            Form2.Show();
        }
    }
}
