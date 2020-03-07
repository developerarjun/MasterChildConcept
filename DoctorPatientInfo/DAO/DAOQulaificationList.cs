using DoctorPatientInfo.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DoctorPatientInfo.DAO
{

    public class DAOQulaificationList
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["mycon"].ToString());

        public List<M_QualificationList> GetQualificationList()
        {
            List<M_QualificationList> lstQualificationList = new List<M_QualificationList>();
          
            SqlCommand cmd = new SqlCommand("spQualificationList", con);
            cmd.CommandType = CommandType.StoredProcedure;

            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    M_QualificationList objATT = new M_QualificationList();
                    objATT.QualId = Convert.ToInt32(dr["QId"]);
                    objATT.QualName = dr["QName"].ToString();

                    lstQualificationList.Add(objATT);
                }

            }
            return lstQualificationList;


        }
    }
}
