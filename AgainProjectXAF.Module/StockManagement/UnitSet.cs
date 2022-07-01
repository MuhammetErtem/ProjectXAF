using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;

namespace AgainProjectXAF.Module.BusinessObjects.StockManagement
{
    [DefaultClassOptions]
    [ImageName("BO_Category")]
    public class UnitSet : BaseObject
    { 
        public UnitSet(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            base.AfterConstruction();
            if (!(Session is NestedUnitOfWork) && (Session.DataLayer != null) && Session.IsNewObject(this) && string.IsNullOrEmpty(Code))
            {
                int code = DistributedIdGeneratorHelper.Generate(Session.DataLayer, this.GetType().FullName, "UnitSetServerPrefix");
                Code = string.Format("Kod-{0:D10}", code);
            }
        }

        private string _Code;
        [RuleRequiredField("RuleRequiredField for UnitSet.Code", DefaultContexts.Save)]
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
        [RuleRequiredField("RuleRequiredField for UnitSet.Name", DefaultContexts.Save)]
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

        /// <summary>
        ///                 COLLECTİON
        /// </summary>
        [Association("UnitSet-Products"), Aggregated] //Agregated = Eğer bunun UnitSet ini silersem buna ait olanlar da silinsin mi ?
        public XPCollection<Product> Products
        {
            get { return GetCollection<Product>("Products"); }
        }


        [Association("UnitSet-UnitSetDetails"), Aggregated]
        public XPCollection<UnitSetDetail> UnitSetDetails
        {
            get { return GetCollection<UnitSetDetail>("UnitSetDetails"); }
        }

    }
}