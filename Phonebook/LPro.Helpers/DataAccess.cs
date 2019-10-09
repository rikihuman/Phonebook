using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Phonebook.Helpers
{
    public class DataAccess
    {

        public static string GetConnectionString()
        {
#if (DEBUG)
            return ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString;
#else
            return ConfigurationManager.ConnectionStrings["ApplicationServicesLive"].ConnectionString;
#endif
        }

        public static DataTable RunFillDataTable(SqlCommand cmd)
        {
            try
            {
                cmd.Connection = new SqlConnection();
                cmd.Connection.ConnectionString = GetConnectionString();
                if (cmd.Connection.State == ConnectionState.Closed)
                    cmd.Connection.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                return dt;
            }
            catch (Exception e)
            {
               string d= e.Message;
                return new DataTable();
            }
            finally
            {
                if (cmd.Connection != null)
                    cmd.Connection.Close();
            }
        }

        public static DataTable RunFillDataTableEncrypt(SqlCommand cmd)
        {
            try
            {
                cmd.Connection = new SqlConnection();
                cmd.Connection.ConnectionString = GetConnectionString();
                if (cmd.Connection.State == ConnectionState.Closed)
                    cmd.Connection.Open();
                DataTable dt = new DataTable();
                DataTable dtEncrypted = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i][3] = Controller.Cryptor.encrypt(dt.Rows[i][3].ToString());
                    dt.Rows[i][4] = Controller.Cryptor.encrypt(dt.Rows[i][4].ToString());
                    dt.Rows[i][5] = Controller.Cryptor.encrypt(dt.Rows[i][5].ToString());
                    dt.Rows[i][6] = Controller.Cryptor.encrypt(dt.Rows[i][6].ToString());
                    dt.Rows[i][7] = Controller.Cryptor.encrypt(dt.Rows[i][7].ToString());
                    dt.Rows[i][8] = Controller.Cryptor.encrypt(dt.Rows[i][8].ToString());
                    dt.Rows[i][9] = Controller.Cryptor.encrypt(dt.Rows[i][9].ToString());
                 
                    //for (int j = 0; j < dt.Columns.Count; j++)
                    //{
                    //    dt.Rows[i][j] = Controller.Cryptor.encrypt(dt.Rows[i][j].ToString());
                    //}

                }
                return dt;
            }
            catch (Exception e)
            {
                return new DataTable();
            }
            finally
            {
                if (cmd.Connection != null)
                    cmd.Connection.Close();
            }
        }


        public static bool RunBoolExecuteNonQuery(SqlCommand cmd)
        {
            try
            {
                cmd.Connection = new SqlConnection();
                cmd.Connection.ConnectionString = GetConnectionString();
                if (cmd.Connection.State == ConnectionState.Closed)
                    cmd.Connection.Open();
                foreach (SqlParameter parameter in cmd.Parameters)
                {
                    if (parameter.Value == null)
                    {
                        parameter.Value = DBNull.Value;
                    }
                }
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
               string error= e.Message;
                
                return false;
            }
            finally
            {
                if (cmd.Connection != null)
                    cmd.Connection.Close();
            }
        }


        public static object RunExecuteScalar(SqlCommand cmd, bool closeConn)
        {
            try
            {
                cmd.Connection = new SqlConnection();
                cmd.Connection.ConnectionString = GetConnectionString();
                if (cmd.Connection.State == ConnectionState.Closed)
                    cmd.Connection.Open();
                foreach (SqlParameter parameter in cmd.Parameters)
                {
                    if (parameter.Value == null)
                    {
                        parameter.Value = DBNull.Value;
                    }
                }
                return cmd.ExecuteScalar();
            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                if (closeConn)
                {
                    if (cmd.Connection != null)
                        cmd.Connection.Close();
                }
            }
        }
    }
}
