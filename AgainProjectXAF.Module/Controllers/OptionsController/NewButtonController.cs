﻿using DevExpress.ExpressApp;
using DevExpress.ExpressApp.SystemModule;

namespace AgainProjectXAF.Module.Controllers.OptionsController
{
    public partial class NewButtonController : ObjectViewController
    {
        public NewButtonController()
        {
            InitializeComponent();
            RegisterActions(components); //İşlemleri kaydediyor. ? Bakılacak tam anlayamadım.
        }

        protected override void OnActivated()
        {
            base.OnActivated();

            if (View.Id == "PurchaseInvoice_PurchaseInvoiceItems_ListView"
                || View.Id == "Brand_Products_ListView"
                || View.Id == "UnitSet_UnitSetDetails_ListView"
                || View.Id == "Product_PurchaseInvoiceItems_ListView"
                || View.Id == "UnitSetDetail_PurchaseInvoiceItems_ListView"
                || View.Id == "UnitSet_Products_ListView"
                || View.Id == "CustomerSupplier_PurchaseInvoices_ListView"
                || View.Id == "SalesInvoice_SalesInvoiceItems_ListView"
                || View.Id == "CustomerSupplier_Invoices_ListView"
                || View.Id == "CustomerSupplier_FinancialMovements_ListView"
                || View.Id == "Invoice_FinancialMovements_ListView"
                || View.Id == "Product_SalesInvoiceItems_ListView"
                || View.Id == "Tax_SalesInvoiceItems_ListView"
                || View.Id == "Tax_PurchaseInvoiceItems_ListView")
            {
                DevExpress.ExpressApp.Win.SystemModule.WinNewObjectViewController winNewObjectViewController = Frame.GetController<DevExpress.ExpressApp.Win.SystemModule.WinNewObjectViewController>();
                // Frame = çerçeve , Nested = İç içe 
                if (winNewObjectViewController != null)
                {
                    //Frame.GetController<DeleteObjectsViewController>().DeleteAction.Active["NestedListView"] = false;
                    //Frame.GetController<LinkUnlinkController>().LinkAction.Active["NestedListView"] = false;
                    //Frame.GetController<LinkUnlinkController>().UnlinkAction.Active["NestedListView"] = false;
                    winNewObjectViewController.NewObjectAction.Active.SetItemValue("New", false);
                    //SetItemValue = Öğe değerini ayarlamamızı istiyor. ( Kendisi parametre istiyor onları veriyoruz ) 
                    //NewObjectAction = ID , Active öğesini bizim istediğimiz değeri atıyoruz üstte

                }
            }
        }

        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
        }
        protected override void OnDeactivated()
        {
            base.OnDeactivated();
        }
    }
}
