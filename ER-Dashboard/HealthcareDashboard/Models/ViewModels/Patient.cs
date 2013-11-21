using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HealthcareDashboard.Models.ViewModels
{
    public class Patient
    {
        public string Name { get; set; }
        public string SeverityImageUrl { get; set; }
        public string Diagnosis { get; set; }
        public string Disposition { get; set; }
        public bool? Visited { get; set; }
        public int? PatientID { get; set; }
        public int AdmittanceID { get; set; }
    }
}