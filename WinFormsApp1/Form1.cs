using System.Collections.Specialized;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        string Table;
        public DatabaseHandler DB;
        List<KeyValuePair<string, bool>> types;
        public Form1(DatabaseHandler db)
        {
            InitializeComponent();
            DB = db;
        }


        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListBox1.SelectedItem != null)
            {
                Table = ListBox1.SelectedItem.ToString();
                DB.Refresh(Table, ListBox2);
            }


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void ListBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            DB.Refresh(Table, ListBox2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ListBox1.SelectedItem != null)
            {
                Form2 f2 = new Form2(this, Table, ListBox2);
                f2.Show();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ListBox1.Items.Add("Flight");
            ListBox1.Items.Add("Customer");
            ListBox1.Items.Add("Booking");
            ListBox1.Items.Add("Aircraft");
            ListBox1.Items.Add("Admin");
            ListBox1.Items.Add("Infant");
            ListBox1.Items.Add("Luggage");

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void ListBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            types = DB.GetColumNames(Table);
            string deletee = ListBox2.SelectedItem.ToString();
            string deleteeID = GetId(deletee);
            DB.Delete(Table, types[0].Key, deleteeID);
            DB.Refresh(Table, ListBox2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (ListBox1.SelectedItem != null && ListBox2.SelectedItem != null)
            {
                string Modified = ListBox2.SelectedItem.ToString();
                string Mod = GetId(Modified);
                Form3 f3 = new Form3(this, Table, Mod, ListBox2);
                f3.Show();
            }
        }
        private string GetId(string full)
        {

            string deleteeID = "'";
            int i = 0;
            char peek = full[i];
            while (peek != ',')
            {
                deleteeID += full[i];
                peek = full[i + 1];
                i++;
            }
            deleteeID += "'";
            return deleteeID;
        }

        private void button5_Click(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
