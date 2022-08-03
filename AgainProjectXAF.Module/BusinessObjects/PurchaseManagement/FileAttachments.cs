using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Xpo;

namespace AgainProjectXAF.Module.BusinessObjects.PurchaseManagement
{
    //[DefaultClassOptions]
    public class FileAttachments : FileAttachmentBase
    {
        public FileAttachments(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }

        private string _Title;
        [Size(SizeAttribute.DefaultStringMappingFieldSize)]
        //[RuleRequiredField("RuleRequiredField for FileAttachments.Title", DefaultContexts.Save)]
        public string Title
        {
            get { return _Title; }
            set
            {
                if (SetPropertyValue<string>(nameof(Title), ref _Title, value))
                {
                    if (!IsLoading && !IsSaving)
                    {

                    }
                }
            }
        }

        CustomerSupplier _CustomerSupplier;
        [Association("CustomerSupplier-FileAttachmentss")]
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
    }
}