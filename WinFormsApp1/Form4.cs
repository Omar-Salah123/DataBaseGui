using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form4 : Form
    {
        DatabaseHandler? DB;
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            textBox1.Text = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=FlightSystem;Integrated Security=True;Connect Timeout=30;Encrypt=false;";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DB = new DatabaseHandler(textBox1.Text);
            Form1 f1 = new Form1(DB);
            f1.Show();
            this.Hide();
        }
    }
}
