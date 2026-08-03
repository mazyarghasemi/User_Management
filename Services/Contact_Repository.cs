using System;
using Npgsql;
using System.Data;

using At_First.Repository;
using System.Windows.Forms;
using System.Globalization;
using System.Configuration;

namespace At_First.Services
{
    class Contact_Repository : IContact_Repository
    {
        //ADO.NET form


        // PostgreSQL connection string pointing to local instance
        string Connecting = "Host=localhost;Port=5432;Database=Clients;Username=postgres;Password=Mazyar6533!";

        public DataTable SelectRow(int ID)
        {
            // Escape the table and column names to preserve mixed-case
            string query = "SELECT * FROM \"Clients\" WHERE \"ID\"=" + ID;
            NpgsqlConnection connection = new NpgsqlConnection(Connecting);
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(query, connection);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }

        public DataTable SelectAll()
        {
            string query = "SELECT * FROM \"Clients\"";
            NpgsqlConnection connection = new NpgsqlConnection(Connecting);
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(query, connection);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }

        public bool Insert(string Code, string Full_Name, string Mobile, string Service, string Description, string Job, DateTime Date_Born, string Gender, string How_To_Introduce, int Payment, string Discount, int Debit, int All_Payment, int Counter, DateTime Date_Coming, string Address, DateTime Next_Day)
        {
            // Escaped all column names and the table name for PostgreSQL mixed-case schema
            string query = "INSERT INTO \"Clients\" (\"Code\",\"Full_Name\",\"Mobile\", \"Service\", \"Description\", \"Job\", \"Date_Born\", \"Gender\", \"How_To_Introduce\", \"Payment\", \"Discount\", \"Debit\",\"All_Payment\", \"Counter\", \"Date_Coming\", \"Address\", \"Next_Day\") VALUES(@Code,@Full_Name,@Mobile,@Service, @Description, @Job, @Date_Born, @Gender, @How_To_Introduce, @Payment, @Discount, @Debit,@All_Payment, @Counter, @Date_Coming, @Address, @Next_Day);";
            NpgsqlConnection connection = new NpgsqlConnection(Connecting);
            try
            {
                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("@Code", Code);
                command.Parameters.AddWithValue("@Full_Name", Full_Name);
                command.Parameters.AddWithValue("@Mobile", Mobile);
                command.Parameters.AddWithValue("@Service", Service);
                command.Parameters.AddWithValue("@Description", Description);
                command.Parameters.AddWithValue("@Job", Job);
                command.Parameters.AddWithValue("@Date_Born", Date_Born);
                command.Parameters.AddWithValue("@Gender", Gender);
                command.Parameters.AddWithValue("@How_To_Introduce", How_To_Introduce);
                command.Parameters.AddWithValue("@Payment", Payment);
                command.Parameters.AddWithValue("@Discount", Discount);
                command.Parameters.AddWithValue("@Debit", Debit);
                command.Parameters.AddWithValue("@All_Payment", All_Payment);
                command.Parameters.AddWithValue("@Counter", Counter);
                command.Parameters.AddWithValue("@Date_Coming", Date_Coming);
                command.Parameters.AddWithValue("@Address", Address);
                command.Parameters.AddWithValue("@Next_Day", Next_Day);
                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public bool Delete(int ID)
        {
            string query = "DELETE FROM \"Clients\" WHERE \"ID\"=@ID;";
            NpgsqlConnection connection = new NpgsqlConnection(Connecting);
            try
            {
                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID", ID);
                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public bool Edit(int ID, string Code, string Full_Name, string Mobile, string Service, string Description, string Job, DateTime Date_Born, string Gender, string How_To_Introduce, int Payment, string Discount, int Debit, int All_Payment, int Counter, DateTime Date_Coming, string Address, DateTime Next_Day)
        {
            NpgsqlConnection connection = new NpgsqlConnection(Connecting);
            try
            {
                string query = "UPDATE \"Clients\" SET \"Code\"=@Code,\"Full_Name\"=@Full_Name,\"Mobile\"=@Mobile,\"Service\"=@Service,\"Description\"=@Description,\"Job\"=@Job,\"Date_Born\"=@Date_Born,\"Gender\"=@Gender,\"How_To_Introduce\"=@How_To_Introduce,\"Payment\"=@Payment,\"Discount\"=@Discount,\"Debit\"=@Debit,\"All_Payment\"=@All_Payment,\"Counter\"=@Counter,\"Date_Coming\"=@Date_Coming,\"Address\"=@Address WHERE \"ID\"=@ID";
                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID", ID);
                command.Parameters.AddWithValue("@Code", Code);
                command.Parameters.AddWithValue("@Full_Name", Full_Name);
                command.Parameters.AddWithValue("@Mobile", Mobile);
                command.Parameters.AddWithValue("@Service", Service);
                command.Parameters.AddWithValue("@Description", Description);
                command.Parameters.AddWithValue("@Job", Job);
                command.Parameters.AddWithValue("@Date_Born", Date_Born);
                command.Parameters.AddWithValue("@Gender", Gender);
                command.Parameters.AddWithValue("@How_To_Introduce", How_To_Introduce);
                command.Parameters.AddWithValue("@Payment", Payment);
                command.Parameters.AddWithValue("@Discount", Discount);
                command.Parameters.AddWithValue("@Debit", Debit);
                command.Parameters.AddWithValue("@All_Payment", All_Payment);
                command.Parameters.AddWithValue("@Counter", Counter);
                command.Parameters.AddWithValue("@Date_Coming", Date_Coming);
                command.Parameters.AddWithValue("@Address", Address);
                command.Parameters.AddWithValue("@Next_Day", Next_Day);
                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public DataTable SearchFull_Name(string Text)
        {
            string query = "SELECT * FROM \"Clients\" WHERE \"Full_Name\" LIKE @Text";
            NpgsqlConnection connection = new NpgsqlConnection(Connecting);
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(query, connection);
            adapter.SelectCommand.Parameters.AddWithValue("@Text", "%" + Text + "%");
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }

        public DataTable SearchIntroduce(string Text)
        {
            string query = "SELECT * FROM \"Clients\" WHERE \"How_To_Introduce\" LIKE @Text";
            NpgsqlConnection connection = new NpgsqlConnection(Connecting);
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(query, connection);
            adapter.SelectCommand.Parameters.AddWithValue("@Text", "%" + Text + "%");
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }

        public DataTable SearchService(string Text)
        {
            string query = "SELECT * FROM \"Clients\" WHERE \"Service\" LIKE @Text or \"Description\" LIKE @Text";
            NpgsqlConnection connection = new NpgsqlConnection(Connecting);
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(query, connection);
            adapter.SelectCommand.Parameters.AddWithValue("@Text", "%" + Text + "%");
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }

        public DataTable SearchDescription(string Text)
        {
            string query = "SELECT * FROM \"Clients\" WHERE \"Description\" LIKE @Text";
            NpgsqlConnection connection = new NpgsqlConnection(Connecting);
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(query, connection);
            adapter.SelectCommand.Parameters.AddWithValue("@Text", "%" + Text + "%");
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }

        public DataTable SearchMobile(string Text)
        {
            string query = "SELECT * FROM \"Clients\" WHERE \"Mobile\" LIKE @Text";
            NpgsqlConnection connection = new NpgsqlConnection(Connecting);
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(query, connection);
            adapter.SelectCommand.Parameters.AddWithValue("@Text", "%" + Text + "%");
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }

        public DataTable SearchDate(DateTime date)
        {
            PersianCalendar pc = new PersianCalendar();
            int d = pc.GetDayOfMonth(date);
            int m = pc.GetMonth(date);
            int y = pc.GetYear(date);

            // Migrated date functions to standard PostgreSQL EXTRACT syntax
            string query =
                "SELECT * FROM \"Clients\" " +
                "WHERE EXTRACT(DAY FROM \"Date_Born\") = @d OR EXTRACT(MONTH FROM \"Date_Born\") = @m OR EXTRACT(YEAR FROM \"Date_Born\") = @y";

            NpgsqlConnection connection = new NpgsqlConnection(Connecting);
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(query, connection);

            // Using Georgian values for DB parameters as stored originally
            adapter.SelectCommand.Parameters.AddWithValue("@d", date.Day);
            adapter.SelectCommand.Parameters.AddWithValue("@m", date.Month);
            adapter.SelectCommand.Parameters.AddWithValue("@y", date.Year);

            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }

        public DataTable SearchCode(string Text)
        {
            string query = "SELECT * FROM \"Clients\" WHERE \"Code\" LIKE @code";
            NpgsqlConnection connection = new NpgsqlConnection(Connecting);
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(query, connection);
            adapter.SelectCommand.Parameters.AddWithValue("@code", "%" + Text + "%");
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }
    }
}
