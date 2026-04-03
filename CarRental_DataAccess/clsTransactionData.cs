using System;
using System.Data.SqlClient;
using System.Data;

namespace CarRental_DataAccess
{
    public class clsTransactionData
    {
        public static bool GetTransactionInfoByTransactionID(int? TransactionID, ref int? BookingID,
            ref int? ReturnID, ref string PaymentDetails, ref decimal PaidInitialTotalDueAmount,
            ref decimal? ActualTotalDueAmount, ref decimal? TotalRemaining,
            ref decimal? TotalRefundedAmount, ref DateTime TransactionDate,
            ref DateTime? UpdatedTransactionDate, ref byte TransactionType)
        {
            bool IsFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"select * from RentalTransaction where TransactionID = @TransactionID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TransactionID", (object)TransactionID ?? DBNull.Value);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // The record was found
                                IsFound = true;

                                BookingID = (reader["BookingID"] != DBNull.Value) ? (int?)reader["BookingID"] : null;
                                ReturnID = (reader["ReturnID"] != DBNull.Value) ? (int?)reader["ReturnID"] : null;
                                PaymentDetails = (reader["PaymentDetails"] != DBNull.Value) ? (string)reader["PaymentDetails"] : string.Empty;
                                PaidInitialTotalDueAmount = Convert.ToDecimal(reader["PaidInitialTotalDueAmount"]);
                                ActualTotalDueAmount = (reader["ActualTotalDueAmount"] != DBNull.Value) ? (decimal?)Convert.ToDecimal(reader["ActualTotalDueAmount"]) : null;
                                TotalRemaining = (reader["TotalRemaining"] != DBNull.Value) ? (decimal?)Convert.ToDecimal(reader["TotalRemaining"]) : null;
                                TotalRefundedAmount = (reader["TotalRefundedAmount"] != DBNull.Value) ? (decimal?)Convert.ToDecimal(reader["TotalRefundedAmount"]) : null;
                                TransactionDate = (DateTime)reader["TransactionDate"];
                                UpdatedTransactionDate = (reader["UpdatedTransactionDate"] != DBNull.Value) ? (DateTime?)reader["UpdatedTransactionDate"] : null;
                                TransactionType = Convert.ToByte(reader["TransactionType"]);
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

        public static bool GetTransactionInfoByReturnID(int? ReturnID, ref int? TransactionID,
            ref int? BookingID, ref string PaymentDetails, ref decimal PaidInitialTotalDueAmount,
            ref decimal? ActualTotalDueAmount, ref decimal? TotalRemaining,
            ref decimal? TotalRefundedAmount, ref DateTime TransactionDate,
            ref DateTime? UpdatedTransactionDate, ref byte TransactionType)
        {
            bool IsFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"select * from RentalTransaction where ReturnID = @ReturnID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ReturnID", (object)ReturnID ?? DBNull.Value);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // The record was found
                                IsFound = true;

                                TransactionID = (reader["TransactionID"] != DBNull.Value) ? (int?)reader["TransactionID"] : null;
                                BookingID = (reader["BookingID"] != DBNull.Value) ? (int?)reader["BookingID"] : null;
                                PaymentDetails = (reader["PaymentDetails"] != DBNull.Value) ? (string)reader["PaymentDetails"] : string.Empty;
                                PaidInitialTotalDueAmount = Convert.ToDecimal(reader["PaidInitialTotalDueAmount"]);
                                ActualTotalDueAmount = (reader["ActualTotalDueAmount"] != DBNull.Value) ? (decimal?)Convert.ToDecimal(reader["ActualTotalDueAmount"]) : null;
                                TotalRemaining = (reader["TotalRemaining"] != DBNull.Value) ? (decimal?)Convert.ToDecimal(reader["TotalRemaining"]) : null;
                                TotalRefundedAmount = (reader["TotalRefundedAmount"] != DBNull.Value) ? (decimal?)Convert.ToDecimal(reader["TotalRefundedAmount"]) : null;
                                TransactionDate = (DateTime)reader["TransactionDate"];
                                UpdatedTransactionDate = (reader["UpdatedTransactionDate"] != DBNull.Value) ? (DateTime?)reader["UpdatedTransactionDate"] : null;
                                TransactionType = Convert.ToByte(reader["TransactionType"]);
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

