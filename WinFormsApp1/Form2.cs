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
        ListBox ownerbox;
        List<KeyValuePair<string, bool>> types;
        public Form2(Form1 maker, string table, ListBox ownerbox)
        {
            InitializeComponent();
            owner = maker;
            Table = table;
            label2.Text = Table;
            this.ownerbox = ownerbox;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            types=owner.DB.GetSchema(Table, listBox1);
            for (int i =0;i<listBox1.Items.Count; i++)
            {
                listBox2.Items.Add($"null: {types[i]}");
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox2.Items[listBox2.SelectedIndex] = textBox1.Text;
        }
        /*
         cases for each data type nvarchar, datetime, int
         */
        private void button1_Click(object sender, EventArgs e)
        {
            string values = "";
            string places = "";
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                if (types[i].Value != true)
                {
                    switch (types[i].Key)
                    {
                        case "nvarchar":
                            {
                                values += "'" + listBox2.Items[i].ToString() + "'";
                                break;
                            }
                        case "datetime":
                            {
                                values += listBox2.Items[i].ToString();
                                break;
                            }
                        case "int":
                            {
                                values += listBox2.Items[i].ToString();
                                break;
                            }
                        case "float":
                            {
                                values += listBox2.Items[i].ToString();
                                break;
                            }
                    }
                    places += listBox1.Items[i].ToString();
                    if (i < listBox1.Items.Count - 1)
                    {
                        values += ", ";
                        places += ", ";
                    }
                }
            }
            owner.DB.Push(Table,places, values);
            this.Close();
            owner.DB.Refresh(Table, ownerbox);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
