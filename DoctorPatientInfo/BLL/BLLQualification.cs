using DoctorPatientInfo.DAO;
using DoctorPatientInfo.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace DoctorPatientInfo.BLL
{
    public class BLLQualification
    {
        public JsonResponse GetDoctorDetails(int DoctorId)
        {
            JsonResponse response = new JsonResponse();
            try
            {

                DAOQualification objDll = new DAOQualification();
                response.ResponseData = objDll.GetQualificationDetails(DoctorId);
                response.IsSuccess = true;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSuccess = false;

            }
            return response;

        }
    }
}