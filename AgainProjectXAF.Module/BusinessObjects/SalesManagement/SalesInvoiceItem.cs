using AgainProjectXAF.Module.BusinessObjects.StockManagement;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;

namespace AgainProjectXAF.Module.BusinessObjects.SalesManagement
{
    [ImageName("BO_Contact")]
    //[DefaultClassOptions]
    public class SalesInvoiceItem : BaseObject
    { 
        public SalesInvoiceItem(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }
        private SalesInvoice _SalesInvoice;
        [RuleRequiredField("RuleRequiredField for SalesInvoiceItem.SalesInvoice", DefaultContexts.Save)]
        [Association("SalesInvoice-SalesInvoiceItem")]
        [Persistent("Satış Faturası")]
        [ImmediatePostData]

        /// <summary>
        ///               REFERANS
        /// </summary>
        public SalesInvoice SalesInvoice
        {
            get { return _SalesInvoice; }
            set
            {
                if (SetPropertyValue<SalesInvoice>(nameof(SalesInvoice), ref _SalesInvoice, value))
                {
                    if (!IsLoading && !IsSaving)
                    {

                    }
                }
            }
        }

        private Product _Product;
        [RuleRequiredField("RuleRequiredField for SalesInvoiceItem.Product", DefaultContexts.Save)]
        [Association("Product-SalesInvoiceItems")]
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
        [RuleRequiredField("RuleRequiredField for SalesInvoiceItem.Quantity", DefaultContexts.Save)]
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

        [RuleRequiredField("RuleRequiredField for SalesInvoiceItem.UnitSetDetail", DefaultContexts.Save)]
        [Association("UnitSetDetail-SalesInvoiceItems")]
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

        [Persistent("Tutar")]
        private decimal fAmount;
        [ImmediatePostData]
        public decimal Amount
        {
            get { return fAmount = DiscountedPrice + Tax; }
        }







        [PersistentAlias("(Product.Price)*(UnitSetDetail.Quantity)*(Quantity)")]
        [RuleRequiredField("RuleRequiredField for SalesInvoiceItem.UnitPrice", DefaultContexts.Save)]
        [ImmediatePostData]
        public decimal UnitPrice
        {
            get { return Convert.ToDecimal(EvaluateAlias(nameof(UnitPrice))); } //Açıklaması bakılacak. 
            //Sadece get olduğu için okunabilir olur. Set kaldırılmasının nedeni ,yazılabilir bir veri istemediğimizdendir.
        }

        [ImmediatePostData]
        [PersistentAlias("(Product.Name)")]
        [RuleRequiredField("RuleRequiredField for SalesInvoiceItem.ProductName", DefaultContexts.Save)]
        public string ProductName
        {
            get { return Convert.ToString(EvaluateAlias("ProductName")); }
        }


        [PersistentAlias("(UnitPrice)*((Product.TaxRate)*(0.01))")]
        [RuleRequiredField("RuleRequiredField for SalesInvoiceItem.Tax", DefaultContexts.Save)]
        [ImmediatePostData]
        public decimal Tax
        {
            get { return Convert.ToDecimal(EvaluateAlias(nameof(Tax))); }
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
        [RuleRequiredField("RuleRequiredField for SalesInvoiceItem.DiscountedPrice", DefaultContexts.Save)]
        [ImmediatePostData]
        public decimal DiscountedPrice
        {
            get { return Convert.ToDecimal(EvaluateAlias(nameof(DiscountedPrice))); }
        }


        [PersistentAlias("(DiscountedPrice)/(UnitSetDetail.Quantity)/(Quantity)")]
        [RuleRequiredField("RuleRequiredField for SalesInvoiceItem.UnitCost", DefaultContexts.Save)]
        [ImmediatePostData]
        public decimal UnitCost
        {
            get { return Convert.ToDecimal(EvaluateAlias(nameof(UnitCost))); }
        }
    }
}