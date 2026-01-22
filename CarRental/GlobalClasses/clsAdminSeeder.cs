using System;
using CarRental_Business;

namespace CarRental.GlobalClasses
{
    internal static class clsAdminSeeder
    {
        private const string _DefaultAdminUsername = "admin";
        private const string _DefaultAdminPassword = "Admin@123";

        public static void EnsureAdminAccount()
        {
            try
            {
                clsUser admin = clsUser.Find(_DefaultAdminUsername);

                if (admin == null)
                {
                    admin = new clsUser
                    {
                        Username = _DefaultAdminUsername
                    };
                }

                _PopulateAdminDefaults(admin);

                if (!admin.Save())
                {
                    clsLogError.LogError("Admin Seed Failure", new Exception("Failed to create or update default admin account."));
                }
            }
            catch (Exception ex)
            {
                clsLogError.LogError("Admin Seed Exception", ex);
            }
        }

        private static void _PopulateAdminDefaults(clsUser admin)
        {
            admin.Name = "System Administrator";
            admin.Address = "Head Office";
            admin.Phone = "0000000000";
            admin.Email = "admin@carrental.local";
            admin.DateOfBirth = new DateTime(1990, 1, 1);
            admin.Gender = clsPerson.enGender.Male;
            admin.NationalityCountryID = _TryGetDefaultProvinceID();
            admin.Password = clsGlobal.ComputeHash(_DefaultAdminPassword);
            admin.Permissions = (int)clsUser.enPermissions.All;
            admin.SecurityQuestion = "Default security question";
            admin.SecurityAnswer = clsGlobal.Encrypt("Administrator");
            admin.IsActive = true;
            admin.ImagePath = null;
        }

        private static int? _TryGetDefaultProvinceID()
        {
            try
            {
                clsProvince defaultProvince = clsProvince.Find("Jordan");
                if (defaultProvince != null)
                    return defaultProvince.ProvinceID;
            }
            catch
            {
                // ignore failures and fall back to null so seeding can continue
            }

            return null;
        }
    }
}
