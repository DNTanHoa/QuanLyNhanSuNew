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
    public partial class DuyetNghi : ViewController
    {
        public DuyetNghi()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
        }
        protected override void OnActivated()
        {
            base.OnActivated();
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

        private void duyetNghiPhep_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            LanNghiPhep lanNghiPhep = (LanNghiPhep)View.CurrentObject;
            //string condition = CriteriaOperator.And(CriteriaOperator.Parse("[nguoiNghiPhep] = ?",lanNghiPhep.nguoiNghiPhep), CriteriaOperator.Parse("GetMonth([ngayNghi])",DateTime.Today.Month)).ToString();
            CriteriaOperator criteria = CriteriaOperator.And(CriteriaOperator.Parse("[nguoiNghiPhep] = ?", lanNghiPhep.nguoiNghiPhep), CriteriaOperator.Parse("IsThisMonth([ngayNghi])"));
            IList<LanNghiPhep> lanNghiPheps = ObjectSpace.GetObjects<LanNghiPhep>(criteria);
            CriteriaOperator criteriaOperator = CriteriaOperator.And(CriteriaOperator.Parse("[nguoiNghiPhep] = ?", lanNghiPhep.nguoiNghiPhep), CriteriaOperator.Parse("IsThisMonth([ngayNghi])"), CriteriaOperator.Parse("[ngayDuyet] Is Not Null"));
            IList<LanNghiPhep> daDuyets = ObjectSpace.GetObjects<LanNghiPhep>(criteriaOperator);

            lanNghiPhep.ngayDuyet = DateTime.Today;
            lanNghiPhep.nguoiDuyet = lanNghiPhep.Session.GetObjectByKey<NguoiDung>(SecuritySystem.CurrentUserId);
            MessageBox.Show("Đã Duyệt Thành Công");

            //if (lanNghiPhep.Session.GetObjectByKey<NguoiDung>(SecuritySystem.CurrentUserId).EmployeeRoles.)
            //{
            //    if((lanNghiPheps.Count >= 3) && (daDuyets.Count >= 2))
            //    {
            //        MessageBox.Show("Không Được phép duyệt, vì đã nghỉ 2 ngày trước đó");

            //    }
            //    else
            //    {
            //        lanNghiPhep.ngayDuyet = DateTime.Today;
            //        lanNghiPhep.nguoiDuyet = lanNghiPhep.Session.GetObjectByKey<NguoiDung>(SecuritySystem.CurrentUserId);
            //        MessageBox.Show("Đã Duyệt Thành Công");
            //        MessageBox.Show(daDuyets.Count.ToString());
            //    }
            //}
            ObjectSpace.CommitChanges();
            ObjectSpace.Refresh();
            View.Refresh();
        }
    }
}
