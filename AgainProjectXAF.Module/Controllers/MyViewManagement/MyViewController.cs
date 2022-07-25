using AgainProjectXAF.Module.BusinessObjects.PurchaseManagement;
using DevExpress.ExpressApp;
using System.Collections.Generic;
using System.ComponentModel;

namespace AgainProjectXAF.Module.Controllers.MyViewManagement
{
    public partial class MyViewController : ObjectViewController<DetailView, PurchaseInvoice> //Nerede çalışsın ?
    {
        protected override void OnActivated()
        {
            base.OnActivated();
            View.ObjectSpace.Committing += ObjectSpace_Committing; // Committing edince bunu çalıştır.
        }
        private void ObjectSpace_Committing(object sender, CancelEventArgs e)
        {
            IObjectSpace objectSpace = View.ObjectSpace;
            PurchaseInvoice purchaseInvoice = View.CurrentObject as PurchaseInvoice;
            bool financialX = false;

            IList<FinancialMovement> financial = objectSpace.GetObjects<FinancialMovement>();
            foreach (var item in financial)
            {
                if (purchaseInvoice.Oid == item.Invoice.Oid)
                {
                    financialX = true;
                    item.Date = purchaseInvoice.Date;
                    item.CustomerSupplier = purchaseInvoice.CustomerSupplier;
                    item.Credit = purchaseInvoice.TotalAmount;
                    item.Invoice = purchaseInvoice;
                }
            }

            if (financialX == false)
            {
                FinancialMovement financialMovement = objectSpace.CreateObject<FinancialMovement>();

                financialMovement.Date = purchaseInvoice.Date;
                financialMovement.CustomerSupplier = purchaseInvoice.CustomerSupplier;
                financialMovement.Debt = purchaseInvoice.TotalAmount;
                financialMovement.Invoice = purchaseInvoice;

            }
        }
        protected override void OnDeactivated()
        {
            View.ObjectSpace.Committing -= ObjectSpace_Committing;
        }
    }
}
