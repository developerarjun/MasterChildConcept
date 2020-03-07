using DoctorPatientInfo.BLL;
using DoctorPatientInfo.Model;
using DoctorPatientInfo.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Utility;

namespace DoctorPatientInfo.Handler
{
    /// <summary>
    /// Summary description for HandlerOfDoctor
    /// </summary>
    public class HandlerOfDoctor : BaseHandler
    {

        public object SaveDoctor(string args)
        {

            JsonResponse response = new Utility.JsonResponse();
            M_Doctor objDoc = Utility.JsonUtility.DeSerialize(args, typeof(M_Doctor)) as M_Doctor;
            BLLDoctor bllObj = new BLLDoctor();
            response = bllObj.SaveDoctor(objDoc);
            return JsonUtility.Serialize(response);

        }

        public object GetQualificationList(int QualId)
        {
            JsonResponse response = new JsonResponse();
            BLLQualificationList bllQualificationList = new BLLQualificationList();
            response = bllQualificationList.GetQualificationList();
            return JsonUtility.Serialize(response);

        }

        public object GetDoctor()
        {

            JsonResponse response = new JsonResponse();
            BLLDoctor bllDoctor = new BLLDoctor();
            response= bllDoctor.GetDoctor();
            return JsonUtility.Serialize(response);
        }


        public object GetDoctorDetails(string DoctorId)
        {
            JsonResponse response = new JsonResponse();
            BLLDoctor bllDoctor = new BLLDoctor();
            response = bllDoctor.GetDoctorDetails(DoctorId);
            return JsonUtility.Serialize(response);


        }

        public object GetQualificationDetails(int DoctorId)
        {
            JsonResponse response = new JsonResponse();
             BLLQualification bllQualification = new BLLQualification();
             response = bllQualification.GetDoctorDetails(DoctorId);
            return JsonUtility.Serialize(response);


        }

    }
}