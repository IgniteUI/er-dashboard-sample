using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HealthcareDashboard.Models.ViewModels
{
    public class VitalSignsItem
    {
        public int ID { get; set; }
        public int? AdmittanceID { get; set; }
        public DateTime? Timestamp { get; set; }
        public string VitalSignValue { get; set; }
        public int? VitalSignTypeID { get; set; }
        public string VitalSignType { get; set; }

        public int BloodPressureLow { get; set; }
    }
}