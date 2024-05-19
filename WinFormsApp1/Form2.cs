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
    public partial class Form2 : Form
    {
        Form1 owner;
        string Table;
        
        public Form2(Form1 maker, string table)
        {
            InitializeComponent();
            owner = maker;
            Table = table;
            label2.Text = Table;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            owner.DB.GetSchema(Table, listBox1);
            foreach (var item in listBox1.Items)
            {
                listBox2.Items.Add("null");
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox2.Items[listBox2.SelectedIndex] = textBox1.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string values = "";
            string places = "";
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                places += listBox1.Items[i].ToString();
                values += "'" + listBox2.Items[i].ToString()+ "'";
               if(i<listBox1.Items.Count-1) 
                {
                    values += ", ";
                    places += ", ";
                }
            }
            owner.DB.Push(Table,places, values);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
