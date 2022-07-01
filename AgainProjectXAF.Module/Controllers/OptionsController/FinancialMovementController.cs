using AgainProjectXAF.Module.BusinessObjects.PuchaseManagament;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.Persistent.Base;
using System;

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
            var id = customerSupplier.Oid;

            PopupWindowShowAction showDetailViewAction = new PopupWindowShowAction(this, "CustomerSupplier", PredefinedCategory.Edit);
            showDetailViewAction.SelectionDependencyType = SelectionDependencyType.RequireSingleObject;
            showDetailViewAction.TargetObjectsCriteria = "FinancialMovement.CustomerSupplier.Oid == id";
            ////    showDetailViewAction.CustomizePopupWindowParams += showDetailViewAction_CustomizePopupWindowParams;
            ////}
            ////void showDetailViewAction_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
            ////{
            ////    IObjectSpace newObjectSpace = Application.CreateObjectSpace(View.ObjectTypeInfo.Type);
            ////    Object objectToShow = newObjectSpace.GetObject(View.CurrentObject);
            ////    if (objectToShow != null)
            ////    {
            ////        DetailView createdView = Application.CreateDetailView(newObjectSpace, objectToShow);
            ////        createdView.ViewEditMode = ViewEditMode.Edit;
            ////        e.View = createdView;
            ////    }
            ////}
            //e.ShowViewParameters.CreatedView = xpView;
        }

        private void popupWindowShowAction1_Execute(object sender, CustomizePopupWindowParamsEventArgs e)
        {
            //IObjectSpace objectSpace = Application.CreateObjectSpace(typeof(FinancialMovement));
            //e.ShowViewParameters.CreatedView = Application.CreateListView(objectSpace, typeof(FinancialMovement), true);

            IObjectSpace objectSpace = Application.CreateObjectSpace();
            e.View = Application.CreateListView(Application.FindListViewId(typeof(PurchaseInvoice)),
                new CollectionSource(objectSpace, typeof(PurchaseInvoice)), true);
        }
    }
}
