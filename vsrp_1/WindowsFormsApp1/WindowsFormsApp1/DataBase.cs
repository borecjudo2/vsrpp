using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    class DataBase
    {
        
        private static MySqlConnection getConnection()
        {
            string cs = "datasource=localhost;port=3306;username=root;password=NJ23XV/igWp7VADw8+YdNVa8xALRngA2;database=test";

            var con = new MySqlConnection(cs);

            try
            {
                con.Open();
            } catch (MySqlException ex)
            {
                MessageBox.Show("MySQL error!");
            }
            return con;
        }

        public static void save(VastedTimeEntity entity)
        {
            string sql = "INSERT INTO vasted_time VALUES (@id, @name, @vastedTime, @createdDate)";
            MySqlConnection connection = getConnection();
            MySqlCommand mySqlCommand = new MySqlCommand(sql, connection);

            mySqlCommand.CommandType = CommandType.Text;
            mySqlCommand.Parameters.Add("@id", MySqlDbType.Binary).Value = entity.id.ToByteArray();
            mySqlCommand.Parameters.Add("@name", MySqlDbType.VarChar).Value = entity.name;
            mySqlCommand.Parameters.Add("@vastedTime", MySqlDbType.Int32).Value = entity.vastedTime;
            mySqlCommand.Parameters.Add("@createdDate", MySqlDbType.DateTime).Value = entity.createdTime;

            try
            {
                mySqlCommand.ExecuteNonQuery();
            } catch (Exception ex)
            {
                MessageBox.Show("Didn't Add" + ex.Message);
            }
            connection.Close();
        }

        public static void update(VastedTimeEntity entity)
        {
            string sql = "UPDATE vasted_time SET name = @name, vasted_time = @vastedTime, created_date = @createdDate WHERE id = @id";
            MySqlConnection connection = getConnection();
            MySqlCommand mySqlCommand = new MySqlCommand(sql, connection);

            mySqlCommand.CommandType = CommandType.Text;
            mySqlCommand.Parameters.Add("@id", MySqlDbType.Binary).Value = entity.id.ToByteArray();
            mySqlCommand.Parameters.Add("@name", MySqlDbType.VarChar).Value = entity.name;
            mySqlCommand.Parameters.Add("@vastedTime", MySqlDbType.Int32).Value = entity.vastedTime;
            mySqlCommand.Parameters.Add("@createdDate", MySqlDbType.DateTime).Value = entity.createdTime;

            try
            {
                mySqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Didn't update");
            }
            connection.Close();
        }

        public static void delete(Guid id)
        {
            string sql = "DELETE FROM vasted_time WHERE id = @id";
            MySqlConnection connection = getConnection();
            MySqlCommand mySqlCommand = new MySqlCommand(sql, connection);

            mySqlCommand.CommandType = CommandType.Text;
            mySqlCommand.Parameters.Add("@id", MySqlDbType.Binary).Value = id.ToByteArray();

            try
            {
                mySqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            { 
                MessageBox.Show("Didn't delete");
            }
            connection.Close();
        }

        public static void findBySql(string sql, DataGridView gridView)
        {
            MySqlConnection connection = getConnection();
            MySqlCommand mySqlCommand = new MySqlCommand(sql, connection);
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(mySqlCommand);
            DataTable table = new DataTable();
            dataAdapter.Fill(table);
            gridView.DataSource = table;
            connection.Close();
        }

    }
}