        public static bool GetTransactionInfoByBookingID(int? BookingID, ref int? TransactionID,
            ref int? ReturnID, ref string PaymentDetails, ref decimal PaidInitialTotalDueAmount,
            ref decimal? ActualTotalDueAmount, ref decimal? TotalRemaining,
            ref decimal? TotalRefundedAmount, ref DateTime TransactionDate,
            ref DateTime? UpdatedTransactionDate, ref byte TransactionType)
        {
            bool IsFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"select * from RentalTransaction where BookingID = @BookingID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@BookingID", (object)BookingID ?? DBNull.Value);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // The record was found
                                IsFound = true;

                                TransactionID = (reader["TransactionID"] != DBNull.Value) ? (int?)reader["TransactionID"] : null;
                                ReturnID = (reader["ReturnID"] != DBNull.Value) ? (int?)reader["ReturnID"] : null;
                                PaymentDetails = (reader["PaymentDetails"] != DBNull.Value) ? (string)reader["PaymentDetails"] : string.Empty;
                                PaidInitialTotalDueAmount = Convert.ToDecimal(reader["PaidInitialTotalDueAmount"]);
                                ActualTotalDueAmount = (reader["ActualTotalDueAmount"] != DBNull.Value) ? (decimal?)Convert.ToDecimal(reader["ActualTotalDueAmount"]) : null;
                                TotalRemaining = (reader["TotalRemaining"] != DBNull.Value) ? (decimal?)Convert.ToDecimal(reader["TotalRemaining"]) : null;
                                TotalRefundedAmount = (reader["TotalRefundedAmount"] != DBNull.Value) ? (decimal?)Convert.ToDecimal(reader["TotalRefundedAmount"]) : null;
                                TransactionDate = (DateTime)reader["TransactionDate"];
                                UpdatedTransactionDate = (reader["UpdatedTransactionDate"] != DBNull.Value) ? (DateTime?)reader["UpdatedTransactionDate"] : null;
                                TransactionType = Convert.ToByte(reader["TransactionType"]);
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

        public static int? AddNewTransaction(int? BookingID, string PaymentDetails,
            decimal PaidInitialTotalDueAmount)

        {
            // This function will return the new person id if succeeded and null if not
            int? TransactionID = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"insert into RentalTransaction (BookingID, PaymentDetails, PaidInitialTotalDueAmount, TransactionDate)
values (@BookingID, @PaymentDetails, @PaidInitialTotalDueAmount, @TransactionDate)
select scope_identity()";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@BookingID", (object)BookingID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@PaymentDetails", (object)PaymentDetails ?? DBNull.Value);
                        command.Parameters.AddWithValue("@PaidInitialTotalDueAmount", PaidInitialTotalDueAmount);
                        command.Parameters.AddWithValue("@TransactionDate", DateTime.Now);

                        object result = command.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int InsertID))
                        {
                            TransactionID = InsertID;
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

            return TransactionID;
        }

