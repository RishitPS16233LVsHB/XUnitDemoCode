using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace XUnitDemo
{
    public class SqlDBConnectionModule
    {
        private static readonly string _connectionString = @"Data Source=DTBLR01LP270\MSSQLSERVER1;Initial Catalog=StudentDB;Integrated Security=True;Encrypt=False";

        /// <summary>
        /// Gets sql connection
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        private static IDbConnection GetSqlConnection()
        {
            IDbConnection connection = new SqlConnection(_connectionString);
            connection.Open();
            return connection; // Return the connection if successful
        }

        /// <summary>
        /// Executes and returns list of T type objects
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <returns></returns>
        public static List<T> ExecuteList<T>(string query, object parameters = null)
        {
            using (IDbConnection connection = GetSqlConnection())
            {
                return connection.Query<T>(query,parameters).AsList(); // Execute the query and return a list of T
            }
        }

        /// <summary>
        /// Executes and returns one T type oject from the query
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <returns></returns>
        public static T ExecuteScalar<T>(string query, object parameters = null)
        {
            using (IDbConnection connection = GetSqlConnection())
            {
                return connection.ExecuteScalar<T>(query,parameters); // Execute the query and return a single value of type T
            }
        }
        /// <summary>
        /// Executes Method to execute a non-query (INSERT, UPDATE, DELETE)
        /// </summary>
        /// <param name="query"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string query, object parameters = null)
        {
            using (IDbConnection connection = GetSqlConnection())
            {
                return connection.Execute(query, parameters); // Return number of affected rows
            }
        }


        /// <summary>
        /// Checks if connections was successful or not
        /// </summary>
        /// <returns></returns>
        public static bool CheckConnection()
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open(); // Attempt to open the connection
                    return true; // Connection successful
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"SQL error: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

            return false; // Return false if the connection fails
        }
    }
}
