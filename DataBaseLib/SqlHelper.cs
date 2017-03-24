using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DataBaseLib
{
    public class SqlHelper
    {
        private static SqlHelper _sqlHelper;
        private static object _locker = new object();

        private string _connectionString;

        public string ConnectionString
        {
            get { return _connectionString; }
        }
        public static SqlHelper Instance
        {
            get
            {
                if (_sqlHelper == null)
                {

                    lock (_locker)
                    {
                        _sqlHelper = new SqlHelper();
                    }
                }
                return _sqlHelper;
            }
        }

        public SqlHelper()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["PettoStudio.AppServices"].ConnectionString;
        }

        /// <summary>
        /// 执行Sql语句
        /// </summary>
        /// <param name="command"></param>
        public int ExecuteCommand(string command)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(command, conn))
                    {
                        conn.Open();
                        return cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 单项
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public object ExecuteScalar(string command)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(command, conn))
                    {
                        conn.Open();
                        object res = cmd.ExecuteScalar();
                        return res;
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public void ExecuteProcedure(string spName, Dictionary<string, string> parameters)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(spName, conn))
                    {
                        conn.Open();
                        cmd.CommandType = CommandType.StoredProcedure;

                        foreach (var item in parameters)
                        {
                            cmd.Parameters.AddWithValue(item.Key, item.Value);
                        }

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }

        }


        /// <summary>
        /// DataTable
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public DataTable ExecuteDataTable(string command)
        {
            try
            {
                DataTable dt = new DataTable();
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    SqlDataAdapter da = new SqlDataAdapter(command, conn);
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
