using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoctorPatientInfo.Model
{
    public class M_Doctor
    {      
        public int DoctorId { get; set;}    
        public string Name { get; set; }
        public string BirthDate { get; set; }     
        public string Gender { get; set; }
        public string Salary { get; set; }
     

        public string Action { get; set; }

        private List<M_Qulaification> _Qualification = new List<M_Qulaification>();

        public List<M_Qulaification> Qualification
        {
            get { return _Qualification; }
            set { _Qualification = value; }
        }
    }
}