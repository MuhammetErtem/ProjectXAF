
namespace AgainProjectXAF.Module.Controllers.OptionsController
{
    partial class FileAttachmentController
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
            this.simpleAction1 = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            // 
            // simpleAction1
            // 
            this.simpleAction1.Caption = "FileAttachment";
            this.simpleAction1.ConfirmationMessage = null;
            this.simpleAction1.Id = "simpleAction1";
            this.simpleAction1.ImageName = "CustomerProfileReport";
            this.simpleAction1.PaintStyle = DevExpress.ExpressApp.Templates.ActionItemPaintStyle.CaptionAndImage;
            this.simpleAction1.TargetViewId = "CustomerSupplier_ListView";
            this.simpleAction1.ToolTip = null;
            this.simpleAction1.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.simpleAction1_Execute);
            // 
            // FileAttachmentController
            // 
            this.Actions.Add(this.simpleAction1);

        }

        #endregion
        private DevExpress.ExpressApp.Actions.SimpleAction simpleAction1;
    }
}
