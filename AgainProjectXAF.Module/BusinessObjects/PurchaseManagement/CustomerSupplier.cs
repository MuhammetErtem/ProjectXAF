﻿using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace AgainProjectXAF.Module.BusinessObjects.PuchaseManagament
{
    [DefaultClassOptions]
    [ImageName("BO_Customer")]
    public class CustomerSupplier : BaseObject
    { 
        public CustomerSupplier(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            if (!(Session is NestedUnitOfWork) && (Session.DataLayer != null) && Session.IsNewObject(this) && string.IsNullOrEmpty(Code))
            {
                int code = DistributedIdGeneratorHelper.Generate(Session.DataLayer, this.GetType().FullName, "CustomerSupplierServerPrefix");
                Code = string.Format("Kod-{0:D10}", code);
            }
            IsApproved = true;  //Varsayılan olarak true gelecek diye ayarlamış olduk.
        }

        private string _Code;
        [RuleRequiredField("RuleRequiredField for CustomerSupplier.Code", DefaultContexts.Save)]
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

        [Size(120)]
        private string _Name;
        [RuleRequiredField("RuleRequiredField for CustomerSupplier.Name", DefaultContexts.Save )]
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

        private bool _IsApproved;
        [RuleRequiredField("RuleRequiredField for CustomerSupplier.IsApproved", DefaultContexts.Save )]
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
        [VisibleInListView(false)]
        [VisibleInDetailView(false)]
        [PersistentAlias("Concat(Name + ' ' + Code)")]
        public string CustomerSupplierNameAndCode
        {
            get { return Convert.ToString(EvaluateAlias("CustomerSupplierNameAndCode")); }
        }

        /// <summary>
        ///                 COLLECTİON
        /// </summary>
        [Association("CustomerSupplier-PurchaseInvoices"), DevExpress.ExpressApp.DC.Aggregated]
        public XPCollection<PurchaseInvoice> PurchaseInvoices
        {
            get { return GetCollection<PurchaseInvoice>("PurchaseInvoices"); }
        }

        /// <summary>
        ///                 COLLECTİON
        /// </summary>
        [Association("CustomerSupplier-SalesInvoices"), DevExpress.ExpressApp.DC.Aggregated]
        public XPCollection<SalesInvoice> SalesInvoices
        {
            get { return GetCollection<SalesInvoice>("SalesInvoices"); }
        }

        [Association("CustomerSupplier-FinancialMovements"), DevExpress.ExpressApp.DC.Aggregated]
        public XPCollection<FinancialMovement> FinancialMovements
        {
            get { return GetCollection<FinancialMovement>("FinancialMovements"); }
        }

    }
}