using AgainProjectXAF.Module.BusinessObjects.PurchaseManagement;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;

namespace AgainProjectXAF.Module.BusinessObjects.PurchaseManagament
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