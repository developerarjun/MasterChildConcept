using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace Utility
{
    public static class DAO2
    {
        static DAO2()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static string connectionStr
        {
            get { return ConfigurationManager.ConnectionStrings["mycon"].ConnectionString; }
        }

        public static SqlConnection getConnection()
        {
            SqlConnection con = new SqlConnection(DAO2.connectionStr);
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            return con;
        }

        //public static int executeProcedure(string StoreProcName, SqlParameter[] param)
        //{
        //    using (SqlConnection con = DAO2.getConnection())
        //    {
        //        using (SqlCommand cmd = con.CreateCommand())
        //        {
        //            cmd.CommandText = StoreProcName;
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            if (param != null)
        //            {
        //                cmd.Parameters.AddRange(param);
        //            }
        //            return cmd.ExecuteNonQuery();
        //        }
        //    }
        //}

        //public static int executeTranProcedure(string StoreProcName, SqlParameter[] param, SqlTransaction tran, SqlConnection con)
        //{
        //    using (SqlCommand cmd = con.CreateCommand())
        //    {
        //        cmd.CommandText = StoreProcName;
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        if (tran != null)
        //        {
        //            cmd.Transaction = tran;
        //        }
        //        if (param != null)
        //        {
        //            cmd.Parameters.AddRange(param);
        //        }
        //        return cmd.ExecuteNonQuery();
        //    }
        //}

        public static DataSet gettable(string StoreProcName, SqlParameter[] param)
        {
            DataSet ds = new DataSet();
            using (SqlConnection con = DAO2.getConnection())
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText = StoreProcName;
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (param != null)
                    {
                        cmd.Parameters.AddRange(param);
                    }
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {

                        da.Fill(ds);

                    }
                    return ds;
                }
            }


        }
    }
}
