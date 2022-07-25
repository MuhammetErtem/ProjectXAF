using AgainProjectXAF.Module.BusinessObjects.PurchaseManagement;
using DevExpress.ExpressApp;
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

        /// <summary>
        ///             COLLECTİON
        /// </summary>
        [Association("SalesInvoice-SalesInvoiceItem"), DevExpress.ExpressApp.DC.Aggregated]
        public XPCollection<SalesInvoiceItem> SalesInvoiceItems
        {
            get { return GetCollection<SalesInvoiceItem>(nameof(SalesInvoiceItems)); }
        }

        private decimal _TotalAmount;
        [ImmediatePostData]
        [PersistentAlias("SalesInvoiceItems.Sum(Amount)")]
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


        //protected override void OnSaving()
        //{
        //    FinancialMovement financialMovement = objectSpace.CreateObject<FinancialMovement>();

        //    financialMovement.Date = Date;
        //    financialMovement.CustomerSupplier = CustomerSupplier;
        //    financialMovement.Credit = TotalAmount;
        //    financialMovement.Invoice = (SalesInvoice)This;
        //    base.OnSaving();
        //}

    }
}