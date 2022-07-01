using AgainProjectXAF.Module.BusinessObjects.PuchaseManagament;
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
            PurchaseInvoice purchase = View.CurrentObject as PurchaseInvoice; 
            FinancialMovement fm = objectSpace.CreateObject<FinancialMovement>();

            fm.Date = purchase.Date;
            fm.CustomerSupplier = purchase.CustomerSupplier;
            fm.PurchaseInvoiceAmount = purchase.TotalAmount;
            fm.PurchaseInvoice = purchase;
            fm.PurchaseInvoiceDocumentID = purchase.DocumentId;
            
        }
        protected override void OnDeactivated()
        {
            View.ObjectSpace.Committing -= ObjectSpace_Committing;
        }
    }
}
