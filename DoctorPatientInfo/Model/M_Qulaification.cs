using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoctorPatientInfo.Model
{
    public class M_Qulaification
    {
        public int DoctorId { get; set; }
        public int QualId { get; set; }
        public string Marks { get; set; }
        public string Action { get; set; }
        public string QualName { get;  set; }
    }
}