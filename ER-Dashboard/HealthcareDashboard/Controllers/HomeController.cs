using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

using HealthcareDashboard.Models;
using HealthcareDashboard.Models.DTO;
using HealthcareDashboard.Models.ViewModels;
using System.Reflection;

namespace HealthcareDashboard.Controllers
{
    public class HomeController : BaseDBController
    {

        #region Public Action Methods
        //
        // GET: /Home/
        public ActionResult Index()
        {
            var showcaseLangauge = GetUserResourceFile(Request.Headers["Accept-Language"]);
            ViewBag.ResourceFile = showcaseLangauge.ResourceFile;
            ViewBag.Language = showcaseLangauge.Language;
            ViewBag.DllVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            
            return View();
        }

        public JsonResult GetPatients()
        {
            return new JsonResult
            {
                Data = new
                {
                    Results = Models.DTO.Mapper.Map(DbContext.Admittances, Url.Content("~/Content/images"))
                },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        public JsonResult GetVitalSignTypes()
        {
            return new JsonResult
            {
                Data = Mapper.Map(DbContext.VitalSignTypes),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        [HttpPost]
        public JsonResult GetVitalSignData(int admittanceID)
        {
           return new JsonResult {
                Data = Mapper.Map(
                        DbContext.Vitals.Where(item => item.AdmittanceID == admittanceID).OrderBy(ke => ke.Timestamp.Value.Hour)
                    )
            };
        }
        public ActionResult GenerateTests()
        {
            using (DbContext)
            {
                Random rnd = new Random();
                for (int id = 20; id < 34; id++)
                {
                    double testValue;
                    #region Hemoglobin

                    for (int hour = 7; hour < 13; hour++)
                    {
                        //for every hour
                        for (int minutes = 0; minutes < 50; minutes += 30)
                        {
                            testValue = rnd.NextDouble() * (14.0 - 19.0) + 19.0;
                            testValue = Math.Round(testValue, 1);
                            Test item = new Test()
                            {
                                //Hemoglobin
                                TestTypeID = 6,
                                AdmittanceID = id,
                                Timestamp = new DateTime(2009, 6, 25, hour, minutes, 00),
                                Result = testValue.ToString()
                            };
                            DbContext.Tests.Add(item);
                        }

                    }
                    for (int hour = 17; hour < 20; hour++)
                    {
                        //for every hour
                        for (int minutes = 0; minutes < 50; minutes += 30)
                        {
                            testValue = rnd.NextDouble() * (14.0 - 19.0) + 19.0;
                            testValue = Math.Round(testValue, 1);
                            Test item = new Test()
                            {
                                //Hemoglobin
                                TestTypeID = 6,
                                AdmittanceID = id,
                                Timestamp = new DateTime(2009, 6, 25, hour, minutes, 00),
                                Result = testValue.ToString()
                            };
                            DbContext.Tests.Add(item);
                        }

                    }
                    #endregion
                    #region Hematocrit

                    for (int hour = 7; hour < 13; hour++)
                    {
                        //for every hour
                        for (int minutes = 0; minutes < 50; minutes+= 30)
                        {
                            testValue = rnd.Next(42, 55);    
                            Test item = new Test()
                            {
                                //Hematocrit
                                TestTypeID = 7,
                                AdmittanceID = id,
                                Timestamp = new DateTime(2009, 6, 25, hour, minutes, 00),
                                Result = testValue.ToString()
                            };
                            DbContext.Tests.Add(item);
                        }

                    }
                    for (int hour = 17; hour < 20; hour++)
                    {
                        //for every hour
                        for (int minutes = 0; minutes < 50; minutes += 30)
                        {
                            testValue = rnd.Next(42, 55);
                            Test item = new Test()
                            {
                                //Hemoglobin
                                TestTypeID = 7,
                                AdmittanceID = id,
                                Timestamp = new DateTime(2009, 6, 25, hour, minutes, 00),
                                Result = testValue.ToString()
                            };
                            DbContext.Tests.Add(item);
                        }

                    }
                    #endregion
                    #region MCV

                    for (int hour = 7; hour < 13; hour++)
                    {
                        //for every hour
                        for (int minutes = 0; minutes < 50; minutes += 30)
                        {
                            testValue = rnd.Next(80, 104);
                            Test item = new Test()
                            {
                                //ID = DbContext.Vitals.Count() + 10,
                                //MCV
                                TestTypeID = 8,
                                AdmittanceID = id,
                                Timestamp = new DateTime(2009, 6, 25, hour, minutes, 00),
                                Result = testValue.ToString()
                            };
                            DbContext.Tests.Add(item);
                        }

                    }
                    for (int hour = 17; hour < 20; hour++)
                    {
                        //for every hour
                        for (int minutes = 0; minutes < 50; minutes += 30)
                        {
                            testValue = rnd.Next(80, 104);
                            Test item = new Test()
                            {
                                //ID = DbContext.Vitals.Count() + 10,
                                //MCV
                                TestTypeID = 8,
                                AdmittanceID = id,
                                Timestamp = new DateTime(2009, 6, 25, hour, minutes, 00),
                                Result = testValue.ToString()
                            };
                            DbContext.Tests.Add(item);
                        }

                    }
                    #endregion
                    #region MCHC

                    for (int hour = 7; hour < 13; hour++)
                    {
                        //for every hour
                        for (int minutes = 0; minutes < 50; minutes += 30)
                        {
                            testValue = rnd.Next(25, 50);
                            Test item = new Test()
                            {
                                //MCHC
                                TestTypeID = 9,
                                AdmittanceID = id,
                                Timestamp = new DateTime(2009, 6, 25, hour, minutes, 00),
                                Result = testValue.ToString()
                            };
                            DbContext.Tests.Add(item);
                        }

                    }
                    for (int hour = 17; hour < 20; hour++)
                    {
                        //for every hour
                        for (int minutes = 0; minutes < 50; minutes += 30)
                        {
                            testValue = rnd.Next(25, 50);
                            Test item = new Test()
                            {
                                //MCHC
                                TestTypeID = 9,
                                AdmittanceID = id,
                                Timestamp = new DateTime(2009, 6, 25, hour, minutes, 00),
                                Result = testValue.ToString()
                            };
                            DbContext.Tests.Add(item);
                        }

                    }
                    #endregion
                    #region RDW

                    for (int hour = 7; hour < 13; hour++)
                    {
                        //for every hour
                        for (int minutes = 0; minutes < 50; minutes += 30)
                        {
                            testValue = rnd.Next(28, 46);
                            Test item = new Test()
                            {
                                //RDW
                                TestTypeID = 10,
                                AdmittanceID = id,
                                Timestamp = new DateTime(2009, 6, 25, hour, minutes, 00),
                                Result = testValue.ToString()
                            };
                            DbContext.Tests.Add(item);
                        }

                    }
                    for (int hour = 17; hour < 20; hour++)
                    {
                        //for every hour
                        for (int minutes = 0; minutes < 50; minutes += 30)
                        {
                            testValue = rnd.Next(28, 46);
                            Test item = new Test()
                            {
                                //RDW
                                TestTypeID = 10,
                                AdmittanceID = id,
                                Timestamp = new DateTime(2009, 6, 25, hour, minutes, 00),
                                Result = testValue.ToString()
                            };
                            DbContext.Tests.Add(item);
                        }

                    }
                    #endregion
                    #region RBC
                    for (int hour = 7; hour < 13; hour++)
                    {
                        //for every hour
                        for (int minutes = 0; minutes < 50; minutes += 30)
                        {
                            testValue = rnd.NextDouble() * (4.5 - 9.5) + 9.5;
                            testValue = Math.Round(testValue, 1);
                            Test item = new Test()
                            {

                                //RBC
                                TestTypeID = 5,
                                AdmittanceID = id,
                                Timestamp = new DateTime(2009, 6, 25, hour, minutes, 00),
                                Result = testValue.ToString()
                            };
                            DbContext.Tests.Add(item);
                        }

                    }
                    for (int hour = 17; hour < 20; hour++)
                    {
                        //for every hour
                        for (int minutes = 0; minutes < 50; minutes += 30)
                        {
                            testValue = rnd.NextDouble() * (4.5 - 9.5) + 9.5;
                            testValue = Math.Round(testValue, 1);
                            Test item = new Test()
                            {
                                //RBC
                                TestTypeID = 5,
                                AdmittanceID = id,
                                Timestamp = new DateTime(2009, 6, 25, hour, minutes, 00),
                                Result = testValue.ToString()
                            };
                            DbContext.Tests.Add(item);
                        }

                    }
                    #endregion
                    #region WBC
                    for (int hour = 7; hour < 13; hour++)
                    {
                        //for every hour
                        for (int minutes = 0; minutes < 50; minutes += 30)
                        {
                            testValue = rnd.NextDouble() * (6.0 - 10.0) + 10.0;
                            testValue = Math.Round(testValue, 1);
                            Test item = new Test()
                            {

                                //WBC
                                TestTypeID = 4,
                                AdmittanceID = id,
                                Timestamp = new DateTime(2009, 6, 25, hour, minutes, 00),
                                Result = testValue.ToString()
                            };
                            DbContext.Tests.Add(item);
                        }

                    }
                    for (int hour = 17; hour < 20; hour++)
                    {
                        //for every hour
                        for (int minutes = 0; minutes < 50; minutes += 30)
                        {
                            testValue = rnd.NextDouble() * (6.0 - 10.0) + 10.0;
                            testValue = Math.Round(testValue, 1);
                            Test item = new Test()
                            {
                                //WBC
                                TestTypeID = 4,
                                AdmittanceID = id,
                                Timestamp = new DateTime(2009, 6, 25, hour, minutes, 00),
                                Result = testValue.ToString()
                            };
                            DbContext.Tests.Add(item);
                        }

                    }
                    #endregion
                }
                //DbContext.SaveChanges();
            }
            return View();
        }
        public ActionResult GenerateVitals()
        {

            using (DbContext)
            {
                Random rnd = new Random();
                for (int id = 20; id < 34; id++)
                {
                    double vitalValue;
                    #region Temperature
                    for (int hour = 7; hour < 13; hour++)
                    {
                        //for every hour
                        for (int minutes = 0; minutes < 50; minutes+= 30)
                        {
                            vitalValue = rnd.NextDouble() * (106.0 - 98.0) + 98.0;
                            vitalValue = Math.Round(vitalValue, 1);
                            Vital item = new Vital()
                            {
                                //ID = DbContext.Vitals.Count() + 10,
                                //Temperature
                                VitalSignTypeID = 1,
                                AdmittanceID = id,
                                Timestamp = new DateTime(2009, 6, 25, hour, minutes, 00),
                                VitalSignValue = vitalValue.ToString()
                            };
                            DbContext.Vitals.Add(item);
                        }
                    
                    }

                    //After 16
                    for (int hour = 17; hour < 20; hour++)
                    {
                        //for every hour
                        for (int minutes = 0; minutes < 50; minutes += 30)
                        {
                            vitalValue = rnd.NextDouble() * (106.0 - 98.0) + 98.0;
                            vitalValue = Math.Round(vitalValue, 1);
                            Vital item = new Vital()
                            {
                                //ID = DbContext.Vitals.Count() + 10,
                                VitalSignTypeID = 1,
                                AdmittanceID = id,
                                Timestamp = new DateTime(2009, 6, 25, hour, minutes, 00),
                                VitalSignValue = vitalValue.ToString()
                            };
                            DbContext.Vitals.Add(item);
                        }

                    }
                    #endregion
                    #region Blood Pressure
                    int bloodPressureSystolic;
                    int bloodPressureDiastolic;
                    for (int hour = 7; hour < 13; hour++)
                    {
                        //for every hour
                        for (int minutes = 0; minutes < 50; minutes += 30)
                        {
                            bloodPressureDiastolic = rnd.Next(50, 100);
                            int diff = rnd.Next(40, 60);

                            bloodPressureSystolic = bloodPressureDiastolic + diff;
                         
                            Vital item = new Vital()
                            {

                                VitalSignTypeID = 2,
                                AdmittanceID = id,
                                Timestamp = new DateTime(2009, 6, 25, hour, minutes, 00),
                                VitalSignValue = bloodPressureSystolic.ToString() + "/" + bloodPressureDiastolic.ToString()
                            };
                            DbContext.Vitals.Add(item);
                        }

                    }

                    //After 16
                    for (int hour = 17; hour < 20; hour++)
                    {
                        //for every hour
                        for (int minutes = 0; minutes < 50; minutes += 30)
                        {
                            bloodPressureDiastolic = rnd.Next(50, 100);
                            int diff = rnd.Next(40, 60);

                            bloodPressureSystolic = bloodPressureDiastolic + diff;
                            Vital item = new Vital()
                            {
                                //ID = DbContext.Vitals.Count() + 10,
                                VitalSignTypeID = 2,
                                AdmittanceID = id,
                                Timestamp = new DateTime(2009, 6, 25, hour, minutes, 00),
                                VitalSignValue = bloodPressureSystolic.ToString() + "/" + bloodPressureDiastolic.ToString()
                            };
                            DbContext.Vitals.Add(item);
                        }

                    }
                    #endregion
                    #region Pulse
                    int pulseValue;

                    for (int hour = 7; hour < 13; hour++)
                    {
                        //for every hour
                        for (int minutes = 0; minutes < 50; minutes += 30)
                        {
                            pulseValue = rnd.Next(60, 110);
                            Vital item = new Vital()
                            {
                                
                                //Pulse
                                VitalSignTypeID = 3,
                                AdmittanceID = id,
                                Timestamp = new DateTime(2009, 6, 25, hour, minutes, 00),
                                VitalSignValue = pulseValue.ToString()
                            };
                            DbContext.Vitals.Add(item);
                        }

                    }

                    ////After 16
                    for (int hour = 17; hour < 20; hour++)
                    {
                        //for every hour
                        for (int minutes = 0; minutes < 50; minutes += 30)
                        {
                            pulseValue = rnd.Next(60, 110);
                            Vital item = new Vital()
                            {
                                //ID = DbContext.Vitals.Count() + 10,
                                //Pulse
                                VitalSignTypeID = 3,
                                AdmittanceID = id,
                                Timestamp = new DateTime(2009, 6, 25, hour, minutes, 00),
                                VitalSignValue = pulseValue.ToString()
                            };
                            DbContext.Vitals.Add(item);
                        }

                    }
                    #endregion
                    #region Respiratory Rate
                    int respiratoryValue;

                    for (int hour = 7; hour < 13; hour++)
                    {
                        //for every hour
                        for (int minutes = 0; minutes < 50; minutes += 30)
                        {
                            respiratoryValue = rnd.Next(14, 25);
                            Vital item = new Vital()
                            {
                                
                                //Respiratory Rate
                                VitalSignTypeID = 4,
                                AdmittanceID = id,
                                Timestamp = new DateTime(2009, 6, 25, hour, minutes, 00),
                                VitalSignValue = respiratoryValue.ToString()
                            };
                            DbContext.Vitals.Add(item);
                        }

                    }

                    ////After 16
                    for (int hour = 17; hour < 20; hour++)
                    {
                        //for every hour
                        for (int minutes = 0; minutes < 50; minutes += 30)
                        {
                            respiratoryValue = rnd.Next(14, 25);
                            Vital item = new Vital()
                            {
                                //ID = DbContext.Vitals.Count() + 10,
                                //Respiratory Rate
                                VitalSignTypeID = 4,
                                AdmittanceID = id,
                                Timestamp = new DateTime(2009, 6, 25, hour, minutes, 00),
                                VitalSignValue = respiratoryValue.ToString()
                            };
                            DbContext.Vitals.Add(item);
                        }

                    }
                    #endregion
                    #region Pain
                    int painValue;

                    for (int hour = 7; hour < 13; hour++)
                    {
                        //for every hour
                        for (int minutes = 0; minutes < 50; minutes += 30)
                        {
                            painValue = rnd.Next(7, 15);
                            Vital item = new Vital()
                            {
                                //ID = DbContext.Vitals.Count() + 10,
                                //Pain
                                VitalSignTypeID = 5,
                                AdmittanceID = id,
                                Timestamp = new DateTime(2009, 6, 25, hour, minutes, 00),
                                VitalSignValue = painValue.ToString()
                            };
                            DbContext.Vitals.Add(item);
                        }
                    }

                    //After 16
                    for (int hour = 17; hour < 20; hour++)
                    {
                        //for every hour
                        for (int minutes = 0; minutes < 50; minutes += 30)
                        {
                            painValue = rnd.Next(7, 15);
                            Vital item = new Vital()
                            {
                                //ID = DbContext.Vitals.Count() + 10,
                                //Pain
                                VitalSignTypeID = 5,
                                AdmittanceID = id,
                                Timestamp = new DateTime(2009, 6, 25, hour, minutes, 00),
                                VitalSignValue = painValue.ToString()
                            };
                            DbContext.Vitals.Add(item);
                        }

                    }
                    #endregion
                }
                //DbContext.SaveChanges();

            }


            return View("Index");
        }

        public JsonResult GetMedTestsTypes()
        {
            return new JsonResult
            {
                Data = Mapper.Map(DbContext.TestTypes),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        [HttpPost]
        public JsonResult GetTestsData(int admittanceID)
        {
            return new JsonResult {
                Data = Mapper.Map(
                        DbContext.Tests.Where(item => item.AdmittanceID == admittanceID).OrderBy(o => o.Timestamp.Value.Hour)
                    )
            };
        }

        public JsonResult GetMedTypes()
        {
            return new JsonResult
            {
                Data = Mapper.Map(DbContext.Meds),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        [HttpPost]
        public JsonResult GetOrdersData(int admittanceID)
        {
            return new JsonResult
            {
                Data = Mapper.Map(DbContext.Orders.Where(item => item.AdmittanceID == admittanceID))
            };
        }

        #endregion

        #region Private methods

        private ShowcaseLanguage GetUserResourceFile(string acceptLanguage)
        {
            string i18nRelativePath = "~/Scripts/app/i18n/";
            string i18nDir = Server.MapPath(i18nRelativePath);
            //  Default to English if nothing else hints for a different language);
            ShowcaseLanguage result = new ShowcaseLanguage()
            {
                Language = "en",
                ResourceFile = i18nDir + "en" + ".js"
            };

            if (!string.IsNullOrWhiteSpace(acceptLanguage))
            {
                //  Get all languages the user accepts
                string[] languages = acceptLanguage.Split(';')[0].Split(',');

                foreach (var lang in languages)
                {
                    //  Check if a specific JS resource file exists
                    if (System.IO.File.Exists(i18nDir + lang + ".js"))
                    {
                        result.Language = lang;
                        break;
                    }
                    else
                    {   //  Check if a general JS resource file exists
                        string baseLang = lang.Split('-')[0];
                        if (System.IO.File.Exists(i18nDir + baseLang + ".js"))
                        {
                            result.Language = baseLang;
                            break;
                        }
                    }
                }
            }

            result.ResourceFile = Url.Content(string.Format("{0}{1}.js", i18nRelativePath, result.Language));
            return result;
        }

        #endregion

        #region Custom Data Structures

        class ShowcaseLanguage
        {
            public string ResourceFile { get; set; }
            public string Language { get; set; }
        }

        #endregion
    }
}
