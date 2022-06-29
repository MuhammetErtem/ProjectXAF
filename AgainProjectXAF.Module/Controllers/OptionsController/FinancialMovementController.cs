using AgainProjectXAF.Module.BusinessObjects.PuchaseManagament;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;

namespace AgainProjectXAF.Module.Controllers.OptionsController
{
    public partial class FinancialMovement : ViewController
    {
        public FinancialMovement()
        {
            InitializeComponent();
        }
        protected override void OnActivated()
        {
            base.OnActivated();
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
        }
        protected override void OnDeactivated()
        {
            base.OnDeactivated();
        }

        private void simpleAction1_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            IObjectSpace objectSpace = View.ObjectSpace;
            CustomerSupplier customerSupplier = View.CurrentObject as CustomerSupplier;
            var ıd = customerSupplier.Oid;

            IObjectSpace objectSpace1 = Application.CreateObjectSpace(typeof(PurchaseInvoice));
            e.ShowViewParameters.CreatedView = Application.CreateListView(objectSpace1, typeof(PurchaseInvoice), true);

        }
    }
}
