using AgainProjectXAF.Module.BusinessObjects.SalesManagement;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using System;

namespace AgainProjectXAF.Module.BusinessObjects.PurchaseManagament
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

        private PurchaseInvoice _PurchaseInvoice;
        [Association("PurchaseInvoice-FinancialMovements")]

        /// <summary>
        ///
        /// </summary>
        public PurchaseInvoice PurchaseInvoice
        {
            get { return _PurchaseInvoice; }
            set
            {
                if (SetPropertyValue<PurchaseInvoice>(nameof(PurchaseInvoice), ref _PurchaseInvoice, value))
                {
                    if (!IsLoading && !IsSaving)
                    {
                       
                    }
                }
            }
        }
        private SalesInvoice _SalesInvoice;
        [Association("SalesInvoice-FinancialMovements")]

        /// <summary>
        ///
        /// </summary>
        public SalesInvoice SalesInvoice
        {
            get { return _SalesInvoice; }
            set
            {
                if (SetPropertyValue<SalesInvoice>(nameof(SalesInvoice), ref _SalesInvoice, value))
                {
                    if (!IsLoading && !IsSaving)
                    {
                       
                    }
                }
            }
        }



        private string _DocumentID;

        /// <summary>
        ///
        /// </summary>
        public string DocumentID
        {
            get { return _DocumentID; }
            set
            {
                if (SetPropertyValue<string>(nameof(DocumentID), ref _DocumentID, value))
                {
                    if (!IsLoading && !IsSaving)
                    {
                        
                    }
                }
            }
        }


        //PurchaseInvoice.Date
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

        //PurchaseInvoiceItem.Amount
        private decimal _PurchaseInvoiceAmount;
        /// <summary>
        ///
        /// </summary>
        public decimal PurchaseInvoiceAmount
        {
            get { return _PurchaseInvoiceAmount; }
            set
            {
                if (SetPropertyValue<decimal>(nameof(PurchaseInvoiceAmount), ref _PurchaseInvoiceAmount, value))
                {
                    if (!IsLoading && !IsSaving)
                    {
                        
                    }
                }
            }
        }

        //SalesInvoiceItem.Amount
        private decimal _SalesInvoiceAmount;
        /// <summary>
        ///
        /// </summary>
        public decimal SalesInvoiceAmount
        {
            get { return _SalesInvoiceAmount; }
            set
            {
                if (SetPropertyValue<decimal>(nameof(SalesInvoiceAmount), ref _SalesInvoiceAmount, value))
                {
                    if (!IsLoading && !IsSaving)
                    {

                    }
                }
            }
        }


        private string _Invoice;
        /// <summary>
        ///
        /// </summary>
        public string Invoice
        {
            get { return _Invoice; }
            set
            {
                if (SetPropertyValue<string>(nameof(Invoice), ref _Invoice, value))
                {
                    if (!IsLoading && !IsSaving)
                    {

                    }
                }
            }
        }

    }
}