using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lcwaikiki
{
    public partial class Form2 : Form
    {
        public static Form2 Instance;
        Form3 form3 = new Form3();
        Form4 form4 = new Form4();
        Form5 form5 = new Form5();
        public Form2()
        {
            InitializeComponent();
            Instance = this;

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            string connectionString = "Server=localhost;Database=hierarchy;User Id=root;Password=Bisshamon22;";
            if (Form1.a == false)
            {
                button2.Hide();

 
            }
        }

        private void müşteriYönetimiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            form3.Show();

        }

        private void ürünYönetimiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            form4.Show();
        }

        private void raporlamaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            form5.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form6 form6= new Form6();
            form6.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           Application.Exit();
        }
    }
}
