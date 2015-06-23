using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DataAccess
{
    public class DataAccess
    {
        static string strConn = "Server=SQL;Database=Hydro_final;User Id=Hydrogen;Password=Codeflange4life1;";
        private static SqlConnection Connect()
        {
            try
            {
                SqlConnection sqlConn = new SqlConnection(strConn);
                return sqlConn;
            }
            catch(SqlException e) 
            {
                throw e;
            }
        }

        private static List<List<object>> Query(string query)
        {
            SqlConnection conn = null;
            try
            {
                conn = Connect();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = query;
                cmd.Connection = conn;
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                List<List<object>> retval = new List<List<object>>();
                try
                {

                    while (reader.Read())
                    {
                        List<object> row = new List<object>();
                        
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            row.Add(reader[i]);
                        }

                        retval.Add(row);
                    }
                }
                finally
                {
                    // Always call Close when done reading.
                    reader.Close();
                }

                string result = Convert.ToString(retval);
                if (string.IsNullOrEmpty(result))
                {
                    Console.WriteLine("No record found!");
                }
                else
                {
                    Console.WriteLine(result);
                }

                conn.Close();
                return retval;
            }
            catch (SqlException e)
            {
                throw e;
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }
        }
        public static List<List<object>> Read(string[] tables, string[] columns = null, string[] where = null)
        {
            string queryString = "SELECT ";
            if (columns == null)
            {
                queryString += "* ";
            } 
            else
            {
                queryString += String.Join(", ", columns);
            }

            queryString += " FROM ";

            if (tables.Length > 1)
            {
                queryString += String.Join(" INNER JOIN ", tables);
            }
            else
            {
                queryString += tables[0];
            }

            if (where != null && where.Length > 0)
            {
                if (tables.Length > 1)
                    queryString += " ON ";
                else
                    queryString += " WHERE ";
                queryString += String.Join(" AND ", where);
            }

            return Query(queryString);
        }

        public static object Create(string table, string[] columns, List<string[]> values)
        {
            string queryString = "INSERT INTO " + table + "(";
            queryString += String.Join(", ", columns) + ") VALUES ";

            for (int i = 0; i < values.Count; i++)
            {
                string[] row = values[i];
                queryString += "(";
                for (int j = 0; j < row.Length; j++)
                {
                    if (j != 0)
                    {
                        queryString += ", ";
                    }
                    queryString += "'" + row[j] + "'";
                }
                queryString += ")";
                if (i + 1 < values.Count)
                {
                    queryString += ", ";
                }
            }
            return Query(queryString);
        }

        public static object Update(string table, string[] columns, string[] values, string[] where = null)
        {
            string queryString = "UPDATE " + table + " SET ";
            for (int i = 0; i < columns.Length; i++)
            {
                if (i != 0)
                {
                    queryString += ", ";
                }
                queryString += columns[i] + " = '" + values[i] + "'";
            }

            if (where != null)
            {
                queryString += " WHERE " + String.Join(" AND ", where);
            }
            return Query(queryString);
        }

        public static object Delete()
        {
            return null;
        }     
    }
}
