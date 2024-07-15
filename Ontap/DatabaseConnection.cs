using System;
using System.Data;
using System.Data.SqlClient;

namespace Ontap
{
    public class DatabaseConnection
    {
        private string connectionString;

        // Constructor có thể truyền chuỗi kết nối vào
        public DatabaseConnection(string connectionString)
        {
            this.connectionString = connectionString;
        }

        // Phương thức mở kết nối
        private SqlConnection OpenConnection()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            return con;
        }

        // Phương thức đóng kết nối
        private void CloseConnection(SqlConnection con)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }

        // Phương thức thực thi truy vấn trả về DataTable
        public DataTable ExecuteQuery(string sql)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = OpenConnection())
            {
                try
                {
                    using (SqlDataAdapter adap = new SqlDataAdapter(sql, con))
                    {
                        adap.Fill(dt);
                    }
                }
                catch (Exception ex)
                {
                    // Xử lý ngoại lệ
                    throw new Exception("Error executing query: " + ex.Message);
                }
                finally
                {
                    CloseConnection(con);
                }
            }
            return dt;
        }

        // Phương thức thực thi câu lệnh không trả về kết quả (INSERT, UPDATE, DELETE)
        public int ExecuteNonQuery(string sql)
        {
            int rowsAffected = 0;
            using (SqlConnection con = OpenConnection())
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        rowsAffected = cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    // Xử lý ngoại lệ
                    throw new Exception("Error executing non-query: " + ex.Message);
                }
                finally
                {
                    CloseConnection(con);
                }
            }
            return rowsAffected;
        }

        // Phương thức thực thi câu lệnh trả về giá trị duy nhất (SELECT COUNT(*), MAX(id), ...)
        public object ExecuteScalar(string sql)
        {
            object result = null;
            using (SqlConnection con = OpenConnection())
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        result = cmd.ExecuteScalar();
                    }
                }
                catch (Exception ex)
                {
                    // Xử lý ngoại lệ
                    throw new Exception("Error executing scalar: " + ex.Message);
                }
                finally
                {
                    CloseConnection(con);
                }
            }
            return result;
        }
    }
}
