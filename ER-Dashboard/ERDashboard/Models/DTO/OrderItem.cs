using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ERDashboard.Models.ViewModels
{
    public class OrderItem
    {
        public int ID { get; set; }
        public int? AdmittanceID { get; set; }
        public int? MedID { get; set; }
        public string MedName { get; set; }
        public int? Dosage { get; set; }
        public string Unit { get; set; }
        public string Frequency { get; set; }
        public string Indication { get; set; }
        public DateTime? Timestamp { get; set; }
    }
}
