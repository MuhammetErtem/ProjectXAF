using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System;

namespace AgainProjectXAF.Module.BusinessObjects.PurchaseManagement
{
    [DefaultClassOptions]
    [ImageName("BO_Invoice")]
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

        [PersistentAlias("PurchaseInvoiceItems.Sum(Amount)")]
        [ImmediatePostData]
        public decimal TotalAmount
        {
            get { return Convert.ToDecimal(EvaluateAlias(nameof(TotalAmount))); }
        }
    }
}