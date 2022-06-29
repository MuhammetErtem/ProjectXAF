using AgainProjectXAF.Module.BusinessObjects.StockManagement;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgainProjectXAF.Module.Controllers.ProductManagement
{
    public partial class ProductViewController : ViewController
    {
        public ProductViewController()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }

        private void ActionBrand_Execute(object sender, SingleChoiceActionExecuteEventArgs e)
        {
            IObjectSpace objectSpace = View.ObjectSpace; //DataBaseden veriyi çekiyoruz.
            IList<Brand> brnd = objectSpace.GetObjects<Brand>(); //Brand listesini alıyoruz
            int number = brnd.Count; //Count unu alıyoruz
            Random rand = new Random(); //Random işlemi tanımlıyoruz.
            int random = rand.Next(0, number); //Sıfır dahil ve number dahil olmayacak şekilde alır. Bunu öğrenmek için InfoBox(Next) ten kontrol edebiliriz.
            Brand result = brnd[random]; //random brand alıyoruz.
            Product currentProduct = View.CurrentObject as Product; //currentProduct ı product olarak tanımlıyoruz.

            if (View is ListView && View.SelectedObjects.Count > 0 && View.SelectedObjects != null) //Filtre uyguluyoruz. 
            {
                switch (e.SelectedChoiceActionItem.Id) // SelectedChoiceActionItem seçtiğim tuş 
                {
                    case "MarkaT":
                        currentProduct.Brand = result;
                        break;
                    case "MarkaS":
                        currentProduct.Brand = null;
                        break;

                    default:
                        break;
                }
            }
            objectSpace.CommitChanges(); //DataBase e veriyi kaydediyoruz.
        }
    }
}
