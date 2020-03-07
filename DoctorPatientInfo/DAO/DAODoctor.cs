using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using DoctorPatientInfo.Model;
using Utility;
namespace DoctorPatientInfo.DAO
{
    public class DAODoctor
    {

       
        public string InsertData(M_Doctor objDoctor)
        {
            string msg = "";
            SqlConnection con = DAO2.getConnection();

            using (con)
            {
                SqlTransaction tran;
                tran = con.BeginTransaction();
                try
                {

                    SqlCommand cmd;


                    if (objDoctor.Action != null)
                    {
                        if (objDoctor.Action == "A")
                        {
                            cmd = new SqlCommand("SpInsertDoctor", con, tran);
                        }
                        else
                        {
                            cmd = new SqlCommand("spUpdateDoctor", con, tran);
                        }
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@DoctorName", SqlDbType.VarChar,200).Value = objDoctor.Name;
                        cmd.Parameters.Add("@BirthDate", SqlDbType.VarChar, 200).Value = objDoctor.BirthDate;
                        cmd.Parameters.Add("@Gender", SqlDbType.VarChar, 200).Value = objDoctor.Gender;
                        cmd.Parameters.Add("@Salary", SqlDbType.VarChar, 200).Value = objDoctor.Salary;

                        cmd.Parameters.Add("@id", SqlDbType.Int).Value = objDoctor.DoctorId;
                        cmd.Parameters["@id"].Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                        objDoctor.DoctorId = (int)cmd.Parameters["@id"].Value;
                        
                      //  SqlParameter param = cmd.Parameters.AddWithValue("@Return", null);
                      
                      //  objDoctor.DoctorId = (int)cmd.Parameters["@Return"].Value;
                        if (objDoctor.Action == "A")
                        {
                            foreach (var item in objDoctor.Qualification)
                            {
                                item.DoctorId = objDoctor.DoctorId;
                            }
                            DAOQualification dllQualification = new DAOQualification();
                            dllQualification.SaveQualification(objDoctor.Qualification, con,tran);

                        }
                        else
                        {
                            foreach (var item in objDoctor.Qualification)
                            {
                                item.DoctorId = objDoctor.DoctorId;
                            }
                            DAOQualification dllQualification = new DAOQualification();
                            dllQualification.SaveQualification(objDoctor.Qualification, con, tran);

                        }
                        tran.Commit();

                    }
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw new Exception("Error" + ex.Message);
                }
            }
            return msg;


        }

        
        public List<M_Doctor> GetDoctor()
        {
            //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());
            List<M_Doctor> lstDoctor = new List<M_Doctor>();

            //SqlCommand cmd = new SqlCommand("GetDoctor", con);
            //cmd.CommandType = CommandType.StoredProcedure;

            DataSet ds = new DataSet();
            ds = DAO2.gettable("GetDoctor", null);
            
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    M_Doctor objDoc = new M_Doctor();

                    objDoc.DoctorId = Convert.ToInt32(dr["DoctorId"]);
                    objDoc.Name = dr["DoctorName"].ToString();
                    objDoc.BirthDate = dr["BirthDate"].ToString();
                    objDoc.Gender = dr["Gender"].ToString();                   
                    objDoc.Salary = dr["Salary"].ToString();
                    lstDoctor.Add(objDoc);
                }

            }
            return lstDoctor;

        }

        public List<M_Doctor> GetDoctorDetails(string DoctorId)
        {
            DAOQualification dd = new DAOQualification();
            List<M_Doctor> lstDetails = new List<M_Doctor>();

            DataSet ds = new DataSet();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@DoctorID", DoctorId);
            ds = DAO2.gettable("GetDoctorDetails", param);


            if (ds.Tables[0].Rows.Count > 0)
            {

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    M_Doctor objDoc = new M_Doctor();
                    objDoc.DoctorId = Convert.ToInt32(dr["DoctorId"]);
                    objDoc.Name = dr["DoctorName"].ToString();
                    objDoc.BirthDate = dr["BirthDate"].ToString();
                    objDoc.Gender = dr["Gender"].ToString();                   
                    objDoc.Salary = dr["Salary"].ToString();
                    objDoc.Qualification = dd.GetQualificationDetails(objDoc.DoctorId);
                    lstDetails.Add(objDoc);
                }

            }
            return lstDetails;

        }


    }
}