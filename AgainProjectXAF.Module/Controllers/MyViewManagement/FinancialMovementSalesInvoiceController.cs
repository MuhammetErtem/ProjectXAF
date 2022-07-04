using AgainProjectXAF.Module.BusinessObjects.PurchaseManagament;
using AgainProjectXAF.Module.BusinessObjects.SalesManagement;
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
            SalesInvoice salesInvoice = View.CurrentObject as SalesInvoice;
            FinancialMovement financialMovement = objectSpace.CreateObject<FinancialMovement>();

            financialMovement.Date = salesInvoice.Date;
            financialMovement.CustomerSupplier = salesInvoice.CustomerSupplier;
            financialMovement.SalesInvoiceAmount = salesInvoice.TotalAmount;
            financialMovement.SalesInvoice = salesInvoice;
            financialMovement.DocumentID = salesInvoice.DocumentId;
            financialMovement.Invoice = salesInvoice.ClassInfo.TableName;

        }
        protected override void OnDeactivated()
        {
            View.ObjectSpace.Committing -= ObjectSpace_Committing;
        }
    }
}