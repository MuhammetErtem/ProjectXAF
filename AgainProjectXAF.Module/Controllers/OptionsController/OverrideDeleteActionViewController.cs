using AgainProjectXAF.Module.BusinessObjects.PurchaseManagement;
using AgainProjectXAF.Module.BusinessObjects.StockManagement;
using DevExpress.ExpressApp;
using System;
using System.Collections.Generic;

namespace AgainProjectXAF.Module.Controllers.OptionsController
{
    public partial class OverrideDeleteActionViewController : ViewController
    {
        public OverrideDeleteActionViewController()
        {
            TargetViewId = "Product_ListView";
            InitializeComponent();
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            ObjectSpace.CustomDeleteObjects += new EventHandler<CustomDeleteObjectsEventArgs>(ObjectSpace_CustomDeleteObjects);
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
        }
        void ObjectSpace_CustomDeleteObjects(object sender, CustomDeleteObjectsEventArgs e)
        {
            IObjectSpace objectSpace = View.ObjectSpace;
            IList<PurchaseInvoiceItem> purchaseInvoiceItems = objectSpace.GetObjects<PurchaseInvoiceItem>();
            Product currentProduct = View.CurrentObject as Product;

            if (currentProduct.Oid != null)
            {
                string a = "Bu Malzemeye Ait Satın Alma Fatura Satırları Bulunmuştur!  ";

                foreach (var item in purchaseInvoiceItems)
                {
                    if (currentProduct.Oid == item.Product.Oid)
                    {
                        string b = item.PurchaseInvoice.DocumentId;
                        a += Environment.NewLine +b;
                    }

                    //MessageOptions msg = new MessageOptions();
                    //msg.Duration = 3000;
                    //msg.Type = InformationType.Error;
                    //msg.Message = item.PurchaseInvoice.DocumentId;
                    //Application.ShowViewStrategy.ShowMessage(msg);
                }
                foreach (var item in purchaseInvoiceItems)
                {
                    if (currentProduct.Oid == item.Product.Oid)
                    {
                        throw new UserFriendlyException(a);
                    }
                }
                //objectSpace.CommitChanges(); // kayıt yapıyor
                //objectSpace.Refresh();//objectSpace.Refresh(); yeniliyor. Büyük o bütün uygulamadaki sayfaları - küçük o o sayfayı.
            }
        }
        protected override void OnDeactivated()
        {
            ObjectSpace.CustomDeleteObjects -= new EventHandler<CustomDeleteObjectsEventArgs>(ObjectSpace_CustomDeleteObjects);
            base.OnDeactivated();
        }
    }
}