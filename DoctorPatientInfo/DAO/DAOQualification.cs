using DoctorPatientInfo.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Utility;

namespace DoctorPatientInfo.DAO
{
    public class DAOQualification
    {
      
        public void SaveQualification(List<M_Qulaification> qua, SqlConnection con, SqlTransaction tran)
        {
            try
            {
                SqlCommand cmd;
                foreach (var doctor in qua)
                {
                    if (doctor.Action == "A")
                    {
                        cmd = new SqlCommand("InsertQualification", con, tran);
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@DoctorId", doctor.DoctorId);
                        cmd.Parameters.AddWithValue("@QualId", doctor.QualId);
                        cmd.Parameters.AddWithValue("@Marks", doctor.Marks);
                    }
                    else if (doctor.Action == "E")
                    {
                        cmd = new SqlCommand("UpdateQualification", con, tran);
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@DoctorId", doctor.DoctorId);
                        cmd.Parameters.AddWithValue("@QualId", doctor.QualId);
                        cmd.Parameters.AddWithValue("@Marks", doctor.Marks);
                    }
                    else
                    {
                        cmd = new SqlCommand("DeleteQualification", con, tran);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@DoctorId", doctor.DoctorId);
                        cmd.Parameters.AddWithValue("@QualId", doctor.QualId);
                    }
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public List<M_Qulaification> GetQualificationDetails(int DoctorId)
        {

            List<M_Qulaification> lstQualification = new List<M_Qulaification>();

            DataSet ds = new DataSet();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@DoctorId", DoctorId);
            ds = DAO2.gettable("GetQualificationDetails", param);

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    M_Qulaification objATT = new M_Qulaification();
                    objATT.DoctorId = Convert.ToInt32(dr["Doctor_Id"]);
                    objATT.QualName = dr["Qname"].ToString();
                    objATT.QualId = Convert.ToInt32(dr["Q_Id"]);
                    objATT.Marks = dr["Marks"].ToString();

                    objATT.Action = "E";
                    lstQualification.Add(objATT);
                }

            }
            return lstQualification;

        }

    }


  
}