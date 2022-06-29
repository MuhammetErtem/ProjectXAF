using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;
using System.Collections;
using System.Linq;

namespace AgainProjectXAF.Module.BusinessObjects.PuchaseManagament
{
    [DefaultClassOptions]
    [ImageName("BO_Invoice")]
    public class PurchaseInvoice : BaseObject
    {
        public PurchaseInvoice(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            if (!(Session is NestedUnitOfWork) && (Session.DataLayer != null) && Session.IsNewObject(this) && string.IsNullOrEmpty(DocumentId))
            {
                int code = DistributedIdGeneratorHelper.Generate(Session.DataLayer, this.GetType().FullName, "PurchaseInvoicieServerPrefix");
                //Generate ye f12 yaptığımızda vereceğimiz kod bloklarının oraya gidiyoruz.
                DocumentId = string.Format("BLG-{0:D10}", code);
                //Önemli :  Bunu yaptıktan sonra BOModel içerisinde AllowEdit i false yapmamız gerekiyor.
                //Kodun ardından Build  /Module.cs/Referansed Assemblies/DevExpress.Persistent.BaseImpl.v.x/OidGenerator/Sağclick/UseTypInApplication Tıklamamız gerekiyor.

                //Bu if kontrolü tamamen bakılıp yorumlanacak.

                //XPCollection<CustomerSupplier> collection = new XPCollection<CustomerSupplier>(Session); //session= kalıcı nesneyi yüklemek ve kaydetmek için kullanılır
                //DocumentId = $"Kod-00000000{collection.Count + 1}"; //Kodun sayısına bir eklemeyi yazdık ancak şöyle bir durum oluşur 8 sıfır + +1 ekler 9 haleye çıkar 10 haneye çıkar 
                //                                                  //Bunun kodunu tekrardan bakıp düzeltmem gerekiyor.
            }
            Date = DateTime.Now; //Bilgisayarın tarihini alıp yazıyor.
        }

        private string _DocumentId;
        [RuleRequiredField("RuleRequiredField for PurchaseInvoice.DocumentId", DefaultContexts.Save)]
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
        [RuleRequiredField("RuleRequiredField for PurchaseInvoice.Date", DefaultContexts.Save)]
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
        [RuleRequiredField("RuleRequiredField for PurchaseInvoice.CustomerSupplier", DefaultContexts.Save)]
        [Association("CustomerSupplier-PurchaseInvoices")]
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
        [Association("PurchaseInvoice-PurchaseInvoiceItem"), DevExpress.ExpressApp.DC.Aggregated]
        public XPCollection<PurchaseInvoiceItem> PurchaseInvoiceItems
        {
            get { return GetCollection<PurchaseInvoiceItem>(nameof(PurchaseInvoiceItems)); }

        }

        [PersistentAlias("PurchaseInvoiceItems.Sum(Amount)")]
        [ImmediatePostData]

        public decimal TotalAmount
        {
            get { return Convert.ToDecimal(EvaluateAlias(nameof(TotalAmount))); }
        }

        [Association("PurchaseInvoice-FinancialMovements"), DevExpress.ExpressApp.DC.Aggregated]
        public XPCollection<FinancialMovement> FinancialMovements
        {
            get { return GetCollection<FinancialMovement>("FinancialMovements"); }
        }
    }
}