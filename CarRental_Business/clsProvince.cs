using CarRental_DataAccess;
using System.Data;

namespace CarRental_Business
{
    public class clsProvince
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int? ProvinceID { get; set; }
        public string ProvinceName { get; set; }

        public clsProvince()
        {
            ProvinceID = null;
            ProvinceName = string.Empty;

            Mode = enMode.AddNew;
        }

        private clsProvince(int? provinceID, string provinceName)
        {
            ProvinceID = provinceID;
            ProvinceName = provinceName;

            Mode = enMode.Update;
        }

        public static clsProvince Find(int? provinceID)
        {
            string provinceName = string.Empty;

            bool isFound = clsProvinceData.GetProvinceInfoByID(provinceID, ref provinceName);

            if (isFound)
            {
                return new clsProvince(provinceID, provinceName);
            }

            return null;
        }

        public static clsProvince Find(string provinceName)
        {
            int? provinceID = null;

            bool isFound = clsProvinceData.GetProvinceInfoByName(provinceName, ref provinceID);

            if (isFound)
            {
                return new clsProvince(provinceID, provinceName);
            }

            return null;
        }

        public static DataTable GetAllProvinces()
        {
            return clsProvinceData.GetAllProvinces();
        }

        public static DataTable GetAllProvinceNames()
        {
            return clsProvinceData.GetAllProvinceNames();
        }
    }
}
