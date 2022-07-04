using AgainProjectXAF.Module.BusinessObjects.PurchaseManagament;
using DevExpress.ExpressApp;
using DevExpress.Xpo;
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
            FinancialMovement financialMovement = objectSpace.CreateObject<FinancialMovement>();

            financialMovement.Date = purchaseInvoice.Date;
            financialMovement.CustomerSupplier = purchaseInvoice.CustomerSupplier;
            financialMovement.PurchaseInvoiceAmount = purchaseInvoice.TotalAmount;
            financialMovement.PurchaseInvoice = purchaseInvoice;
            financialMovement.DocumentID = purchaseInvoice.DocumentId;
            financialMovement.Invoice = purchaseInvoice.ClassInfo.ClassType.Name;
        }
        protected override void OnDeactivated()
        {
            View.ObjectSpace.Committing -= ObjectSpace_Committing;
        }
    }
}
