using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;

namespace AgainProjectXAF.Module.BusinessObjects.PurchaseManagement
{
    [DefaultClassOptions]
    [ImageName("BO_Invoice")]
    //[FileAttachment("File")]
    //[FileAttachmentAttribute(nameof(File))]
    public class PurchaseInvoice : Invoice
    {
        public PurchaseInvoice(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }



        public void UpdateTotals()
        {
            OnChanged("TotalAmount");
        }

        //protected override void OnSaved()
        //{
        //    base.OnSaved();

        //    FinancialMovement fm = new FinancialMovement(Session);
        //    fm.Date = Date;
        //    fm.CustomerSupplier = CustomerSupplier;
        //    fm.PurchaseInvoiceAmount = TotalAmount;
        //    fm.PurchaseInvoice = this;
        //    fm.PurchaseInvoiceDocumentID = DocumentId;
        //    fm.Save();

        //}



        /// <summary>
        ///             COLLECTİON
        /// </summary>
        [Association("PurchaseInvoice-PurchaseInvoiceItem"), DevExpress.ExpressApp.DC.Aggregated]
        [ImmediatePostData]
        public XPCollection<PurchaseInvoiceItem> PurchaseInvoiceItems
        {
            get { return GetCollection<PurchaseInvoiceItem>(nameof(PurchaseInvoiceItems)); }
        }

        private decimal _TotalAmount;
        [ImmediatePostData]
        [PersistentAlias("PurchaseInvoiceItems.Sum(Amount)")]
        public decimal TotalAmount
        {
            get { return Convert.ToDecimal(EvaluateAlias(nameof(TotalAmount))); }
            set
            {
                if (SetPropertyValue<decimal>(nameof(TotalAmount), ref _TotalAmount, value))
                {
                    if (!IsLoading && !IsSaving)
                    {
                    }
                }
            }
        }

        //[Aggregated, ExpandObjectMembers(ExpandObjectMembers.Never)]
        //public FileData File
        //{
        //    get { return GetPropertyValue<FileData>("File"); }
        //    set { SetPropertyValue<FileData>("File", value); }
        //}
    }
}