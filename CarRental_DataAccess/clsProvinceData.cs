using System;
using System.Data;
using System.Data.SqlClient;

namespace CarRental_DataAccess
{
    public class clsProvinceData
    {
        public static bool GetProvinceInfoByID(int? provinceID, ref string provinceName)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"
IF OBJECT_ID('dbo.Provinces', 'U') IS NOT NULL
    SELECT ProvinceName FROM dbo.Provinces WHERE CountryID = @ProvinceID
ELSE IF OBJECT_ID('dbo.Countries', 'U') IS NOT NULL
    SELECT CountryName AS ProvinceName FROM dbo.Countries WHERE CountryID = @ProvinceID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ProvinceID", (object)provinceID ?? DBNull.Value);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                provinceName = reader["ProvinceName"].ToString();
                            }
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

            return isFound;
        }

        public static bool GetProvinceInfoByName(string provinceName, ref int? provinceID)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"
IF OBJECT_ID('dbo.Provinces', 'U') IS NOT NULL
    SELECT CountryID AS ProvinceID FROM dbo.Provinces WHERE ProvinceName = @ProvinceName
ELSE IF OBJECT_ID('dbo.Countries', 'U') IS NOT NULL
    SELECT CountryID AS ProvinceID FROM dbo.Countries WHERE CountryName = @ProvinceName";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ProvinceName", provinceName);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                isFound = true;
                                provinceID = (reader["ProvinceID"] != DBNull.Value) ? (int?)Convert.ToInt32(reader["ProvinceID"]) : null;
                            }
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

            return isFound;
        }

        public static DataTable GetAllProvinces()
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"
IF OBJECT_ID('dbo.Provinces', 'U') IS NOT NULL
    SELECT CountryID AS ProvinceID, ProvinceName FROM dbo.Provinces
ELSE IF OBJECT_ID('dbo.Countries', 'U') IS NOT NULL
    SELECT CountryID AS ProvinceID, CountryName AS ProvinceName FROM dbo.Countries
ELSE
    SELECT CAST(NULL AS INT) AS ProvinceID, CAST(NULL AS NVARCHAR(255)) AS ProvinceName WHERE 1 = 0";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            dt.Load(reader);
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
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"
IF OBJECT_ID('dbo.Provinces', 'U') IS NOT NULL
    SELECT ProvinceName FROM dbo.Provinces
ELSE IF OBJECT_ID('dbo.Countries', 'U') IS NOT NULL
    SELECT CountryName AS ProvinceName FROM dbo.Countries
ELSE
    SELECT CAST(NULL AS NVARCHAR(255)) AS ProvinceName WHERE 1 = 0";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            dt.Load(reader);
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
