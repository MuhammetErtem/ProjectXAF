using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;

namespace AgainProjectXAF.Module.BusinessObjects.StockManagement
{
    [DefaultClassOptions]
    [ImageName("BO_Price")]
    public class Brand : BaseObject
    { 
        public Brand(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            if (!(Session is NestedUnitOfWork) && (Session.DataLayer != null) && Session.IsNewObject(this) && string.IsNullOrEmpty(Code))
            {
                int code = DistributedIdGeneratorHelper.Generate(Session.DataLayer, this.GetType().FullName, "BrandServerPrefix");
                Code = string.Format("Kod-{0:D10}", code);
            }
        }

        private string _Code;
        [RuleRequiredField("RuleRequiredField for Brand.Code", DefaultContexts.Save)]
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
        [RuleRequiredField("RuleRequiredField for Brand.Name", DefaultContexts.Save)]
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

        [Association("Brand-Products"), Aggregated]
        public XPCollection<Product> Products
        {
            get { return GetCollection<Product>(nameof(Products)); }
        }

    }
}