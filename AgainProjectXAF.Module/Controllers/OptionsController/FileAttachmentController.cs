using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;

namespace AgainProjectXAF.Module.Controllers.OptionsController
{
    public partial class FileAttachmentController : ViewController
    {
        public FileAttachmentController()
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

        //private void popupWindowShowAction1_Execute(object sender, CustomizePopupWindowParamsEventArgs e)
        //{
        //    IObjectSpace objectSpaceCreate = Application.CreateObjectSpace();
        //    e.View = Application.CreateDetailView(objectSpaceCreate, "CustomerSupplier_DetailView_File",true, View.CurrentObject);
        //}

        private void simpleAction1_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            IObjectSpace objectSpaceCreate = Application.CreateObjectSpace();
            e.ShowViewParameters.CreatedView = Application.CreateDetailView(objectSpaceCreate, "CustomerSupplier_DetailView_File", true, View.CurrentObject);
        }
    }
}
