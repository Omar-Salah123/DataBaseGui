using System.Collections.Specialized;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        string Table;
        string working;
        public DatabaseHandler DB;
        public Form1()
        {
            InitializeComponent();
            DB = new DatabaseHandler("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=FlightSystem;Integrated Security=True;Connect Timeout=30;Encrypt=false;");

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
                Form2 f2 = new Form2(this, Table);
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
    }
}