        public static bool AddNewBookingAndTransaction(int? CustomerID, int? VehicleID,
            DateTime RentalStartDate, DateTime RentalEndDate, string PickupLocation,
            string DropoffLocation, decimal RentalPricePerDay, string InitialCheckNotes,
            string PaymentDetails, decimal PaidInitialTotalDueAmount,
            ref int? BookingID, ref int? TransactionID)
        {
            bool isSaved = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();
                    using (SqlTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            string overlapQuery = @"SELECT COUNT(1)
                                                    FROM RentalBooking b
                                                    INNER JOIN RentalTransaction t ON t.BookingID = b.BookingID
                                                    WHERE b.VehicleID = @VehicleID
                                                          AND t.ReturnID IS NULL
                                                          AND b.RentalStartDate < @RentalEndDate
                                                          AND b.RentalEndDate > @RentalStartDate";

                            using (SqlCommand overlapCommand = new SqlCommand(overlapQuery, connection, transaction))
                            {
                                overlapCommand.Parameters.AddWithValue("@VehicleID", (object)VehicleID ?? DBNull.Value);
                                overlapCommand.Parameters.AddWithValue("@RentalStartDate", RentalStartDate);
                                overlapCommand.Parameters.AddWithValue("@RentalEndDate", RentalEndDate);

                                object overlapResult = overlapCommand.ExecuteScalar();
                                if (overlapResult != null && int.TryParse(overlapResult.ToString(), out int overlapCount) && overlapCount > 0)
                                {
                                    transaction.Rollback();
                                    return false;
                                }
                            }

                            if (RentalStartDate.Date <= DateTime.Today)
                            {
                                string lockVehicleQuery = @"update Vehicles
set IsAvailableForRent = 0
where VehicleID = @VehicleID and IsAvailableForRent = 1";

                                using (SqlCommand lockVehicleCommand = new SqlCommand(lockVehicleQuery, connection, transaction))
                                {
                                    lockVehicleCommand.Parameters.AddWithValue("@VehicleID", (object)VehicleID ?? DBNull.Value);
                                    if (lockVehicleCommand.ExecuteNonQuery() == 0)
                                    {
                                        transaction.Rollback();
                                        return false;
                                    }
                                }
                            }

                            string insertBookingQuery = @"insert into RentalBooking (CustomerID, VehicleID, RentalStartDate, RentalEndDate, PickupLocation, DropoffLocation, RentalPricePerDay, InitialCheckNotes)
values (@CustomerID, @VehicleID, @RentalStartDate, @RentalEndDate, @PickupLocation, @DropoffLocation, @RentalPricePerDay, @InitialCheckNotes)
select scope_identity()";

                            using (SqlCommand insertBookingCommand = new SqlCommand(insertBookingQuery, connection, transaction))
                            {
                                insertBookingCommand.Parameters.AddWithValue("@CustomerID", (object)CustomerID ?? DBNull.Value);
                                insertBookingCommand.Parameters.AddWithValue("@VehicleID", (object)VehicleID ?? DBNull.Value);
                                insertBookingCommand.Parameters.AddWithValue("@RentalStartDate", RentalStartDate);
                                insertBookingCommand.Parameters.AddWithValue("@RentalEndDate", RentalEndDate);
                                insertBookingCommand.Parameters.AddWithValue("@PickupLocation", PickupLocation);
                                insertBookingCommand.Parameters.AddWithValue("@DropoffLocation", DropoffLocation);
                                insertBookingCommand.Parameters.AddWithValue("@RentalPricePerDay", RentalPricePerDay);
                                insertBookingCommand.Parameters.AddWithValue("@InitialCheckNotes", (object)InitialCheckNotes ?? DBNull.Value);

                                object bookingResult = insertBookingCommand.ExecuteScalar();
                                if (bookingResult != null && int.TryParse(bookingResult.ToString(), out int bookingId))
                                {
                                    BookingID = bookingId;
                                }
                            }

                            if (!BookingID.HasValue)
                            {
                                transaction.Rollback();
                                return false;
                            }

                            string insertTransactionQuery = @"insert into RentalTransaction (BookingID, PaymentDetails, PaidInitialTotalDueAmount, TransactionDate)
values (@BookingID, @PaymentDetails, @PaidInitialTotalDueAmount, @TransactionDate)
select scope_identity()";

                            using (SqlCommand insertTransactionCommand = new SqlCommand(insertTransactionQuery, connection, transaction))
                            {
                                insertTransactionCommand.Parameters.AddWithValue("@BookingID", BookingID.Value);
                                insertTransactionCommand.Parameters.AddWithValue("@PaymentDetails", (object)PaymentDetails ?? DBNull.Value);
                                insertTransactionCommand.Parameters.AddWithValue("@PaidInitialTotalDueAmount", PaidInitialTotalDueAmount);
                                insertTransactionCommand.Parameters.AddWithValue("@TransactionDate", DateTime.Now);

                                object transactionResult = insertTransactionCommand.ExecuteScalar();
                                if (transactionResult != null && int.TryParse(transactionResult.ToString(), out int transactionId))
                                {
                                    TransactionID = transactionId;
                                }
                            }

                            if (!TransactionID.HasValue)
                            {
                                transaction.Rollback();
                                return false;
                            }

                            transaction.Commit();
                            isSaved = true;
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
                isSaved = false;
                clsLogError.LogError("Database Exception", ex);
            }
            catch (Exception ex)
            {
                isSaved = false;
                clsLogError.LogError("General Exception", ex);
            }

            return isSaved;
        }

