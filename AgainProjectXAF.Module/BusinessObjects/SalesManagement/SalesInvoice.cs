using AgainProjectXAF.Module.BusinessObjects.PurchaseManagament;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;

namespace AgainProjectXAF.Module.BusinessObjects.SalesManagement
{
    [DefaultClassOptions]
    [ImageName("BO_Invoice")]
    public class SalesInvoice : BaseObject
    {
        public SalesInvoice(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            if (!(Session is NestedUnitOfWork) && (Session.DataLayer != null) && Session.IsNewObject(this) && string.IsNullOrEmpty(DocumentId))
            {
                int code = DistributedIdGeneratorHelper.Generate(Session.DataLayer, this.GetType().FullName, "SalesInvoicieServerPrefix");
                DocumentId = string.Format("BLG-{0:D10}", code);
            }
            Date = DateTime.Now;
        }

        private string _DocumentId;
        [RuleRequiredField("RuleRequiredField for SalesInvoice.DocumentId", DefaultContexts.Save)]
        /// <summary>
        ///
        /// </summary>
        public string DocumentId
        {
            get { return _DocumentId; }
            set
            {
                if (SetPropertyValue<string>(nameof(DocumentId), ref _DocumentId, value))
                {
                    if (!IsLoading && !IsSaving)
                    {

                    }
                }
            }
        }

        private DateTime _Date;
        [RuleRequiredField("RuleRequiredField for SalesInvoice.Date", DefaultContexts.Save)]
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


        private CustomerSupplier _CustomerSupplier;
        [RuleRequiredField("RuleRequiredField for SalesInvoice.CustomerSupplier", DefaultContexts.Save)]
        [Association("CustomerSupplier-SalesInvoices")]
        /// <summary>
        ///             REFERANS
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

        [Association("SalesInvoice-FinancialMovements"), DevExpress.ExpressApp.DC.Aggregated]
        public XPCollection<FinancialMovement> FinancialMovements
        {
            get { return GetCollection<FinancialMovement>("FinancialMovements"); }
        }
    }
}