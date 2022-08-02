using AgainProjectXAF.Module.BusinessObjects.PurchaseManagement;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;

namespace AgainProjectXAF.Module.BusinessObjects.CRManagement
{
    //[DefaultClassOptions]
    public class DefaultSalesPerson : BaseObject
    {
        public DefaultSalesPerson(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            if (!(Session is NestedUnitOfWork) && (Session.DataLayer != null) && Session.IsNewObject(this) && string.IsNullOrEmpty(Code))
            {
                int code = DistributedIdGeneratorHelper.Generate(Session.DataLayer, this.GetType().FullName, "DefaultSalesPersonServerPrefix");
                Code = string.Format("Kod-{0:D10}", code);
            }
        }


        private string _Code;
        [RuleRequiredField("RuleRequiredField for DefaultSalesPerson.Code", DefaultContexts.Save)]
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

        [Size(120)]
        private string _Name;
        [RuleRequiredField("RuleRequiredField for DefaultSalesPerson.Name", DefaultContexts.Save)]
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

        private bool _IsMainUnit;
        [RuleRequiredField("RuleRequiredField for DefaultSalesPerson.IsMainUnit", DefaultContexts.Save)]
        /// <summary>
        ///
        /// </summary>
        public bool IsMainUnit
        {
            get { return _IsMainUnit; }
            set
            {
                if (SetPropertyValue<bool>(nameof(IsMainUnit), ref _IsMainUnit, value))
                {
                    if (!IsLoading && !IsSaving)
                    {

                    }
                }
            }
        }

        private CustomerSupplier _CustomerSupplier;
        [RuleRequiredField("RuleRequiredField for DefaultSalesPerson.CustomerSupplier", DefaultContexts.Save)]
        [Association("CustomerSupplier-DefaultSalesPersons")]
        [VisibleInListView(false)]
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
                        if (value.DefaultSalesPersons.Count == 0)
                        {
                            IsMainUnit = true;
                        }

                        else
                        {
                            IsMainUnit = false;

                        }
                    }
                }
            }
        }


        [Association("DefaultSalesPerson-Invoices"), DevExpress.ExpressApp.DC.Aggregated]
        public XPCollection<Invoice> Invoices
        {
            get { return GetCollection<Invoice>("Invoices"); }
        }


    }
}