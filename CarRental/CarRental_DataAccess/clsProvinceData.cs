using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using CarRental.GlobalClasses;

namespace CarRental_DataAccess
{
    public class clsProvinceData
    {
        private static readonly string _connectionString =
            ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        public static bool GetProvinceInfoByID(int? provinceID, ref string provinceName)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    // Try Provinces table first, fallback to Countries
                    string query = @"
                        IF OBJECT_ID('Provinces', 'U') IS NOT NULL
                            SELECT ProvinceName FROM Provinces WHERE ProvinceID = @ProvinceID
                        ELSE IF OBJECT_ID('Countries', 'U') IS NOT NULL
                            SELECT CountryName AS ProvinceName FROM Countries WHERE CountryID = @ProvinceID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ProvinceID", (object)provinceID ?? DBNull.Value);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                provinceName = (string)reader["ProvinceName"];
                            }
                            else
                            {
                                isFound = false;
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                isFound = false;
                clsLogError.LogError("Database Exception", ex);
            }
            catch (Exception ex)
            {
                isFound = false;
                clsLogError.LogError("General Exception", ex);
            }

            return isFound;
        }

        public static bool GetProvinceInfoByName(string provinceName, ref int? provinceID)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    // Try Provinces table first, fallback to Countries
                    string query = @"
                        IF OBJECT_ID('Provinces', 'U') IS NOT NULL
                            SELECT ProvinceID FROM Provinces WHERE ProvinceName = @ProvinceName
                        ELSE IF OBJECT_ID('Countries', 'U') IS NOT NULL
                            SELECT CountryID AS ProvinceID FROM Countries WHERE CountryName = @ProvinceName";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ProvinceName", provinceName);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                provinceID = (reader["ProvinceID"] != DBNull.Value) ? (int?)reader["ProvinceID"] : null;
                            }
                            else
                            {
                                isFound = false;
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                isFound = false;
                clsLogError.LogError("Database Exception", ex);
            }
            catch (Exception ex)
            {
                isFound = false;
                clsLogError.LogError("General Exception", ex);
            }

            return isFound;
        }

        public static DataTable GetAllProvinces()
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    // Try Provinces table first, fallback to Countries if not exists
                    string query = @"
                        IF OBJECT_ID('Provinces', 'U') IS NOT NULL
                            SELECT ProvinceID, ProvinceName FROM Provinces
                        ELSE IF OBJECT_ID('Countries', 'U') IS NOT NULL
                            SELECT CountryID AS ProvinceID, CountryName AS ProvinceName FROM Countries
                        ELSE
                            SELECT NULL AS ProvinceID, NULL AS ProvinceName WHERE 1=0";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            dt.Load(reader); // Load schema even when there are no rows
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                clsLogError.LogError("Database Exception", ex);
            }
            catch (Exception ex)
            {
                clsLogError.LogError("General Exception", ex);
            }

            return dt;
        }

        public static DataTable GetAllProvinceNames()
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    // Try Provinces table first, fallback to Countries
                    string query = @"
                        IF OBJECT_ID('Provinces', 'U') IS NOT NULL
                            SELECT ProvinceID, ProvinceName FROM Provinces
                        ELSE IF OBJECT_ID('Countries', 'U') IS NOT NULL
                            SELECT CountryID AS ProvinceID, CountryName AS ProvinceName FROM Countries
                        ELSE
                            SELECT NULL AS ProvinceID, NULL AS ProvinceName WHERE 1 = 0";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            dt.Load(reader); // Load schema even when there are no rows
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                clsLogError.LogError("Database Exception", ex);
            }
            catch (Exception ex)
            {
                clsLogError.LogError("General Exception", ex);
            }

            return dt;
        }
    }
}
