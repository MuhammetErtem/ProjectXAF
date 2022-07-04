using AgainProjectXAF.Module.BusinessObjects.PurchaseManagament;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.Persistent.Base;
using System;

namespace AgainProjectXAF.Module.Controllers.OptionsController
{
    public partial class FinancialMovementController : ViewController
    {
        public FinancialMovementController()
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

        //private void simpleAction1_Execute(object sender, SimpleActionExecuteEventArgs e)
        //{
        //    IObjectSpace objectSpace = View.ObjectSpace;
        //    CustomerSupplier customerSupplier = View.CurrentObject as CustomerSupplier;
        //    var id = customerSupplier.Oid;

        //    PopupWindowShowAction showDetailViewAction = new PopupWindowShowAction(this, "CustomerSupplier", PredefinedCategory.Edit);
        //    showDetailViewAction.SelectionDependencyType = SelectionDependencyType.RequireSingleObject;
        //    showDetailViewAction.TargetObjectsCriteria = "FinancialMovement.CustomerSupplier.Oid == id";




        //    ////    showDetailViewAction.CustomizePopupWindowParams += showDetailViewAction_CustomizePopupWindowParams;
        //    ////}
        //    ////void showDetailViewAction_CustomizePopupWindowParams(object sender, CustomizePopupWindowParamsEventArgs e)
        //    ////{
        //    ////    IObjectSpace newObjectSpace = Application.CreateObjectSpace(View.ObjectTypeInfo.Type);
        //    ////    Object objectToShow = newObjectSpace.GetObject(View.CurrentObject);
        //    ////    if (objectToShow != null)
        //    ////    {
        //    ////        DetailView createdView = Application.CreateDetailView(newObjectSpace, objectToShow);
        //    ////        createdView.ViewEditMode = ViewEditMode.Edit;
        //    ////        e.View = createdView;
        //    ////    }
        //    ////}
        //    //e.ShowViewParameters.CreatedView = xpView;
        //}

        private void popupWindowShowAction1_Execute(object sender, CustomizePopupWindowParamsEventArgs e)
        {
            //IObjectSpace objectSpace = Application.CreateObjectSpace(typeof(FinancialMovement));
            //e.ShowViewParameters.CreatedView = Application.CreateListView(objectSpace, typeof(FinancialMovement), true);
            //IObjectSpace objectSpace = View.ObjectSpace;
            //CustomerSupplier customerSupplier = View.CurrentObject as CustomerSupplier;
            //var id = customerSupplier.Oid;

            //IObjectSpace objectSpaceCreate = Application.CreateObjectSpace();
            //CollectionSourceBase cb = Application.CreateCollectionSource(objectSpaceCreate, typeof(FinancialMovement), "FinancialMovement_ListView");
            //ListView list = Application.CreateListView("FinancialMovement_ListView", cb, true);
            //e.View = list;

            IObjectSpace objectSpaceCreate = Application.CreateObjectSpace();
            e.View = Application.CreateDetailView(objectSpaceCreate, "CustomerSupplier_DetailView_FinMovs",
                true, View.CurrentObject);
        }
    }
}
