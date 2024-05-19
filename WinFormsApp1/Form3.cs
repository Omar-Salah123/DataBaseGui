using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form3 : Form
    {
        Form1 owner;
        string ID;
        ListBox ownerbox;
        string Table;
        List<KeyValuePair<string, bool>> types;
        public Form3(Form1 maker, string table, string id, ListBox ownerbox)
        {
            InitializeComponent();
            owner = maker;
            ID = id;
            Table = table;
            label1.Text = ID;
            this.ownerbox = ownerbox;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            types = owner.DB.GetSchema(Table, listBox1);
            owner.DB.GetByID(Table, listBox1.Items[0].ToString(), ID, listBox2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text!=string.Empty)
            {
                int index = listBox2.SelectedIndex;
                string attribute = listBox1.Items[index].ToString();
                string idname = listBox1.Items[0].ToString();
                string newvalue = "";
                if (types[index].Value != true)
                {
                    switch (types[index].Key)
                    {
                        case "nvarchar":
                            {
                                newvalue = "'" + textBox1.Text + "'";
                                break;
                            }
                        case "datetime":
                            {
                                newvalue = textBox1.Text;
                                break;
                            }
                        case "int":
                            {
                                newvalue = textBox1.Text;
                                break;
                            }
                        case "float":
                            {
                                newvalue = textBox1.Text;
                                break;
                            }
                    }
                    if (attribute != newvalue)
                    {
                        owner.DB.Modify(Table, attribute, newvalue, idname, ID);
                        owner.DB.Refresh(Table, ownerbox);
                        this.Close();
                    }
                }
            }
        }
    }
}
