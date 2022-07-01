using AgainProjectXAF.Module.BusinessObjects.PuchaseManagament;
using DevExpress.ExpressApp;
using System.ComponentModel;

namespace AgainProjectXAF.Module.Controllers.MyViewManagement
{
    public partial class FinancialMovementSalesInvoiceController : ObjectViewController<DetailView, SalesInvoice>
    {
        protected override void OnActivated()
        {
            base.OnActivated();
            View.ObjectSpace.Committing += ObjectSpace_Committing;
        }
        private void ObjectSpace_Committing(object sender, CancelEventArgs e)
        {
            IObjectSpace objectSpace = View.ObjectSpace;
            SalesInvoice sales = View.CurrentObject as SalesInvoice;
            FinancialMovement fm = objectSpace.CreateObject<FinancialMovement>();

            fm.Date = sales.Date;
            fm.CustomerSupplier = sales.CustomerSupplier;
            fm.SalesInvoiceAmount = sales.TotalAmount;
            fm.SalesInvoice = sales;
            fm.SalesInvoiceDocumentID = sales.DocumentId;

        }
        protected override void OnDeactivated()
        {
            View.ObjectSpace.Committing -= ObjectSpace_Committing;
        }
    }
}