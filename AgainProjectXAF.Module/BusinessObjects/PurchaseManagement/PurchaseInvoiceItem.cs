using AgainProjectXAF.Module.BusinessObjects.RegulationManagement;
using AgainProjectXAF.Module.BusinessObjects.StockManagement;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;

namespace AgainProjectXAF.Module.BusinessObjects.PurchaseManagement
{
    //[RuleCombinationOfPropertiesIsUnique("OneIsMainUnit", DefaultContexts.Save, "UnitSet, IsMainUnit", TargetCriteria = "IsMainUnit==True")] 
    //Yanlızca bir tane veri true olabilir yaptık.

    //[DefaultClassOptions] // Kaldırdığımızda menüde görünmesini engelliyoruz.
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

        protected override void OnDeleting()
        {
            UpdatedSalesInvoice = PurchaseInvoice;

            base.OnDeleting();
        }

        protected override void OnDeleted()
        {
            if (UpdatedSalesInvoice != null)
            {
                UpdatedSalesInvoice.UpdateTotals();
            }
            base.OnDeleted();

            //if (this.SalesInvoice.SalesInvoiceItems.Count > 0)
            //{
            //    if (this.SalesInvoice.SalesInvoiceItems.ClearCount > 0)
            //    {
            //        this.SalesInvoice.TotalAmount = 0;
            //    }
            //    for (int i = 0; i < this.SalesInvoice.SalesInvoiceItems.Count; i++)
            //    {
            //        if (!this.SalesInvoice.SalesInvoiceItems[i].IsDeleted)
            //        {
            //            this.SalesInvoice.TotalAmount += this.SalesInvoice.SalesInvoiceItems[i].Amount;
            //        }
            //    }
            //}
        }

        PurchaseInvoice UpdatedSalesInvoice = null;



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
                    if (!IsLoading && !IsSaving && !IsDeleted)
                    {
                        if (Product != null)
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
                            PurchaseInvoice.TotalAmount = (Amount);
                        }
                    }
                }
            }
        }

        private int _Quantity;
        [RuleRequiredField("RuleRequiredField for PurchaseInvoiceItem.Quantity", DefaultContexts.Save)]
        [Persistent("Miktar")]
        //[ImmediatePostData]
        [RuleValueComparison("PurchaseInvoice.Price.GreaterThanZero", DefaultContexts.Save, ValueComparisonType.GreaterThanOrEqual, 1)]
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
                    if (!IsLoading && !IsSaving && !IsDeleted)
                    {
                        UnitPrice = (Product.Price) * (UnitSetDetail.Quantity) * (Quantity);
                        PurchaseInvoice.TotalAmount = (Amount);
                    }
                }
            }
        }

        private UnitSetDetail _UnitSetDetail;
        [RuleRequiredField("RuleRequiredField for PurchaseInvoiceItem.UnitSetDetail", DefaultContexts.Save)]
        [Association("UnitSetDetail-PurchaseInvoiceItems")]
        [VisibleInListView(false)]
        [Persistent("Birim Set")]
        //[ImmediatePostData]
        [DataSourceCriteria("UnitSet.Oid = '@Product.UnitSet.Oid'")] // Product.unitset ine göre filtreli şekilde getiriyor. Modelde de var.
        public UnitSetDetail UnitSetDetail
        {
            get { return _UnitSetDetail; }
            set
            {
                if (SetPropertyValue<UnitSetDetail>(nameof(UnitSetDetail), ref _UnitSetDetail, value))
                {
                    if (!IsLoading && !IsSaving && !IsDeleted)
                    {
                        if (_UnitSetDetail != null)
                        {
                            _UnitPrice = (Product.Price) * (UnitSetDetail.Quantity) * (Quantity);
                            PurchaseInvoice.TotalAmount = (Amount);
                        }
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

        [PersistentAlias("(UnitPrice)*((Tax.Rate)*(0.01))")]
        [RuleRequiredField("RuleRequiredField for PurchaseInvoiceItem.TaxAmount", DefaultContexts.Save)]
        [ImmediatePostData]
        public decimal TaxAmount
        {
            get { return Convert.ToDecimal(EvaluateAlias(nameof(TaxAmount))); }
        }

        //[PersistentAlias("(Product.Price)*(UnitSetDetail.Quantity)*(Quantity)")]
        //[ImmediatePostData]
        //public decimal UnitPrice
        //{
        //    get { return Convert.ToDecimal(EvaluateAlias(nameof(UnitPrice))); } //Açıklaması bakılacak. 
        //    //Sadece get olduğu için okunabilir olur. Set kaldırılmasının nedeni ,yazılabilir bir veri istemediğimizdendir.
        //}
        private decimal _UnitPrice;
        [Persistent("Birim Fiyat")]
        //[ImmediatePostData]
        [RuleValueComparison("PurchaseInvoice.UnitPrice.GreaterThanZero", DefaultContexts.Save, ValueComparisonType.GreaterThanOrEqual, 1)]
        public decimal UnitPrice
        {
            get { return _UnitPrice; }
            set
            {
                if (SetPropertyValue<decimal>(nameof(UnitPrice), ref _UnitPrice, value))
                {
                    if (!IsLoading && !IsSaving && !IsDeleted)
                    {
                        PurchaseInvoice.TotalAmount = (Amount);
                    }
                }
            }
        }

        [PersistentAlias("iif((Quantity) = 0, 0, (DiscountedPrice)/(UnitSetDetail.Quantity)/(Quantity))")] //0'a bölme işlemlerinde hata almamak için kullanıyoruz.
        //[PersistentAlias("iif(Quantity == 0)(UnitCost = 0) (DiscountedPrice)/(UnitSetDetail.Quantity)/(Quantity)")]
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
        [Persistent("İndirim Oranı")]
        //[ImmediatePostData]
        public int Discount
        {
            get { return _Discount; }
            set
            {
                if (SetPropertyValue<int>(nameof(Discount), ref _Discount, value))
                {
                    if (!IsLoading && !IsSaving && !IsDeleted)
                    {
                        PurchaseInvoice.TotalAmount = (Amount);
                    }
                }
            }
        }

        //[PersistentAlias("(UnitPrice)*(100-Discount)/100")]
        //[RuleRequiredField("RuleRequiredField for PurchaseInvoiceItem.DiscountedPrice", DefaultContexts.Save)]
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

        private decimal _DiscountAmount;
        [ImmediatePostData]
        [Persistent("İndirim Tutarı")]
        [RuleRequiredField("RuleRequiredField for PurchaseInvoiceItem.DiscountAmount", DefaultContexts.Save)]
        public decimal DiscountAmount
        {
            get { return _DiscountAmount = UnitPrice - DiscountedPrice; }
        }

        private Tax _Tax;
        [RuleRequiredField("RuleRequiredField for PurchaseInvoiceItem.Tax", DefaultContexts.Save)]
        [Association("Tax-PurchaseInvoiceItems")]
        public Tax Tax
        {
            get { return _Tax; }
            set
            {
                if (SetPropertyValue<Tax>(nameof(Tax), ref _Tax, value))
                {
                    if (!IsLoading && !IsSaving && !IsDeleted)
                    {
                        PurchaseInvoice.TotalAmount = (Amount);
                    }
                }
            }
        }
    }
}