        public static bool UpdateTransaction(int? TransactionID, int? ReturnID,
            decimal? ActualTotalDueAmount, decimal? TotalRemaining,
            decimal? TotalRefundedAmount)
        {
            int RowAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"Update RentalTransaction
set ReturnID = @ReturnID,
ActualTotalDueAmount = @ActualTotalDueAmount,
TotalRemaining = @TotalRemaining,
TotalRefundedAmount = @TotalRefundedAmount,
UpdatedTransactionDate = @UpdatedTransactionDate
where TransactionID = @TransactionID";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TransactionID", (object)TransactionID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@ReturnID", (object)ReturnID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@TotalRemaining", (object)TotalRemaining ?? DBNull.Value);
                        command.Parameters.AddWithValue("@ActualTotalDueAmount", (object)ActualTotalDueAmount ?? DBNull.Value);
                        command.Parameters.AddWithValue("@TotalRefundedAmount", (object)TotalRefundedAmount ?? DBNull.Value);
                        command.Parameters.AddWithValue("@UpdatedTransactionDate", DateTime.Now);

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

        public static bool UpdateTotalRefundedAmount(int? TransactionID, decimal? TotalRemaining)

        {
            int RowAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"Update RentalTransaction
                                     set TotalRefundedAmount = ABS(@TotalRemaining),
                                         TotalRemaining = 0,
                                         UpdatedTransactionDate = @UpdatedTransactionDate
                                     where TransactionID = @TransactionID";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TransactionID", (object)TransactionID ?? DBNull.Value);
                        command.Parameters.AddWithValue("@TotalRemaining", (object)TotalRemaining ?? DBNull.Value);
                        command.Parameters.AddWithValue("@UpdatedTransactionDate", DateTime.Now);

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

        public static bool DeleteTransaction(int? TransactionID)
        {
            int RowAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"delete RentalTransaction where TransactionID = @TransactionID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TransactionID", (object)TransactionID ?? DBNull.Value);

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

        public static bool DoesTransactionExist(int? TransactionID)
        {
            bool IsFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"select found = 1 from RentalTransaction where TransactionID = @TransactionID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TransactionID", (object)TransactionID ?? DBNull.Value);

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

        public static DataTable GetAllRentalTransaction()
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"select * from TransactionDetails_View order by UpdatedTransactionDate desc";

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

        public static DataTable GetAllRentalTransactionByCustomerID(int? CustomerID)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"select * from TransactionDetails_View where CustomerID = @CustomerID order by TransactionID desc";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CustomerID", (object)CustomerID ?? DBNull.Value);

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

        public static int GetTransactionsCount()
        {
            int Count = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"SELECT COUNT(*) FROM RentalTransaction";

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

        public static int? GetReturnIDByBookingID(int? BookingID)
        {
            int? ReturnID = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    string query = @"SELECT TOP 1 RentalTransaction.ReturnID
                                     FROM RentalTransaction
                                     WHERE RentalTransaction.BookingID = @BookingID
                                           AND RentalTransaction.ReturnID IS NOT NULL
                                     ORDER BY RentalTransaction.ReturnID DESC";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@BookingID", (object)BookingID ?? DBNull.Value);

                        object result = command.ExecuteScalar();

                        if (result != null && (int.TryParse(result.ToString(), out int Value)))
                        {
                            ReturnID = Value;
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

            return ReturnID;
        }

    }
}
