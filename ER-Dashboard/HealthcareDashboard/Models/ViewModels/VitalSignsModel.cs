using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HealthcareDashboard.Models.ViewModels
{
    public class VitalSignsModel
    {
        public IEnumerable<ViewModels.ItemType> VitalSignsTypes { get; set; }
        public IEnumerable<VitalSignsItem> VitalSignsForPatient { get; set; }
    }
}