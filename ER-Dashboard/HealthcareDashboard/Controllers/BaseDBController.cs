using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HealthcareDashboard.Models;

namespace HealthcareDashboard.Controllers
{
    public abstract class BaseDBController : Controller
    {
        /*
         * Wraps the DBContext object for database access. Overrides IDisposable to release DB resources.
         */
        private MedicalDataEntities _dbContext = new MedicalDataEntities();
        protected MedicalDataEntities DbContext
        {
            get
            {
                if (_dbContext == null)
                    _dbContext = new MedicalDataEntities();

                return _dbContext;
            }
        }

        #region IDisposable

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
            base.Dispose(disposing);
        }

        #endregion

    }
}
