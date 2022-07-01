using AgainProjectXAF.Module.BusinessObjects.PuchaseManagament;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System.Linq;

namespace AgainProjectXAF.Module.BusinessObjects.StockManagement
{
    [DefaultClassOptions] //Kaldırdığımızda menüde görünmesini engelliyoruz.
    [ImageName("BO_Contact")]
    public class UnitSetDetail : BaseObject
    { 
        public UnitSetDetail(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            if (!(Session is NestedUnitOfWork) && (Session.DataLayer != null) && Session.IsNewObject(this) && string.IsNullOrEmpty(Code))
            {
                int code = DistributedIdGeneratorHelper.Generate(Session.DataLayer, this.GetType().FullName, "UnitSetDetailServerPrefix");
                Code = string.Format("Kod-{0:D10}", code);
            }
        }

        private string _Code;
        [RuleRequiredField("RuleRequiredField for UnitSetDetail.Code", DefaultContexts.Save)]
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
        [RuleRequiredField("RuleRequiredField for UnitSetDetail.Name", DefaultContexts.Save)]
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

        private bool _IsMaınUnit;
        [RuleRequiredField("RuleRequiredField for UnitSetDetail.IsMaınUnit", DefaultContexts.Save)]
        /// <summary>
        ///
        /// </summary>
        public bool IsMaınUnit
        {

            get { return _IsMaınUnit; }
            set
            {
                if (SetPropertyValue<bool>(nameof(IsMaınUnit), ref _IsMaınUnit, value))
                {

                    if (!IsLoading && !IsSaving)
                    {
                        if (UnitSet.UnitSetDetails.Count == 0)
                        {
                            IsMaınUnit = true;
                        }

                        else
                        {
                            IsMaınUnit = false;

                        }
                    }

                }
            }
        }


        private UnitSet _UnitSet;
        [RuleRequiredField("RuleRequiredField for UnitSetDetail.UnitSet", DefaultContexts.Save)]
        [Association("UnitSet-UnitSetDetails")]
        [VisibleInListView(false)]
        /// <summary>
        ///
        /// </summary>
        public UnitSet UnitSet
        {
            get { return _UnitSet; }
            set
            {
                if (SetPropertyValue<UnitSet>(nameof(UnitSet), ref _UnitSet, value))
                {
                    if (!IsLoading && !IsSaving)
                    {
                        if (value.UnitSetDetails.Count == 0)
                        {
                            IsMaınUnit = true;
                        }

                        else
                        {
                            IsMaınUnit = false;

                        }
                    }
                }
            }
        }


        private decimal _Quantity;
        [RuleRequiredField("RuleRequiredField for UnitSetDetail.Quantity", DefaultContexts.Save)]
        /// <summary>
        ///
        /// </summary>
        public decimal Quantity
        {
            get { return _Quantity; }
            set
            {
                if (SetPropertyValue<decimal>(nameof(Quantity), ref _Quantity, value))
                {
                    if (!IsLoading && !IsSaving)
                    {

                    }
                }
            }
        }



        [Association("UnitSetDetail-PurchaseInvoiceItems"), Aggregated]
        public XPCollection<PurchaseInvoiceItem> PurchaseInvoiceItems
        {
            get { return GetCollection<PurchaseInvoiceItem>("PurchaseInvoiceItems"); }
        }

        [Association("UnitSetDetail-SalesInvoiceItems"), Aggregated]
        public XPCollection<SalesInvoiceItem> SalesInvoiceItems
        {
            get { return GetCollection<SalesInvoiceItem>("SalesInvoiceItems"); }
        }
    }
}