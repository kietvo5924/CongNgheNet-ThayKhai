using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental_DataAccess
{
    public class clsReturnData
    {
        public static bool GetReturnInfoByID(int? ReturenID, ref DateTime ActualReturnDate,
            ref int ActualRentalDays, ref int Mileage, ref int ConsumedMileage,
            ref string FinalCheckNotes, ref decimal AdditionalCharges,
            ref decimal ActualTotalDueAmount)
        {
            bool IsFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"select * from VehicleReturns where ReturenID = @ReturenID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ReturenID", (object)ReturenID ?? DBNull.Value);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // The record was found
                                IsFound = true;

                                ActualReturnDate = (DateTime)reader["ActualReturnDate"];
                                ActualRentalDays = (int)reader["ActualRentalDays"];
                                Mileage = (int)reader["Mileage"];
                                ConsumedMileage = (int)reader["ConsumedMileage"];
                                FinalCheckNotes = (string)reader["FinalCheckNotes"];
                                AdditionalCharges = Convert.ToDecimal(reader["AdditionalCharges"]);
                                ActualTotalDueAmount = Convert.ToDecimal(reader["ActualTotalDueAmount"]);
                            }
                            else
                            {
                                // The record was not found
                                IsFound = false;
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                IsFound = false;

                clsLogError.LogError("Database Exception", ex);
            }
            catch (Exception ex)
            {
                IsFound = false;

                clsLogError.LogError("General Exception", ex);
            }

            return IsFound;
        }

        public static int? AddNewReturn(DateTime ActualReturnDate, int ActualRentalDays,
            int Mileage, int ConsumedMileage, string FinalCheckNotes,
            decimal AdditionalCharges, decimal ActualTotalDueAmount)

        {
            // This function will return the new person id if succeeded and null if not
            int? ReturenID = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"insert into VehicleReturns (ActualReturnDate, ActualRentalDays, Mileage, ConsumedMileage, FinalCheckNotes, AdditionalCharges, ActualTotalDueAmount)
values (@ActualReturnDate, @ActualRentalDays, @Mileage, @ConsumedMileage, @FinalCheckNotes, @AdditionalCharges, @ActualTotalDueAmount)
select scope_identity()";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ActualReturnDate", ActualReturnDate);
                        command.Parameters.AddWithValue("@Mileage", Mileage);
                        command.Parameters.AddWithValue("@FinalCheckNotes", FinalCheckNotes);
                        command.Parameters.AddWithValue("@AdditionalCharges", AdditionalCharges);
                        command.Parameters.AddWithValue("@ActualRentalDays", ActualRentalDays);
                        command.Parameters.AddWithValue("@ConsumedMileage", ConsumedMileage);
                        command.Parameters.AddWithValue("@ActualTotalDueAmount", ActualTotalDueAmount);

                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int InsertID))
                        {
                            ReturenID = InsertID;
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

            return ReturenID;
        }

        public static bool CompleteReturnWithTransactionAndVehicleUpdate(int? TransactionID,
            DateTime ActualReturnDate, int ActualRentalDays, int Mileage, int ConsumedMileage,
            string FinalCheckNotes, decimal AdditionalCharges, decimal ActualTotalDueAmount,
            ref int? ReturenID, ref decimal? TotalRemaining, ref decimal? TotalRefundedAmount,
            out string failureReason)
        {
            bool isCompleted = false;
            failureReason = null;

            if (!TransactionID.HasValue)
            {
                failureReason = "Không tìm thấy giao dịch tương ứng với đơn đặt xe.";
                return false;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();
                    using (SqlTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            int? vehicleID = null;
                            decimal paidInitialAmount = 0m;

                            string getTransactionContextQuery = @"select t.BookingID, b.VehicleID, t.PaidInitialTotalDueAmount
from RentalTransaction t
inner join RentalBooking b on b.BookingID = t.BookingID
where t.TransactionID = @TransactionID and t.ReturnID is null";

                            using (SqlCommand getContextCommand = new SqlCommand(getTransactionContextQuery, connection, transaction))
                            {
                                getContextCommand.Parameters.AddWithValue("@TransactionID", (object)TransactionID ?? DBNull.Value);
                                using (SqlDataReader reader = getContextCommand.ExecuteReader())
                                {
                                    if (!reader.Read())
                                    {
                                        transaction.Rollback();
                                        failureReason = "Giao dịch không tồn tại hoặc đơn này đã được trả trước đó.";
                                        return false;
                                    }

                                    vehicleID = reader["VehicleID"] != DBNull.Value ? (int?)Convert.ToInt32(reader["VehicleID"]) : null;
                                    paidInitialAmount = reader["PaidInitialTotalDueAmount"] != DBNull.Value ? Convert.ToDecimal(reader["PaidInitialTotalDueAmount"]) : 0m;
                                }
                            }

                            if (!vehicleID.HasValue)
                            {
                                transaction.Rollback();
                                failureReason = "Không xác định được xe cần cập nhật khi trả xe.";
                                return false;
                            }

                            string insertReturnQuery = @"insert into VehicleReturns (ActualReturnDate, ActualRentalDays, Mileage, ConsumedMileage, FinalCheckNotes, AdditionalCharges, ActualTotalDueAmount)
values (@ActualReturnDate, @ActualRentalDays, @Mileage, @ConsumedMileage, @FinalCheckNotes, @AdditionalCharges, @ActualTotalDueAmount)
select scope_identity()";

                            using (SqlCommand insertReturnCommand = new SqlCommand(insertReturnQuery, connection, transaction))
                            {
                                insertReturnCommand.Parameters.AddWithValue("@ActualReturnDate", ActualReturnDate);
                                insertReturnCommand.Parameters.AddWithValue("@ActualRentalDays", ActualRentalDays);
                                insertReturnCommand.Parameters.AddWithValue("@Mileage", Mileage);
                                insertReturnCommand.Parameters.AddWithValue("@ConsumedMileage", ConsumedMileage);
                                insertReturnCommand.Parameters.AddWithValue("@FinalCheckNotes", (object)FinalCheckNotes ?? DBNull.Value);
                                insertReturnCommand.Parameters.AddWithValue("@AdditionalCharges", AdditionalCharges);
                                insertReturnCommand.Parameters.AddWithValue("@ActualTotalDueAmount", ActualTotalDueAmount);

                                object returnResult = insertReturnCommand.ExecuteScalar();
                                if (returnResult != null && int.TryParse(returnResult.ToString(), out int insertedReturnID))
                                {
                                    ReturenID = insertedReturnID;
                                }
                            }

                            if (!ReturenID.HasValue)
                            {
                                transaction.Rollback();
                                failureReason = "Không thể lưu phiếu trả xe vào cơ sở dữ liệu.";
                                return false;
                            }

                            TotalRemaining = ActualTotalDueAmount - paidInitialAmount;
                            TotalRefundedAmount = TotalRemaining < 0 ? Math.Abs(TotalRemaining.Value) : 0m;

                            string updateTransactionQuery = @"update RentalTransaction
set ReturnID = @ReturnID,
    ActualTotalDueAmount = @ActualTotalDueAmount,
    TotalRemaining = @TotalRemaining,
    TotalRefundedAmount = @TotalRefundedAmount,
    UpdatedTransactionDate = @UpdatedTransactionDate
where TransactionID = @TransactionID and ReturnID is null";

                            using (SqlCommand updateTransactionCommand = new SqlCommand(updateTransactionQuery, connection, transaction))
                            {
                                updateTransactionCommand.Parameters.AddWithValue("@ReturnID", ReturenID.Value);
                                updateTransactionCommand.Parameters.AddWithValue("@ActualTotalDueAmount", ActualTotalDueAmount);
                                updateTransactionCommand.Parameters.AddWithValue("@TotalRemaining", (object)TotalRemaining ?? DBNull.Value);
                                updateTransactionCommand.Parameters.AddWithValue("@TotalRefundedAmount", (object)TotalRefundedAmount ?? DBNull.Value);
                                updateTransactionCommand.Parameters.AddWithValue("@UpdatedTransactionDate", DateTime.Now);
                                updateTransactionCommand.Parameters.AddWithValue("@TransactionID", (object)TransactionID ?? DBNull.Value);

                                if (updateTransactionCommand.ExecuteNonQuery() == 0)
                                {
                                    transaction.Rollback();
                                    failureReason = "Không thể cập nhật giao dịch quyết toán (đơn có thể đã được xử lý trước đó).";
                                    return false;
                                }
                            }

                            string updateVehicleQuery = @"update Vehicles
set Mileage = @Mileage,
    IsAvailableForRent = 1
where VehicleID = @VehicleID";

                            using (SqlCommand updateVehicleCommand = new SqlCommand(updateVehicleQuery, connection, transaction))
                            {
                                updateVehicleCommand.Parameters.AddWithValue("@Mileage", Mileage);
                                updateVehicleCommand.Parameters.AddWithValue("@VehicleID", (object)vehicleID ?? DBNull.Value);

                                if (updateVehicleCommand.ExecuteNonQuery() == 0)
                                {
                                    transaction.Rollback();
                                    failureReason = "Không thể cập nhật trạng thái xe sau khi trả.";
                                    return false;
                                }
                            }

                            transaction.Commit();
                            isCompleted = true;
                        }
                        catch
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                isCompleted = false;
                failureReason = "Lỗi cơ sở dữ liệu: " + ex.Message;
                clsLogError.LogError("Database Exception", ex);
            }
            catch (Exception ex)
            {
                isCompleted = false;
                failureReason = "Lỗi hệ thống: " + ex.Message;
                clsLogError.LogError("General Exception", ex);
            }

            return isCompleted;
        }

        public static bool UpdateReturn(int? ReturenID, DateTime ActualReturnDate,
            int ActualRentalDays,int Mileage, int ConsumedMileage,
             string FinalCheckNotes,decimal AdditionalCharges, decimal ActualTotalDueAmount )

        {
            int RowAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"Update VehicleReturns
set ActualReturnDate = @ActualReturnDate,
Mileage = @Mileage,
FinalCheckNotes = @FinalCheckNotes,
AdditionalCharges = @AdditionalCharges,
ActualRentalDays = @ActualRentalDays,
ConsumedMileage = @ConsumedMileage,
ActualTotalDueAmount = @ActualTotalDueAmount
where ReturenID = @ReturenID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ReturenID", (object)ReturenID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@ActualReturnDate", ActualReturnDate);
                        command.Parameters.AddWithValue("@Mileage", Mileage);
                        command.Parameters.AddWithValue("@FinalCheckNotes", FinalCheckNotes);
                        command.Parameters.AddWithValue("@AdditionalCharges", AdditionalCharges);
                        command.Parameters.AddWithValue("@ActualRentalDays", ActualRentalDays);
                        command.Parameters.AddWithValue("@ConsumedMileage", ConsumedMileage);
                        command.Parameters.AddWithValue("@ActualTotalDueAmount", ActualTotalDueAmount);

                        RowAffected = command.ExecuteNonQuery();
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

            return (RowAffected > 0);
        }
           
        public static bool DeleteReturn(int? ReturenID)
        {
            int RowAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"delete VehicleReturns where ReturenID = @ReturenID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ReturenID", (object)ReturenID ?? DBNull.Value);

                        RowAffected = command.ExecuteNonQuery();
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

            return (RowAffected > 0);
        }

        public static bool DoesReturnExist(int? ReturenID)
        {
            bool IsFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"select found = 1 from VehicleReturns where ReturenID = @ReturenID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ReturenID", (object)ReturenID ?? DBNull.Value);

                        object result = command.ExecuteScalar();

                        IsFound = (result != null);
                    }
                }
            }
            catch (SqlException ex)
            {
                IsFound = false;

                clsLogError.LogError("Database Exception", ex);
            }
            catch (Exception ex)
            {
                IsFound = false;

                clsLogError.LogError("General Exception", ex);
            }

            return IsFound;
        }

        public static DataTable GetAllVehicleReturns()
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"select * from ReturnDetails_View order by ActualReturnDate desc";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                dt.Load(reader);
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

            return dt;
        }

        public static int GetReturnCount()
        {
            int Count = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"SELECT COUNT(*) FROM VehicleReturns";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int Value))
                        {
                            Count = Value;
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

            return Count;
        }
    }
}
