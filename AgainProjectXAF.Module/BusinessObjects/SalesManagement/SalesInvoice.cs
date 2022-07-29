using AgainProjectXAF.Module.BusinessObjects.PurchaseManagement;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System;
using System.Linq;

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




        public void UpdateTotals()
        {
            OnChanged("TotalAmount");
        }




        /// <summary>
        ///             COLLECTİON5
        /// </summary>
        [Association("SalesInvoice-SalesInvoiceItem"), DevExpress.ExpressApp.DC.Aggregated]
        public XPCollection<SalesInvoiceItem> SalesInvoiceItems
        {
            get {return GetCollection<SalesInvoiceItem>(nameof(SalesInvoiceItems)); }
        }

        private decimal _TotalAmount;
        [ImmediatePostData]
        [PersistentAlias("SalesInvoiceItems.Sum(Amount)")] //PersistentAlias alanlar database e kaydolmaz.
        /// <summary>
        /// Toplam tutar hesaplamak için hesaplanır alan açtım
        /// set açmamın nedeni başka bir BO içerisinden buraya veri set etmem gerekiyor bu yüzden
        /// </summary>
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
    }
}