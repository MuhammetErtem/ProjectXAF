using AgainProjectXAF.Module.BusinessObjects.StockManagement;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;
using System;

namespace AgainProjectXAF.Module.BusinessObjects.PuchaseManagament
{
    [DefaultClassOptions]
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

        private Product _Product;
        [Association("Product-FinancialMovements")]
        /// <summary>
        ///
        /// </summary>
        public Product Product
        {
            get { return _Product; }
            set
            {
                if (SetPropertyValue<Product>(nameof(Product), ref _Product, value))
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
                        PurchaseInvoiceAmount = PurchaseInvoice.TotalAmount;
                        PurchaseInvoiceDocumentID = PurchaseInvoice.DocumentId;
                    }
                }
            }
        }



        //PurchaseInvoice.DocumentId
        private string _PurchaseInvoiceDocumentID;

        /// <summary>
        ///
        /// </summary>
        public string PurchaseInvoiceDocumentID
        {
            get { return _PurchaseInvoiceDocumentID; }
            set
            {
                if (SetPropertyValue<string>(nameof(PurchaseInvoiceDocumentID), ref _PurchaseInvoiceDocumentID, value))
                {
                    if (!IsLoading && !IsSaving)
                    {
                        
                    }
                }
            }
        }



        //SalesInvoice.DocumentId
        private string _SalesInvoiceDocumentID;
        /// <summary>
        ///
        /// </summary>
        public string SalesInvoiceDocumentID
        {
            get { return _SalesInvoiceDocumentID; }
            set
            {
                if (SetPropertyValue<string>(nameof(SalesInvoiceDocumentID), ref _SalesInvoiceDocumentID, value))
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

    }

}