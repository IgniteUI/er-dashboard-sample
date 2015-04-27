using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ERDashboard.Models;

namespace ERDashboard.Models.DTO
{
    public class Mapper
    {
        #region Patient VM object methods

        internal static IEnumerable<ViewModels.Patient> Map(IQueryable<Admittance> addmitances, string imagesBasePath)
        {

            var patiences = addmitances.ToList().GroupBy(a => a.PatientID, admittance => admittance, (key, admittance) => new ViewModels.Patient
            {
                Name = string.Format("{0} {1}", admittance.Select(x => x.Patient.LastName.ToUpper()).FirstOrDefault(), admittance.Select(x => x.Patient.FirstName).FirstOrDefault()),
                SeverityImageUrl = GetSeverityUrl(admittance.Select(x => x.Severity).FirstOrDefault(), imagesBasePath),
                Diagnosis = admittance.Select(x => x.Diagnosis).FirstOrDefault(),
                Disposition = admittance.Select(x => x.Disposition).FirstOrDefault(),
                Visited = admittance.Select(x => x.Patient.Visited).FirstOrDefault(),
                PatientID = admittance.Select(x => x.PatientID).Distinct().FirstOrDefault(),
                AdmittanceID = admittance.Select(x => x.ID).FirstOrDefault()
            }).OrderBy(o => o.Visited).ToList();
            return patiences;
        }

        #endregion

        #region VitalSignsItem VM object methods

        internal static IEnumerable<ViewModels.VitalSignsItem> Map(IQueryable<Vital> vitals)
        {
            var vitalsList = 
                (from vital in vitals
                select new ViewModels.VitalSignsItem
                {
                    ID = vital.ID,
                    AdmittanceID = vital.AdmittanceID,
                    Timestamp = vital.Timestamp,
                    VitalSignValue = vital.VitalSignValue,      //  TODO: Some items are URLs others are numbers
                    VitalSignTypeID = vital.VitalSignTypeID,
                    VitalSignType = vital.VitalSignType.Name,
                    BloodPressureLow = 0
                }).ToList();

            foreach (var bloodPressureItem in vitalsList.Where(vital => vital.VitalSignTypeID == 2))
            {
                string[] bloodPressure = bloodPressureItem.VitalSignValue.Split('/');
                bloodPressureItem.VitalSignValue = bloodPressure[0];
                bloodPressureItem.BloodPressureLow = Convert.ToInt32(bloodPressure[1]);
            }
            //We need this loop so we convert timestamp item to UTC Date
            foreach (var vital in vitalsList)
            {
                vital.Timestamp = vital.Timestamp.HasValue ? new DateTime(vital.Timestamp.Value.Ticks, DateTimeKind.Utc) : vital.Timestamp;
            }
            return vitalsList;
        }

        internal static IEnumerable<ViewModels.ItemType> Map(IEnumerable<VitalSignType> dbSet)
        {
            return
                from vitalSignType in dbSet
                select new ViewModels.ItemType
                    {
                        ID = vitalSignType.ID,
                        Name = vitalSignType.Name
                    };
        }

        #endregion

        #region Medical Tests VM object methods

        internal static IEnumerable<ViewModels.ItemType> Map(IEnumerable<TestType> dbSet)
        {
            return
                from medTestType in dbSet
                //Temporary remove CT Scan and EKG from the dropdown list as we currently don't have data for it. 
                where medTestType.ID < 2 || medTestType.ID > 3 
                select new ViewModels.ItemType
                    {
                        ID = medTestType.ID,
                        Name = medTestType.Name,
                        ValueType = medTestType.ResultType
                    };
        }

        internal static IEnumerable<ViewModels.MedTestItem> Map(IQueryable<Test> tests)
        {
            var testItems = 
                (from test in tests
                select new ViewModels.MedTestItem
                    {
                        ID = test.ID,
                        TestTypeID = test.TestTypeID,
                        TestTypeName = test.TestType.Name,
                        AdmittanceID = test.AdmittanceID,
                        Timestamp = test.Timestamp,
                        Result = test.Result,
                        BodyRegionID = test.BodyRegionID
                    }).ToList();
            //We need this loop so we convert timestamp item to UTC Date
            foreach (var test in testItems)
            {
                test.Timestamp = test.Timestamp.HasValue ? new DateTime(test.Timestamp.Value.Ticks, DateTimeKind.Utc) : test.Timestamp;
            } 
            return testItems;
        }

        #endregion

        #region Orders VM object methods

        internal static IEnumerable<ViewModels.ItemType> Map(IEnumerable<Med> dbSet)
        {
            return
                from medicine in dbSet
                select new ViewModels.ItemType
                    {
                        ID = medicine.ID,
                        Name = medicine.Name
                    };
        }

        internal static object Map(IQueryable<Order> orders)
        {
            return
                from order in orders
                select new ViewModels.OrderItem
                    {
                        ID = order.ID,
                        AdmittanceID = order.AdmittanceID,
                        MedID = order.MedID,
                        MedName = order.Med.Name,
                        Dosage = order.Dosage,
                        Unit = order.Unit,
                        Frequency = order.Frequency,
                        Indication = order.Indication,
                        Timestamp = order.Timestamp
                    };
        }

        #endregion

        #region Private Helpers

        private static string GetSeverityUrl(string severity, string imagesBasePath)
        {
            // TODO: Make the URLs relative!
            int intSeverity = Convert.ToInt32(severity);
            switch (intSeverity)
            {
                case 1:
                    return "severity_1";
                case 2:
                    return "severity_2";
                case 3:
                    return "severity_3";
                default:
                    return "severity_1";
            }
        }

        #endregion
    }
}