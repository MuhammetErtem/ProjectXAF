using AgainProjectXAF.Module.BusinessObjects.RegulationManagement;
using AgainProjectXAF.Module.BusinessObjects.StockManagement;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;

namespace AgainProjectXAF.Module.BusinessObjects.SalesManagement
{
    //[ImageName("BO_Contact")]
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
                        foreach (var item in value.UnitSet.UnitSetDetails)
                        {
                            if (item != null)
                            {
                                if (item.IsMaınUnit)
                                {
                                    UnitSetDetail = item;
                                }
                            }
                        }
                        Tax = Product.Tax;
                        Quantity = 1;
                        // UnitPrice = (Product.Price)*(UnitSetDetail.Quantity)*(Quantity);*/ // Ürünü set ettiğimizde UnitPrice alanına ürünün fiyatını yazıyor.
                    }
                }
            }
        }

        private int _Quantity;
        [RuleRequiredField("RuleRequiredField for SalesInvoiceItem.Quantity", DefaultContexts.Save)]
        [Persistent("Miktar")]
        [ImmediatePostData]
        [RuleValueComparison("SalesInvoice.Price.GreaterThanZero", DefaultContexts.Save, ValueComparisonType.GreaterThanOrEqual, 1)] // Girilen sayı 1 den küçük olamaz.
        public int Quantity
        {
            get { return _Quantity; }
            set
            {
                if (SetPropertyValue<int>(nameof(Quantity), ref _Quantity, value))
                {
                    if (!IsLoading && !IsSaving)
                    {
                        UnitPrice = (Product.Price) * (UnitSetDetail.Quantity) * (Quantity);
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
                        _UnitPrice = (Product.Price) * (UnitSetDetail.Quantity) * (Quantity);
                    }
                }
            }
        }

        private decimal _Amount;
        [Persistent("Tutar")]
        [ImmediatePostData]
        public decimal Amount
        {
            get { return _Amount = DiscountedPrice + TaxAmount; }
        }

        //[PersistentAlias("(Product.Price)*(UnitSetDetail.Quantity)*(Quantity)")]
        //[ImmediatePostData]
        //public decimal UnitPrice
        //{
        //    get { return Convert.ToDecimal(EvaluateAlias(nameof(UnitPrice))); }
        //    //Açıklaması bakılacak. 
        //    //Sadece get olduğu için okunabilir olur. Set kaldırılmasının nedeni ,yazılabilir bir veri istemediğimizdendir.
        //}

        private decimal _UnitPrice;
        [Persistent("Birim Fiyat")]
        [ImmediatePostData]
        [RuleValueComparison("SalesInvoice.UnitPrice.GreaterThanZero", DefaultContexts.Save, ValueComparisonType.GreaterThanOrEqual, 1)]
        public decimal UnitPrice
        {
            get { return _UnitPrice; }
            set
            {
                if (SetPropertyValue<decimal>(nameof(UnitPrice), ref _UnitPrice, value))
                {
                    if (!IsLoading && !IsSaving)
                    {

                    }
                }
            }
        }

        //private decimal _UnitPrice;
        ///// <summary>
        /////
        ///// </summary>
        //public decimal UnitPrice
        //{
        //    get { return _UnitPrice = (Product.Price) * (UnitSetDetail.Quantity) * (Quantity); }
        //    set
        //    {
        //        if (SetPropertyValue<decimal>(nameof(UnitPrice), ref _UnitPrice, value))
        //        {
        //            if (!IsLoading && !IsSaving)
        //            {

        //            }
        //        }
        //    }
        //}

        [ImmediatePostData]
        [PersistentAlias("(Product.Name)")]
        [RuleRequiredField("RuleRequiredField for SalesInvoiceItem.ProductName", DefaultContexts.Save)]
        public string ProductName
        {
            get { return Convert.ToString(EvaluateAlias("ProductName")); }
        }

        [PersistentAlias("(UnitPrice)*((Tax.Rate)*(0.01))")]
        [RuleRequiredField("RuleRequiredField for SalesInvoiceItem.TaxAmount", DefaultContexts.Save)]
        [ImmediatePostData]
        public decimal TaxAmount
        {
            get { return Convert.ToDecimal(EvaluateAlias(nameof(TaxAmount))); }
        }

        private int _Discount;
        [Persistent("İndirim Oranı")]
        [ImmediatePostData]
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

        //[PersistentAlias("(UnitPrice)*(100-Discount)/100")]
        //[ImmediatePostData]
        //public decimal DiscountedPrice
        //{
        //    get { return Convert.ToDecimal(EvaluateAlias(nameof(DiscountedPrice))); }
        //}

        private decimal _DiscountedPrice;
        [ImmediatePostData]
        public decimal DiscountedPrice
        {
            get { return _DiscountedPrice = (UnitPrice) * (100 - Discount) / 100; }
        }

        //private decimal _UnitCost;
        //[Persistent("Birim Maliyet")]
        //public decimal UnitCost
        //{
        //    get { return _UnitCost = (DiscountedPrice)/(UnitSetDetail.Quantity)/(Quantity); }
        //}

        [PersistentAlias("(DiscountedPrice)/(UnitSetDetail.Quantity)/(Quantity)")]
        [ImmediatePostData]
        public decimal UnitCost
        {
            get { return Convert.ToDecimal(EvaluateAlias(nameof(UnitCost))); }
        }

        private decimal _DiscountAmount;
        [ImmediatePostData]
        [Persistent("İndirim Tutarı")]
        [RuleRequiredField("RuleRequiredField for SalesInvoiceItem.DiscountAmount", DefaultContexts.Save)]
        public decimal DiscountAmount
        {
            get { return _DiscountAmount = UnitPrice - DiscountedPrice; }
        }

        private Tax _Tax;
        [RuleRequiredField("RuleRequiredField for SalesInvoiceItem.Tax", DefaultContexts.Save)]
        [Association("Tax-SalesInvoiceItems")]
        public Tax Tax
        {
            get { return _Tax; }
            set
            {
                if (SetPropertyValue<Tax>(nameof(Tax), ref _Tax, value))
                {
                    if (!IsLoading && !IsSaving)
                    {

                    }
                }
            }
        }

    }
}