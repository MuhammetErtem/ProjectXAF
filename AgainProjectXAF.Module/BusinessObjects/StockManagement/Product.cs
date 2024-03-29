﻿using AgainProjectXAF.Module.BusinessObjects.PurchaseManagement;
using AgainProjectXAF.Module.BusinessObjects.RegulationManagement;
using AgainProjectXAF.Module.BusinessObjects.SalesManagement;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System.Collections.Generic;

namespace AgainProjectXAF.Module.BusinessObjects.StockManagement
{
    [DefaultClassOptions]
    [ImageName("BO_Product_Group")]
    public class Product : BaseObject
    { 
        public Product(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();

            //Bu kalıp araştırılacak ne olduğu tam anlamıyla öğrenilecek.
            if (!(Session is NestedUnitOfWork) && (Session.DataLayer != null) && Session.IsNewObject(this) && string.IsNullOrEmpty(Code))
            {
                int code = DistributedIdGeneratorHelper.Generate(Session.DataLayer, this.GetType().FullName, "ProductServerPrefix");
                Code = string.Format("Kod-{0:D10}", code);
            }

            IsApproved = true; // Varsayılan olarak true getirdik.
        }

        protected override void OnDeleting()
        {
            
            base.OnDeleting();
            //foreach (var item in this.PurchaseInvoiceItems)
            //{
            //    if (this.Oid == item.Product.Oid)
            //    {
            //        MessageOptions msg = new MessageOptions();
            //        msg.Duration = 3000;
            //        msg.Type = InformationType.Error;
            //        msg.Message = "Bu Malzemeye Ait Fatura Bulunmuştur! ";
            //        throw new UserFriendlyException("Bu Malzemeye Ait Fatura Bulunmuştur!");

            //    }
            //}

        }

        private string _Code;
        [RuleRequiredField("RuleRequiredField for Product.Code", DefaultContexts.Save)]
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

        //, Index(0), VisibleInListView(false)]

        [Size(80)] //Karakter uzunluğuna sınırlama getirdik.
        private string _Name;
        [RuleRequiredField("RuleRequiredField for Product.Name", DefaultContexts.Save)]
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

        private decimal _Price;
        [RuleRequiredField("RuleRequiredField for Product.Price", DefaultContexts.Save)]
        /// <summary>
        ///
        /// </summary>
        public decimal Price
        {
            get { return _Price; }
            set
            {
                if (SetPropertyValue<decimal>(nameof(Price), ref _Price, value))
                {
                    if (!IsLoading && !IsSaving)
                    {

                    }
                }
            }
        }

        //private decimal _TaxRate;
        //[RuleRequiredField("RuleRequiredField for Product.TaxRate", DefaultContexts.Save)]
        ///// <summary>
        /////
        ///// </summary>
        //public decimal TaxRate
        //{
        //    get { return _TaxRate; }
        //    set
        //    {
        //        if (SetPropertyValue<decimal>(nameof(TaxRate), ref _TaxRate, value))
        //        {
        //            if (!IsLoading && !IsSaving)
        //            {

        //            }
        //        }
        //    }
        //}

        private bool _IsApproved;
        [RuleRequiredField("RuleRequiredField for Product.IsApproved", DefaultContexts.Save)]
        /// <summary>
        ///
        /// </summary>
        public bool IsApproved
        {
            get { return _IsApproved; }
            set
            {
                if (SetPropertyValue<bool>(nameof(IsApproved), ref _IsApproved, value))
                {
                    if (!IsLoading && !IsSaving)
                    {

                    }
                }
            }
        }
        [Delayed(true)] //Gecikmeli yüklemedir. Uygulamanız ve veritabanı sunucusu arasında aktarılan veri miktarını azaltmak için kullanılır.
        [ImageEditor(DetailViewImageEditorMode = ImageEditorMode.PictureEdit, DetailViewImageEditorFixedWidth = 300)]
        public byte[] Image
        {
            get { return GetDelayedPropertyValue<byte[]>(nameof(Image)); }
            set { SetDelayedPropertyValue<byte[]>(nameof(Image), value); }
        }


        private UnitSet _UnitSet;
        [RuleRequiredField("RuleRequiredField for Product.UnitSet", DefaultContexts.Save)]
        [Association("UnitSet-Products")]
        //[VisibleInListView(false)] //Listede görünmemesini istiyorsak bunu kullanıyoruz.
        /// <summary>
        ///                     REFERANS
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

                    }
                }
            }
        }

        /// <summary>
        ///             COLLECTİON
        /// </summary>
        [Association("Product-PurchaseInvoiceItems")]
        [Aggregated]
        public XPCollection<PurchaseInvoiceItem> PurchaseInvoiceItems
        {
            get { return GetCollection<PurchaseInvoiceItem>(nameof(PurchaseInvoiceItems)); }

        }

        /// <summary>
        ///             COLLECTİON
        /// </summary>
        [Association("Product-SalesInvoiceItems")]
        [Aggregated]
        public XPCollection<SalesInvoiceItem> SalesInvoiceItems
        {
            get { return GetCollection<SalesInvoiceItem>(nameof(SalesInvoiceItems)); }

        }

        private Brand _Brand;
        [Association("Brand-Products")] //Association = Bağlantılı
        public Brand Brand
        {
            get { return _Brand; }
            set
            {
                if (SetPropertyValue<Brand>(nameof(Brand), ref _Brand, value))
                {
                    if (!IsLoading && !IsSaving)
                    {

                    }
                }
            }
        }

        private Tax _Tax;
        [RuleRequiredField("RuleRequiredField for Product.Tax", DefaultContexts.Save)]
        [Association("Tax-Products")]
        /// <summary>
        ///             REFERANS
        /// </summary>
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