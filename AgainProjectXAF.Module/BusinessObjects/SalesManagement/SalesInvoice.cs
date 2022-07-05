using AgainProjectXAF.Module.BusinessObjects.PurchaseManagament;
using AgainProjectXAF.Module.BusinessObjects.PurchaseManagement;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;

namespace AgainProjectXAF.Module.BusinessObjects.SalesManagement
{
    [DefaultClassOptions]
    [ImageName("BO_Invoice")]
    public class SalesInvoice : Invoice
    {
        public SalesInvoice(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            
        }

        /// <summary>
        ///             COLLECTİON
        /// </summary>
        [Association("SalesInvoice-SalesInvoiceItem"), DevExpress.ExpressApp.DC.Aggregated]
        public XPCollection<SalesInvoiceItem> SalesInvoiceItems
        {
            get { return GetCollection<SalesInvoiceItem>(nameof(SalesInvoiceItems)); }

        }


        [PersistentAlias("SalesInvoiceItems.Sum(Amount)")]
        [ImmediatePostData]

        public decimal TotalAmount
        {
            get { return Convert.ToDecimal(EvaluateAlias(nameof(TotalAmount))); }
        }
    }
}