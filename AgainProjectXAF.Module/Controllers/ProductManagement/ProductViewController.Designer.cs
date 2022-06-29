
namespace AgainProjectXAF.Module.Controllers.ProductManagement
{
    partial class ProductViewController
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.ExpressApp.Actions.ChoiceActionItem choiceActionItem3 = new DevExpress.ExpressApp.Actions.ChoiceActionItem();
            DevExpress.ExpressApp.Actions.ChoiceActionItem choiceActionItem4 = new DevExpress.ExpressApp.Actions.ChoiceActionItem();
            this.ActionBrand = new DevExpress.ExpressApp.Actions.SingleChoiceAction(this.components);
            // 
            // ActionBrand
            // 
            this.ActionBrand.Caption = "Marka İşlemleri";
            this.ActionBrand.ConfirmationMessage = null;
            this.ActionBrand.Id = "ActionBrand";
            this.ActionBrand.ImageName = "BO_Audit_ChangeHistory";
            choiceActionItem3.Caption = "Marka Tanımla";
            choiceActionItem3.Id = "MarkaT";
            choiceActionItem3.ImageName = null;
            choiceActionItem3.Shortcut = null;
            choiceActionItem3.ToolTip = null;
            choiceActionItem4.Caption = "Marka Sil";
            choiceActionItem4.Id = "MarkaS";
            choiceActionItem4.ImageName = null;
            choiceActionItem4.Shortcut = null;
            choiceActionItem4.ToolTip = null;
            this.ActionBrand.Items.Add(choiceActionItem3);
            this.ActionBrand.Items.Add(choiceActionItem4);
            this.ActionBrand.ItemType = DevExpress.ExpressApp.Actions.SingleChoiceActionItemType.ItemIsOperation;
            this.ActionBrand.PaintStyle = DevExpress.ExpressApp.Templates.ActionItemPaintStyle.CaptionAndImage;
            this.ActionBrand.QuickAccess = true;
            this.ActionBrand.SelectionDependencyType = DevExpress.ExpressApp.Actions.SelectionDependencyType.RequireMultipleObjects;
            this.ActionBrand.ShowItemsOnClick = true;
            this.ActionBrand.TargetObjectsCriteria = "";
            this.ActionBrand.TargetObjectsCriteriaMode = DevExpress.ExpressApp.Actions.TargetObjectsCriteriaMode.TrueForAll;
            this.ActionBrand.ToolTip = null;
            this.ActionBrand.Execute += new DevExpress.ExpressApp.Actions.SingleChoiceActionExecuteEventHandler(this.ActionBrand_Execute);
            // 
            // ProductViewController
            // 
            this.Actions.Add(this.ActionBrand);
            this.TargetViewId = "Product_ListView;Product_DetailView";

        }

        #endregion

        private DevExpress.ExpressApp.Actions.SingleChoiceAction ActionBrand;
    }
}
