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
        [ImmediatePostData]
        public decimal Amount
        {
            get { return _Amount = DiscountedPrice + Tax; }
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
        /// <summary>
        ///
        /// </summary>
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


        [PersistentAlias("(UnitPrice)*((Product.TaxRate)*(0.01))")]
        [RuleRequiredField("RuleRequiredField for SalesInvoiceItem.Tax", DefaultContexts.Save)]
        [ImmediatePostData]
        public decimal Tax
        {
            get { return Convert.ToDecimal(EvaluateAlias(nameof(Tax))); }
        }

        private int _Discount;
        [ImmediatePostData]
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

        [PersistentAlias("(DiscountedPrice)/(UnitSetDetail.Quantity)/(Quantity)")]
        [ImmediatePostData]
        public decimal UnitCost
        {
            get { return Convert.ToDecimal(EvaluateAlias(nameof(UnitCost))); }
        }
    }
}