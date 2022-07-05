using AgainProjectXAF.Module.BusinessObjects.StockManagement;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;
using System.ComponentModel;

namespace AgainProjectXAF.Module.BusinessObjects.PurchaseManagament
{
    //[RuleCombinationOfPropertiesIsUnique("OneIsMainUnit", DefaultContexts.Save, "UnitSet, IsMainUnit", TargetCriteria = "IsMainUnit==True")] 
    //Yanlızca bir tane veri true olabilir yaptık.

    [DefaultClassOptions] // Kaldırdığımızda menüde görünmesini engelliyoruz.
    [ImageName("BO_Contact")]
    public class PurchaseInvoiceItem : BaseObject
    {
        public PurchaseInvoiceItem(Session session)
            : base(session)
        {

        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }


        private PurchaseInvoice _PurchaseInvoice;
        [RuleRequiredField("RuleRequiredField for PurchaseInvoiceItem.PurchaseInvoice", DefaultContexts.Save)]
        [Association("PurchaseInvoice-PurchaseInvoiceItem")]
        [Persistent("Satın Alma Faturası")]
        [ImmediatePostData]

        /// <summary>
        ///               REFERANS
        /// </summary>
        public PurchaseInvoice PurchaseInvoice
        {
            get { return _PurchaseInvoice; }
            set
            {
                if (SetPropertyValue<PurchaseInvoice>(nameof(PurchaseInvoice), ref _PurchaseInvoice, value))
                {
                    if (!IsLoading && !IsSaving)
                    {

                    }
                }
            }
        }

        private Product _Product;
        [RuleRequiredField("RuleRequiredField for PurchaseInvoiceItem.Product", DefaultContexts.Save)]
        [Association("Product-PurchaseInvoiceItems")]
        [Persistent("Malzeme")]
        [ImmediatePostData]
        public Product Product
        {
            get { return _Product; }
            set
            {
                if (SetPropertyValue<Product>(nameof(Product), ref _Product, value))
                {
                    if (!IsLoading && !IsSaving)
                    {
                        //UnitPrice = Product.Price; // Ürünü set ettiğimizde UnitPrice alanına ürünün fiyatını yazıyor.
                        //Kod patlıyor. Buna bakılacak ? 
                    }
                }
            }
        }

        private int _Quantity;
        [RuleRequiredField("RuleRequiredField for PurchaseInvoiceItem.Quantity", DefaultContexts.Save)]
        [Persistent("Miktar")]
        [ImmediatePostData]
        /// <summary>
        ///
        /// </summary>
        public int Quantity
        {
            get { return _Quantity; }
            set
            {
                if (SetPropertyValue<int>(nameof(Quantity), ref _Quantity, value))
                {
                    if (!IsLoading && !IsSaving)
                    {

                    }
                }
            }
        }
        private UnitSetDetail _UnitSetDetail;

        [RuleRequiredField("RuleRequiredField for PurchaseInvoiceItem.UnitSetDetail", DefaultContexts.Save)]
        [Association("UnitSetDetail-PurchaseInvoiceItems")]
        [VisibleInListView(false)]
        [Persistent("Birim Set")]
        [ImmediatePostData]
        public UnitSetDetail UnitSetDetail
        {
            get { return _UnitSetDetail; }
            set
            {
                if (SetPropertyValue<UnitSetDetail>(nameof(UnitSetDetail), ref _UnitSetDetail, value))
                {
                    if (!IsLoading && !IsSaving)
                    {

                    }
                }
            }
        }

        private decimal _Amount;
        [Persistent("Tutar")]
        [ImmediatePostData]
        public decimal Amount
        {
            get { return _Amount = DiscountedPrice + Tax;}
            set { }
        }








        [PersistentAlias("(UnitPrice)*((Product.TaxRate)*(0.01))")]
        [RuleRequiredField("RuleRequiredField for PurchaseInvoiceItem.Tax", DefaultContexts.Save)]
        [ImmediatePostData]
        public decimal Tax
        {
            get { return Convert.ToDecimal(EvaluateAlias(nameof(Tax))); }
        }

        [PersistentAlias("(Product.Price)*(UnitSetDetail.Quantity)*(Quantity)")]
        [ImmediatePostData]
        public decimal UnitPrice
        {
            get { return Convert.ToDecimal(EvaluateAlias(nameof(UnitPrice))); } //Açıklaması bakılacak. 
            //Sadece get olduğu için okunabilir olur. Set kaldırılmasının nedeni ,yazılabilir bir veri istemediğimizdendir.
        }

        [PersistentAlias("(DiscountedPrice)/(UnitSetDetail.Quantity)/(Quantity)")] //UnitSetDetail.Quantity
        [RuleRequiredField("RuleRequiredField for PurchaseInvoiceItem.UnitCost", DefaultContexts.Save)]
        [ImmediatePostData]
        public decimal UnitCost
        {
            get { return Convert.ToDecimal(EvaluateAlias(nameof(UnitCost))); }
        }

        [ImmediatePostData]
        [PersistentAlias("(Product.Name)")]
        [RuleRequiredField("RuleRequiredField for PurchaseInvoiceItem.ProductName", DefaultContexts.Save)]
        public string ProductName
        {
            get { return Convert.ToString(EvaluateAlias("ProductName")); }
        }

        private int _Discount;
        [ImmediatePostData]
        [NonPersistent]
        /// <summary>
        ///
        /// </summary>
        public int Discount
        {
            get { return _Discount; }
            set
            {
                if (SetPropertyValue<int>(nameof(Discount), ref _Discount, value))
                {
                    if (!IsLoading && !IsSaving)
                    {

                    }
                }
            }
        }


        [PersistentAlias("(UnitPrice)*(100-Discount)/100")]
        [RuleRequiredField("RuleRequiredField for PurchaseInvoiceItem.DiscountedPrice", DefaultContexts.Save)]
        [ImmediatePostData]
        public decimal DiscountedPrice
        {
            get { return Convert.ToDecimal(EvaluateAlias(nameof(DiscountedPrice))); }
        }



    }
}