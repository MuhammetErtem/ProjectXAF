using DevExpress.ExpressApp;
using DevExpress.ExpressApp.SystemModule;

namespace AgainProjectXAF.Module.Controllers.OptionsController
{
    public partial class MyNewItemRowListController : NewItemRowListViewController
    {
        protected override NewItemRowPosition CalculateNewItemRowPosition() // Calculate = Hesaplamak
        {
            NewItemRowPosition result = NewItemRowPosition.None; //None = Yok
            if (View.Model != null && View.AllowEdit && View.AllowNew)
            {
                result = ((IModelListViewNewItemRow)View.Model).NewItemRowPosition; // ??
            }
            return result;
        }
    }
}
