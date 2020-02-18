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
        private static SqlConnection connection;
        private string connectionString;

        public DbManager()
        {
            StreamReader fs = new StreamReader("db_credentials.cn", Encoding.ASCII);

            string username = fs.ReadLine();
            string password = fs.ReadLine();

            connectionString = string.Format(@"data source=DESKTOP-VFJQT9I\NIK;user={0};password={1};database=ThesisProject;", username, password);
            connection = new SqlConnection(connectionString);

            //Testing the connection
            connection.Open();
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

        public static DataTable Where(string tableName, Dictionary<string, Object> dict, string whereClause)
        {
            connection.Open();

            StringBuilder sb = new StringBuilder();

            sb.Append(string.Format("Select * From {0} Where ", tableName));

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

        public static DataTable WhereAnd(string tableName, Dictionary<string, Object> dict)
        {
            return Where(tableName, dict, "AND");
        }

        public static DataTable WhereOr(string tableName, Dictionary<string, Object> dict)
        {
            return Where(tableName, dict, "OR");
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
                sqlCmd.Parameters.AddWithValue(string.Concat("@", obj.Key), obj.Value.ToString());
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

        public static DataTable All(string tableName)
        {
            SqlDataAdapter da = new SqlDataAdapter(string.Format("Select * From {0}", tableName), connection);

            DataTable dt = new DataTable();

            da.Fill(dt);
            return dt;
        }
    }
}
