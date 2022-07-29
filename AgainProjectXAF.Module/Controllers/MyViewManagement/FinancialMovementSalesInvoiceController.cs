using AgainProjectXAF.Module.BusinessObjects.PurchaseManagement;
using AgainProjectXAF.Module.BusinessObjects.SalesManagement;
using DevExpress.ExpressApp;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

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
            bool financialX = false; //boolen bir alan belirleyip false verdim.

            IList<FinancialMovement> financial = objectSpace.GetObjects<FinancialMovement>();
            foreach (var item in financial)
            {
                if (salesInvoice.Oid == item.Invoice.Oid)
                {
                    financialX = true; // burada alan true ya çevirdim.
                    item.Date = salesInvoice.Date;
                    item.CustomerSupplier = salesInvoice.CustomerSupplier;
                    item.Credit = salesInvoice.TotalAmount;
                    item.Invoice = salesInvoice;
                }
            }

            if (financialX == false) // true olmadığı için buraya girmedi.
            {
                FinancialMovement financialMovement = objectSpace.CreateObject<FinancialMovement>();

                financialMovement.Date = salesInvoice.Date;
                financialMovement.CustomerSupplier = salesInvoice.CustomerSupplier;
                financialMovement.Credit = salesInvoice.TotalAmount;
                financialMovement.Invoice = salesInvoice;
            }
        }
        protected override void OnDeactivated()
        {
            View.ObjectSpace.Committing -= ObjectSpace_Committing;
        }
    }
}