using CarRental_DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental_Business
{
    public class clsReturn
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int? ReturnID { get; set; }
        public DateTime ActualReturnDate { get; set; }
        public int ActualRentalDays { get; set; }
        public int Mileage { get; set; }
        public int ConsumedMileage { get; set; }
        public string FinalCheckNotes { get; set; }
        public decimal AdditionalCharges { get; set; }
        public decimal ActualTotalDueAmount { get; set; }
        public string LastError { get; private set; }

        public clsTransaction TransactionInfo => clsTransaction.FindByReturnID(this.ReturnID);

        public clsReturn()
        {
            this.ReturnID = null;
            this.ActualReturnDate = DateTime.Now;
            this.ActualRentalDays = 0;
            this.Mileage = -1;
            this.ConsumedMileage = 0;
            this.FinalCheckNotes = string.Empty;
            this.AdditionalCharges = -1m;
            this.ActualTotalDueAmount = 0m;

            Mode = enMode.AddNew;
        }

        private clsReturn(int? ReturnID, DateTime ActualReturnDate, int ActualRentalDays,
            int Mileage, int ConsumedMileage, string FinalCheckNotes, decimal AdditionalCharges,
            decimal ActualTotalDueAmount)
        {
            this.ReturnID = ReturnID;
            this.ActualReturnDate = ActualReturnDate;
            this.ActualRentalDays = ActualRentalDays;
            this.Mileage = Mileage;
            this.ConsumedMileage = ConsumedMileage;
            this.FinalCheckNotes = FinalCheckNotes;
            this.AdditionalCharges = AdditionalCharges;
            this.ActualTotalDueAmount = ActualTotalDueAmount;

            Mode = enMode.Update;
        }

        private bool _AddNewReturn()
        {
            this.ReturnID = clsReturnData.AddNewReturn(this.ActualReturnDate,
                this.ActualRentalDays, this.Mileage, this.ConsumedMileage,
                  this.FinalCheckNotes, this.AdditionalCharges, this.ActualTotalDueAmount);

            return (this.ReturnID.HasValue);
        }

        private bool _UpdateReturn()
        {
            return clsReturnData.UpdateReturn(this.ReturnID, this.ActualReturnDate,
                this.ActualRentalDays, this.Mileage, this.ConsumedMileage,
                  this.FinalCheckNotes, this.AdditionalCharges, this.ActualTotalDueAmount);

        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewReturn())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateReturn();
            }

            return false;
        }

        public static clsReturn Find(int? ReturnID)
        {
            DateTime ActualReturnDate = DateTime.Now;
            int ActualRentalDays = 0;
            int Mileage = -1;
            int ConsumedMileage = 0;
            string FinalCheckNotes = string.Empty;
            decimal AdditionalCharges = -1m;
            decimal ActualTotalDueAmount = 0m;

            bool IsFound = clsReturnData.GetReturnInfoByID(ReturnID, ref ActualReturnDate,
                ref ActualRentalDays, ref Mileage, ref ConsumedMileage, ref FinalCheckNotes,
                ref AdditionalCharges, ref ActualTotalDueAmount);

            if (IsFound)
            {
                return new clsReturn(ReturnID, ActualReturnDate, ActualRentalDays,
                    Mileage, ConsumedMileage, FinalCheckNotes, AdditionalCharges,
                    ActualTotalDueAmount);
            }
            else
            {
                return null;
            }
        }

        public static bool DeleteReturn(int? ReturnID)
        {
            return clsReturnData.DeleteReturn(ReturnID);
        }

        public static bool DoesReturnExist(int? ReturnID)
        {
            return clsReturnData.DoesReturnExist(ReturnID);
        }

        public static DataTable GetAllVehicleReturns()
        {
            return clsReturnData.GetAllVehicleReturns();
        }

        public static int GetReturnCount()
        {
            return clsReturnData.GetReturnCount();
        }

        public bool CompleteReturnWorkflow(int? TransactionID)
        {
            LastError = null;

            if (!TransactionID.HasValue)
            {
                LastError = "Không tìm thấy giao dịch của đơn đặt xe để quyết toán.";
                return false;
            }

            if (this.ActualRentalDays < 1)
            {
                LastError = "Số ngày thuê thực tế phải lớn hơn hoặc bằng 1.";
                return false;
            }

            if (this.Mileage < 0)
            {
                LastError = "Số KM hiện tại không hợp lệ.";
                return false;
            }

            if (this.AdditionalCharges < 0)
            {
                LastError = "Phí phát sinh không được âm.";
                return false;
            }

            if (this.ActualTotalDueAmount < 0)
            {
                LastError = "Tổng tiền thanh toán thực tế không hợp lệ.";
                return false;
            }

            int? returnID = this.ReturnID;
            decimal? totalRemaining = null;
            decimal? totalRefundedAmount = null;
            string failureReason;

            bool isCompleted = clsReturnData.CompleteReturnWithTransactionAndVehicleUpdate(
                TransactionID,
                this.ActualReturnDate,
                this.ActualRentalDays,
                this.Mileage,
                this.ConsumedMileage,
                this.FinalCheckNotes,
                this.AdditionalCharges,
                this.ActualTotalDueAmount,
                ref returnID,
                ref totalRemaining,
                ref totalRefundedAmount,
                out failureReason);

            if (isCompleted)
            {
                this.ReturnID = returnID;
                this.Mode = enMode.Update;
            }
            else
            {
                LastError = failureReason;
            }

            return isCompleted;
        }

        public bool UpdateTransaction(int? TransactionID)
        {
            clsTransaction Transaction = clsTransaction.FindByTransactionID(TransactionID);

            if (Transaction == null)
            {
                return false;
            }

            Transaction.ReturnID = this.ReturnID;
            Transaction.ActualTotalDueAmount = this.ActualTotalDueAmount;
            Transaction.TotalRemaining = Transaction.PaidInitialTotalDueAmount >= 0
                ? this.ActualTotalDueAmount - Transaction.PaidInitialTotalDueAmount
                : (decimal?)null;

            return Transaction.Save();
        }
    }
}
