namespace QuanLyNhanSu.Module.Controllers
{
    partial class DuyetNghi
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
            this.duyetNghiPhep = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            // 
            // duyetNghiPhep
            // 
            this.duyetNghiPhep.Caption = "Duyệt Nghỉ";
            this.duyetNghiPhep.ConfirmationMessage = null;
            this.duyetNghiPhep.Id = "duyetNghi";
            this.duyetNghiPhep.TargetObjectType = typeof(QuanLyNhanSu.Module.BusinessObjects.LanNghiPhep);
            this.duyetNghiPhep.TargetViewType = DevExpress.ExpressApp.ViewType.DetailView;
            this.duyetNghiPhep.ToolTip = null;
            this.duyetNghiPhep.TypeOfView = typeof(DevExpress.ExpressApp.DetailView);
            this.duyetNghiPhep.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.duyetNghiPhep_Execute);
            // 
            // DuyetNghi
            // 
            this.Actions.Add(this.duyetNghiPhep);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.SimpleAction duyetNghiPhep;
    }
}
