using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
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
using QuanLyNhanSu.Module.BusinessObjects;

namespace QuanLyNhanSu.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class CapNhatNhanVien : ViewController
    {
        public CapNhatNhanVien()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            //MessageBox.Show("Cập nhật nhân viên");
            CriteriaOperator criteria = CriteriaOperator.And(CriteriaOperator.Parse("[thoiGianChamCongs][].Count() = ?", 0));
            IList<NhanVien> nhanViens = ObjectSpace.GetObjects<NhanVien>(criteria);
            if (!Equals(nhanViens, null))
            {
                foreach (NhanVien nv in nhanViens)
                {
                    nv.ngayNghiViec = new DateTime(2019, 3, 30);
                }
            }
            
            ObjectSpace.CommitChanges();
            ObjectSpace.Refresh();
            View.Refresh();
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
    }
}
