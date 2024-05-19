using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Net.Security;
using System.Xml.Linq;
using static System.Console;
using System.Windows.Forms;


namespace WinFormsApp1
{
    public class DatabaseHandler : IDisposable
    {
        //class Atributes
        private readonly string connectionString;
        private SqlConnection connection;
        private bool disposedValue;

        public SqlConnection Connection { get => connection; set => connection = value; }

        public DatabaseHandler(string _connectionString)
        {
            connectionString = _connectionString;
            Connection = new SqlConnection(connectionString);
        }
        /// <summary>
        /// Ensure connection to database. To be called before using connection field.
        /// </summary>
        private void EnsureConnection()
        {
            Connection ??= new SqlConnection(connectionString);
            if (Connection.State != ConnectionState.Open)
            {
                Connection.Open();
            }
        }
        public void GetSchema(string Table, ListBox listbox) 
        {
            listbox.Items.Clear();
            string queryString = $"SELECT * FROM {Table}";

            using SqlDataReader reader = GetReaderFromQuery(queryString);
            DataTable schema = reader.GetSchemaTable();
            foreach (DataRow row in schema.Rows)
            {
                List<string> columndata = new List<string>();
                foreach (DataColumn column in schema.Columns)
                {
                    columndata.Add($"{row[column]}");
                }
                string Row = string.Join(", ", columndata);
                listbox.Items.Add(Row);
            }
            /*foreach(DataRow row in schema.Rows) 
            {
                List<string> columndata = new List<string>();
                
                    columndata.Add($"{row[0]}");
           
                string Row = string.Join(", ", columndata);
                listbox.Items.Add(Row);
            }*/
        }
        public void Refresh(string table, ListBox listbox) 
        {
            listbox.Items.Clear();
            string queryString = $"SELECT * FROM {table}";

            using SqlDataReader reader = GetReaderFromQuery(queryString);
            while (reader.Read()) 
            {
                List<string> columndata= new List<string>();
                for(int i = 0; i < reader.FieldCount; i++) 
                {
                    columndata.Add(reader[i].ToString());
                }
                string Row = string.Join(", ", columndata);
                listbox.Items.Add(Row);
            }
            
        }
        #region Update
        public void Modify(string attribute, string newvalue, string id)
        {
            EnsureConnection();
            string queryString = "Update Customer Set @Attribute = @NewValue where ID = @id";
            SqlCommand command = new(queryString, Connection);
            command.Parameters.AddWithValue("@Attribute", attribute);
            command.Parameters.AddWithValue("@Id", id);
            command.Parameters.AddWithValue("@NewValue", newvalue);
            command.ExecuteNonQuery();
        }
        public void Push(string tble, string places, string Values)
        {
            EnsureConnection();
            string queryString = $"INSERT INTO {tble} ({places}) VALUES ({Values});";
            SqlCommand command = new(queryString, Connection);

            command.ExecuteNonQuery();
        }
        public void ChangeFlightTakeOffDateByFnum(DateTime newTime, string fnum)
        {
            EnsureConnection();
            string queryString = "Update Flight Set TakeOffDate = @newTime where Fnum = @fnum";
            SqlCommand command = new(queryString, Connection);
            command.Parameters.AddWithValue("@fnum", fnum);
            command.Parameters.AddWithValue("@newTime", newTime);
            command.ExecuteNonQuery();
        }
        #endregion
        #region Insert
        public void Insert(string name, int companionId, DateTime birthDate, string fnum)
        {
            EnsureConnection();
            string queryString = "Insert Into Infant values(@name,@companionId,@birthDate,@fnum);";
            SqlCommand command = new(queryString, Connection);
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@companionId", companionId);
            command.Parameters.AddWithValue("@birthDate", birthDate);
            command.Parameters.AddWithValue("@fnum", fnum);
            command.ExecuteNonQuery();
        }
        public void InsertCustomer(string name, string passport, string nationality)
        {
            EnsureConnection();
            string queryString = "Insert Into Customer values(@name,@passport,@nationality);";
            SqlCommand command = new(queryString, Connection);
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@passport", passport);
            command.Parameters.AddWithValue("@nationality", nationality);
            command.ExecuteNonQuery();
        }
        #endregion
        #region Delete
        /// <summary>
        /// Deletes all flights before a given date.
        /// </summary>
        /// <param name="date"></param>
        public void DeleteFlightsByDate(DateTime date)
        {
            EnsureConnection();
            string query = "Delete from Flight where TakeOffDate < @date";
            SqlCommand command = new(query, Connection);
            command.Parameters.AddWithValue("@date", date);
            command.ExecuteNonQuery();

        }
        public void DeleteCustomerById(int Id)
        {
            EnsureConnection();
            string queryString = "Delete from Customer where ID=@Id";
            SqlCommand command = new(queryString, Connection);
            command.Parameters.AddWithValue("@Id", Id);
            command.ExecuteNonQuery();
        }
        #endregion
        #region Select
        public SqlDataReader GetReaderFromQuery(string query)
        {
            EnsureConnection();
            SqlCommand command = new(query, Connection);
            return command.ExecuteReader();
        }
        public SqlDataReader GetTableReader(string tableName, string columns = "*")
        {
            string queryString = $"SELECT {columns} FROM {tableName};";
            return GetReaderFromQuery(queryString);
        }
        public IEnumerable<string[]> ReadTable(string tableName)
        {
            using SqlDataReader reader = GetTableReader(tableName);
            while (reader.Read())
            {
                string[] values = new string[reader.FieldCount];
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = reader[i].ToString() ?? "";
                }
                yield return values;
            }
        }
        /// <summary>
        /// Gets flights between two dates
        /// </summary>
        /// <param name="firstDate"></param>
        /// <param name="secondDate"></param>
        /// <param name="destination"></param>
        /// <param name="source"></param>
        /// <returns>SqlDataReader for flights</returns>
        public SqlDataReader GetFlightsReader(DateTime firstDate, DateTime secondDate, string destination, string source)
        {
            string queryString = $"SELECT * From Flight where Destination='{destination}'" +
                $" AND TakeOff='{source}' AND " +
                $"TakeOffDate between '{firstDate}' AND '{secondDate}'";
            return GetReaderFromQuery(queryString);
        }
        /// <summary>
        /// Gets flights before a date
        /// </summary>
        /// <param name="date"></param>
        /// <returns>SqlDataReader for flights</returns>
        public SqlDataReader GetFlightsReader(DateTime date)
        {
            string queryString = $"SELECT * From Flight where  TakeOffDate < '{date}'";
            return GetReaderFromQuery(queryString);
        }
        /// <summary>
        /// Gets flights between two dates
        /// </summary>
        /// <param name="firstDate"></param>
        /// <param name="secondDate"></param>
        /// <param name="destination"></param>
        /// <param name="source"></param>
        /// <returns></returns



        /// <summary>
        /// Gets flights before a date
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        /// <summary>
        /// Reads flights from an SqlDataReader
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>


        #endregion
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    Connection.Dispose();
                }
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
