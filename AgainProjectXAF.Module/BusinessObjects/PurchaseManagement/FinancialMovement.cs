using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using System;

namespace AgainProjectXAF.Module.BusinessObjects.PurchaseManagement
{
    //[DefaultClassOptions]
    public class FinancialMovement : BaseObject
    {
        public FinancialMovement(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }


        private CustomerSupplier _CustomerSupplier;
        [Association("CustomerSupplier-FinancialMovements")]
        /// <summary>
        ///
        /// </summary>
        public CustomerSupplier CustomerSupplier
        {
            get { return _CustomerSupplier; }
            set
            {
                if (SetPropertyValue<CustomerSupplier>(nameof(CustomerSupplier), ref _CustomerSupplier, value))
                {
                    if (!IsLoading && !IsSaving)
                    {

                    }
                }
            }
        }

        private Invoice _Invoice;
        [Association("Invoice-FinancialMovements")]
        /// <summary>
        ///
        /// </summary>
        public Invoice Invoice
        {
            get { return _Invoice; }
            set
            {
                if (SetPropertyValue<Invoice>(nameof(Invoice), ref _Invoice, value))
                {
                    if (!IsLoading && !IsSaving)
                    {

                    }
                }
            }
        }


        private decimal _Debt;
        /// <summary>
        ///
        /// </summary>
        public decimal Debt
        {
            get { return _Debt; }
            set
            {
                if (SetPropertyValue<decimal>(nameof(Debt), ref _Debt, value))
                {
                    if (!IsLoading && !IsSaving)
                    {

                    }
                }
            }
        }


        private decimal _Credit;
        /// <summary>
        ///
        /// </summary>
        public decimal Credit
        {
            get { return _Credit; }
            set
            {
                if (SetPropertyValue<decimal>(nameof(Credit), ref _Credit, value))
                {
                    if (!IsLoading && !IsSaving)
                    {

                    }
                }
            }
        }

        //private string _DocumentID;

        ///// <summary>
        /////
        ///// </summary>
        //public string DocumentID
        //{
        //    get { return _DocumentID; }
        //    set
        //    {
        //        if (SetPropertyValue<string>(nameof(DocumentID), ref _DocumentID, value))
        //        {
        //            if (!IsLoading && !IsSaving)
        //            {

        //            }
        //        }
        //    }
        //}

        private DateTime _Date;
        /// <summary>
        ///
        /// </summary>
        public DateTime Date
        {
            get { return _Date; }
            set
            {
                if (SetPropertyValue<DateTime>(nameof(Date), ref _Date, value))
                {
                    if (!IsLoading && !IsSaving)
                    {

                    }
                }
            }
        }

    }
}