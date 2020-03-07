using DoctorPatientInfo.DAO;
using DoctorPatientInfo.Model;
using DoctorPatientInfo.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoctorPatientInfo.BLL
{
    public class BLLDoctor
    {

        public JsonResponse SaveDoctor(M_Doctor Doc)
        {
            
            JsonResponse response = new JsonResponse();
            try
            {
                DAODoctor doctor = new DAODoctor();
                response.ResponseData = doctor.InsertData(Doc);
                response.IsSuccess = true;

            }
            catch(Exception ex)
            {
                response.ResponseData = ex.Message;
                response.ResponseData = false;

            }
            return response;
        }

        public JsonResponse GetDoctor()
        {
            JsonResponse response = new JsonResponse();
            try
            {

                DAODoctor objDll = new DAODoctor();
                response.ResponseData = objDll.GetDoctor();
                response.IsSuccess = true;

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsSuccess = false;

            }
            return response;

        }

        public JsonResponse GetDoctorDetails(string DoctorId)
        {
            JsonResponse response = new JsonResponse();
            try
            {

                DAODoctor objDll = new DAODoctor();
                response.ResponseData = objDll.GetDoctorDetails(DoctorId);
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