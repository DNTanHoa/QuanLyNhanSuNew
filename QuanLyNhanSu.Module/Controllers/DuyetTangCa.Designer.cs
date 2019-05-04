namespace QuanLyNhanSu.Module.Controllers
{
    partial class DuyetTangCa
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
            this.Duyet = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            // 
            // Duyet
            // 
            this.Duyet.Caption = "Duyệt Tăng Ca";
            this.Duyet.ConfirmationMessage = null;
            this.Duyet.Id = "duyetTangCa";
            this.Duyet.TargetObjectType = typeof(QuanLyNhanSu.Module.BusinessObjects.LanTangCa);
            this.Duyet.TargetViewType = DevExpress.ExpressApp.ViewType.DetailView;
            this.Duyet.ToolTip = null;
            this.Duyet.TypeOfView = typeof(DevExpress.ExpressApp.DetailView);
            this.Duyet.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.Duyet_Execute);
            // 
            // DuyetTangCa
            // 
            this.Actions.Add(this.Duyet);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.SimpleAction Duyet;
    }
}
