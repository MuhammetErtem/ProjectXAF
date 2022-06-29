using DevExpress.ExpressApp;
using DevExpress.ExpressApp.SystemModule;

namespace AgainProjectXAF.Module.Controllers.OptionsController
{
    public partial class CtrlViewNested : ViewController<ListView>
    {
        public CtrlViewNested()

        {
            InitializeComponent();
            RegisterActions(components); //İşelmleri kayıt ediyor.
            TargetViewType = ViewType.Any;
            TargetViewNesting = Nesting.Nested;
        }



        protected override void OnActivated()
        {
            base.OnActivated();
            if (View is ListView)
            {
                Frame.GetController<ListViewProcessCurrentObjectController>().CustomProcessSelectedItem += CtrlVirtualViewNested_CustomProcessSelectedItem;

                //if (View.Id.StartsWith("Virtual")) 
                //{
                //    Frame.GetController<ListViewProcessCurrentObjectController>().CustomProcessSelectedItem += CtrlVirtualViewNested_CustomProcessSelectedItem;
                //}
            }
        }

        private void CtrlVirtualViewNested_CustomProcessSelectedItem(object sender, CustomProcessListViewSelectedItemEventArgs e)
        {
            e.Handled = true;
        }

        protected override void OnDeactivated()
        {
            base.OnDeactivated();
            if (View is ListView)
            {
                Frame.GetController<ListViewProcessCurrentObjectController>().CustomProcessSelectedItem += CtrlVirtualViewNested_CustomProcessSelectedItem;

                //if (View.Id.StartsWith("Virtual"))
                //{
                //    Frame.GetController<ListViewProcessCurrentObjectController>().CustomProcessSelectedItem -= CtrlVirtualViewNested_CustomProcessSelectedItem;
                //}
            }
        }
    }
}
