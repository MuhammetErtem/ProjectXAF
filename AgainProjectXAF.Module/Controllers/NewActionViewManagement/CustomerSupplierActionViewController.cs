using AgainProjectXAF.Module.BusinessObjects.PurchaseManagement;
using AgainProjectXAF.Module.BusinessObjects.SalesManagement;
using AgainProjectXAF.Module.BusinessObjects.StockManagement;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.SystemModule;
using System;
using System.Collections.Generic;

namespace AgainProjectXAF.Module.Controllers.NewActionViewManagement
{
    public partial class CustomerSupplierActionViewController : ObjectViewController<ObjectView, CustomerSupplier>
    {
        protected override void OnActivated()
        {
            base.OnActivated();
            NewObjectViewController controller = Frame.GetController<NewObjectViewController>();
            if (controller != null)
            {
                controller.CollectCreatableItemTypes += NewObjectViewController_CollectCreatableItemTypes;
                controller.CollectDescendantTypes += NewObjectViewController_CollectDescendantTypes;
                if (controller.Active)
                {
                    controller.UpdateNewObjectAction();
                }
            }
        }
        private void NewObjectViewController_CollectDescendantTypes(object sender, CollectTypesEventArgs e)
        {
            CustomizeList(e.Types);
        }
        private void NewObjectViewController_CollectCreatableItemTypes(object sender, CollectTypesEventArgs e)
        {
            CustomizeList(e.Types);
        }
        private void CustomizeList(ICollection<Type> types)
        {
            List<Type> unusableTypes = new List<Type>();
            foreach (Type item in types)
            {
                if (item == typeof(Brand))
                {
                    unusableTypes.Add(item);
                }
                if (item == typeof(UnitSet))
                {
                    unusableTypes.Add(item);
                }
                if (item == typeof(Product))
                {
                    unusableTypes.Add(item);
                }
                if (item == typeof(PurchaseInvoice))
                {
                    unusableTypes.Add(item);
                }
                if (item == typeof(SalesInvoice))
                {
                    unusableTypes.Add(item);
                }
            }
            foreach (Type item in unusableTypes)
            {
                types.Remove(item);
            }
        }
        protected override void OnDeactivated()
        {
            NewObjectViewController controller = Frame.GetController<NewObjectViewController>();
            if (controller != null)
            {
                controller.CollectCreatableItemTypes -= NewObjectViewController_CollectCreatableItemTypes;
                controller.CollectDescendantTypes -= NewObjectViewController_CollectDescendantTypes;
            }
            base.OnDeactivated();
        }
    }
}