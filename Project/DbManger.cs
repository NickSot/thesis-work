using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class DbManager
    {
        public static SqlConnection connection;
        private string connectionString;

        public DbManager()
        {
            StreamReader fs = new StreamReader("db_credentials.cn", Encoding.ASCII);

            string username = fs.ReadLine();
            string password = fs.ReadLine();

            connectionString = string.Format(@"data source=DESKTOP-O5H2295\NIK;user={0};password={1};database=ThesisProject;", username, password);
            connection = new SqlConnection(connectionString);

            //Testing the connection
            connection.Open();
            connection.Close();
        }

        public static void CreateTable(string tableName, Dictionary<string, string> columns) {
            if (connection.State != ConnectionState.Open)
                connection.Open();

            StringBuilder sb = new StringBuilder();

            foreach (var column in columns)
            {
                sb.Append(column.Key + " " + column.Value + ",\n");
            }

            sb.Remove(sb.Length - 1, 1);

            SqlCommand sqlCmd = new SqlCommand($"if not exists(select * from sysobjects where name = '{tableName}' and xtype = 'U') create table { tableName }( { sb.ToString() } )", connection);
            sqlCmd.ExecuteNonQuery();
            
            connection.Close();
        }

        public static void DropTable(string tableName)
        {
            connection.Open();

            SqlCommand sqlCmd = new SqlCommand($"Drop Table If Exists {tableName};", connection);
            sqlCmd.ExecuteNonQuery();

            connection.Close();
        }

        public static DataRow Find(string tableName, int id)
        {
            connection.Open();

            SqlCommand sqlCmd = new SqlCommand("Select * From " + tableName + " Where Id = @id", connection);
            sqlCmd.Parameters.AddWithValue("@id", id);

            SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
            DataTable dt = new DataTable();

            da.Fill(dt);
            connection.Close();

            if (dt.Rows.Count == 0)
            {
                return null;
            }

            return dt.Rows[0];
        }

        public static DataTable Where(string tableName, Dictionary<string, Object> dict, string whereClause, string what = "*", string callback = "")
        {
            connection.Open();

            StringBuilder sb = new StringBuilder();

            sb.Append(string.Format("Select {0} From {1} Where ", what, tableName));

            int counter = 0;

            foreach (var obj in dict)
            {
                sb.Append(obj.Key + "=" + string.Concat("@" + obj.Key));

                if (counter < dict.Count - 1)
                {
                    sb.Append(" " + whereClause + " ");
                }

                counter++;
            }

            sb.Append(callback);
            sb.Append(";");

            SqlCommand sqlCmd = new SqlCommand(sb.ToString(), connection);

            foreach (var obj in dict)
            {
                sqlCmd.Parameters.AddWithValue(string.Concat("@", obj.Key), obj.Value.ToString());
            }

            SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
            DataTable dt = new DataTable();

            da.Fill(dt);
            connection.Close();
            return dt;
        }

        public static DataTable WhereAnd(string tableName, Dictionary<string, Object> dict, string what = "*", string callback = "")
        {
            return Where(tableName, dict, "AND", what, callback);
        }

        public static DataTable WhereOr(string tableName, Dictionary<string, Object> dict, string what = "*", string callback = "")
        {
            return Where(tableName, dict, "OR", what, callback);
        }

        public static void Insert(string tableName, Dictionary<string, Object> dict)
        {
            connection.Open();

            StringBuilder sb = new StringBuilder();

            sb.Append(string.Format("Insert Into {0} (", tableName));

            int counter = 0;

            foreach (var obj in dict)
            {
                sb.Append(obj.Key);

                if (counter < dict.Count - 1)
                {
                    sb.Append(", ");
                }

                counter++;
            }

            sb.Append(") Values ( ");

            counter = 0;

            foreach (var obj in dict)
            {
                sb.Append("@" + obj.Key);

                if (counter < dict.Count - 1)
                {
                    sb.Append(", ");
                }

                counter++;
            }

            sb.Append(");");

            SqlCommand sqlCmd = new SqlCommand(sb.ToString(), connection);

            foreach (var obj in dict)
            {
                sqlCmd.Parameters.AddWithValue(string.Concat("@", obj.Key), obj.Value);
            }

            sqlCmd.ExecuteNonQuery();

            connection.Close();
        }

        public static void Update(string tableName, int id, Dictionary<string, Object> dict)
        {
            connection.Open();

            StringBuilder sb = new StringBuilder();

            sb.Append(string.Format("Update {0} Set ", tableName));

            int counter = 0;

            foreach (var obj in dict)
            {
                sb.Append(obj.Key + "=" + string.Concat("@" + obj.Key));

                if (counter < dict.Count - 1)
                {
                    sb.Append(", ");
                }

                counter++;
            }

            sb.Append(" Where Id = @id;");

            SqlCommand sqlCmd = new SqlCommand(sb.ToString(), connection);

            sqlCmd.Parameters.AddWithValue("@id", id);

            foreach (var obj in dict)
            {
                sqlCmd.Parameters.AddWithValue(string.Concat("@", obj.Key), obj.Value.ToString());
            }

            sqlCmd.ExecuteNonQuery();

            connection.Close();
        }

        public static void Delete(string tableName, Dictionary<string, Object> dict = null)
        {
            connection.Open();

            StringBuilder sb = new StringBuilder();

            sb.Append(string.Format("Delete From {0}", tableName));

            int counter = 0;

            if (dict != null)
            {
                sb.Append(" Where");

                foreach (var obj in dict)
                {
                    sb.Append(obj.Key + "=" + string.Concat("@" + obj.Key));

                    if (counter < dict.Count - 1)
                    {
                        sb.Append(" And ");
                    }

                    counter++;
                }
            }

            sb.Append(";");

            SqlCommand sqlCmd = new SqlCommand(sb.ToString(), connection);

            if (dict != null)
            {
                foreach (var obj in dict)
                {
                    sqlCmd.Parameters.AddWithValue(string.Concat("@", obj.Key), obj.Value.ToString());
                }
            }

            SqlDataAdapter da = new SqlDataAdapter(sqlCmd);

            DataTable dt = new DataTable();

            da.Fill(dt);

            connection.Close();
        }

        public static DataTable All(string tableName, string what = "*", string callback = "")
        {
            SqlDataAdapter da = new SqlDataAdapter(string.Format("Select {0} From {1} {2};", what, tableName, callback), connection);
            DataTable dt = new DataTable();

            da.Fill(dt);
            return dt;
        }
    }
}
