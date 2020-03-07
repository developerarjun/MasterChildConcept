using DoctorPatientInfo.DAO;
using DoctorPatientInfo.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoctorPatientInfo.BLL
{

    public class BLLQualificationList
    {
        public JsonResponse GetQualificationList()
        {
            JsonResponse response = new JsonResponse();
            try
            {

                DAOQulaificationList objList = new DAOQulaificationList();
                response.ResponseData = objList.GetQualificationList();
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }
    }
}