
namespace AgainProjectXAF.Module.Controllers.OptionsController
{
    partial class FinancialMovement
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
            DevExpress.ExpressApp.Actions.SimpleAction simpleAction1;
            simpleAction1 = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            // 
            // simpleAction1
            // 
            simpleAction1.Caption = "Finansal Hareketler";
            simpleAction1.ConfirmationMessage = null;
            simpleAction1.Id = "simpleAction1";
            simpleAction1.ImageName = "EnableSearch";
            simpleAction1.PaintStyle = DevExpress.ExpressApp.Templates.ActionItemPaintStyle.CaptionAndImage;
            simpleAction1.TargetViewId = "CustomerSupplier_ListView";
            simpleAction1.ToolTip = null;
            simpleAction1.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.simpleAction1_Execute);
            // 
            // FinancialMovement
            // 
            this.Actions.Add(simpleAction1);

        }

        #endregion
    }
}
