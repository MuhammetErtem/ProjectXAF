using AgainProjectXAF.Module.BusinessObjects.PurchaseManagement;
using AgainProjectXAF.Module.BusinessObjects.SalesManagement;
using AgainProjectXAF.Module.BusinessObjects.StockManagement;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;

namespace AgainProjectXAF.Module.BusinessObjects.RegulationManagement
{
    [DefaultClassOptions]
    public class Tax : BaseObject
    { 
        public Tax(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            if (!(Session is NestedUnitOfWork) && (Session.DataLayer != null) && Session.IsNewObject(this) && string.IsNullOrEmpty(Code))
            {
                int code = DistributedIdGeneratorHelper.Generate(Session.DataLayer, this.GetType().FullName, "TaxServerPrefix");
                Code = string.Format("VRG-{0:D3}", code);
            }
        }

        private string _Code;
        [RuleRequiredField("RuleRequiredField for Tax.Code", DefaultContexts.Save)]
        /// <summary>
        ///
        /// </summary>
        public string Code
        {
            get { return _Code; }
            set
            {
                if (SetPropertyValue<string>(nameof(Code), ref _Code, value))
                {
                    if (!IsLoading && !IsSaving)
                    {

                    }
                }
            }
        }

        private string _Name;
        [ImmediatePostData]
        [RuleRequiredField("RuleRequiredField for Tax.Name", DefaultContexts.Save)]
        /// <summary>
        ///
        /// </summary>
        public string Name
        {
            get { return _Name; }
            set
            {
                if (SetPropertyValue<string>(nameof(Name), ref _Name, value))
                {
                    if (!IsLoading && !IsSaving)
                    {

                    }
                }
            }
        }


        private int _Rate;
        [RuleRequiredField("RuleRequiredField for Tax.Rate", DefaultContexts.Save)]
        [ImmediatePostData]
        /// <summary>
        ///
        /// </summary>
        public int Rate
        {
            get { return _Rate; }
            set
            {
                if (SetPropertyValue<int>(nameof(Rate), ref _Rate, value))
                {
                    if (!IsLoading && !IsSaving)
                    {

                    }
                }
            }
        }

        [Association("Tax-PurchaseInvoiceItems"), Aggregated]
        public XPCollection<PurchaseInvoiceItem> PurchaseInvoiceItems
        {
            get { return GetCollection<PurchaseInvoiceItem>(nameof(PurchaseInvoiceItems)); }
        }

        [Association("Tax-SalesInvoiceItems"), Aggregated]
        public XPCollection<SalesInvoiceItem> SalesInvoiceItems
        {
            get { return GetCollection<SalesInvoiceItem>(nameof(SalesInvoiceItems)); }
        }
        [Association("Tax-Products"), Aggregated]
        public XPCollection<Product> Products
        {
            get { return GetCollection<Product>(nameof(Products)); }
        }
    }
}