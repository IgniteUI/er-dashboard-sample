using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERDashboard.Models.ViewModels
{
    public class MedTestItem
    {
        public int ID { get; set; }
        public int? TestTypeID { get; set; }
        public string TestTypeName { get; set; }
        public int? AdmittanceID { get; set; }
        public DateTime? Timestamp { get; set; }
        public string Result { get; set; }
        public int? BodyRegionID { get; set; }
    }
}
