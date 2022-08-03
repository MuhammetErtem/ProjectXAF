using AgainProjectXAF.Module.BusinessObjects.CRManagement;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;

namespace AgainProjectXAF.Module.BusinessObjects.PurchaseManagement
{
    //[DefaultClassOptions]
    public abstract class Invoice : BaseObject
    {
        public Invoice(Session session): base(session)
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
        [RuleRequiredField("RuleRequiredField for Invoice.DocumentId", DefaultContexts.Save)]
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
        [RuleRequiredField("RuleRequiredField for Invoice.Date", DefaultContexts.Save)]
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
        [RuleRequiredField("RuleRequiredField for Invoice.CustomerSupplier", DefaultContexts.Save)]
        [Association("CustomerSupplier-Invoices")]
        [ImmediatePostData]
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
                    if (!IsLoading && !IsSaving && !IsDeleted)
                    {
                        DefaultSalesPerson = CustomerSupplier.DefaultSalesPerson;
                    }
                }
            }
        }
        private DefaultSalesPerson _DefaultSalesPerson;
        [RuleRequiredField("RuleRequiredField for Invoice.DefaultSalesPerson", DefaultContexts.Save)]
        [Association("DefaultSalesPerson-Invoices")]
        [DataSourceCriteria("CustomerSupplier.Oid = '@DefaultSalesPerson.CustomerSupplier.Oid'")]
        [ImmediatePostData]
        /// <summary>
        ///             REFERANS
        /// </summary>
        public DefaultSalesPerson DefaultSalesPerson
        {
            get { return _DefaultSalesPerson; }
            set
            {
                if (SetPropertyValue<DefaultSalesPerson>(nameof(DefaultSalesPerson), ref _DefaultSalesPerson, value))
                {
                    if (!IsLoading && !IsSaving)
                    {

                    }
                }
            }
        }

        [Association("Invoice-FinancialMovements"), DevExpress.ExpressApp.DC.Aggregated]
        public XPCollection<FinancialMovement> FinancialMovements
        {
            get { return GetCollection<FinancialMovement>("FinancialMovements"); }
        }

    }
}