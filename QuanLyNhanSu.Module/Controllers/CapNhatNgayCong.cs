using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    public partial class CapNhatNgayCong : ViewController
    {
        public CapNhatNgayCong()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            NgayTinhCong ngayTinh = ObjectSpace.FindObject<NgayTinhCong>(new BinaryOperator("ngayChamCong",DateTime.Today));
            // if this today haven't updated data
            if (Equals(ngayTinh, null))
            {
                NgayTinhCong ngayTinhCong = ObjectSpace.CreateObject<NgayTinhCong>();
                ngayTinhCong.ngayChamCong = DateTime.Today;
                //Add list of employees
                var nhanViens = ObjectSpace.GetObjects<NhanVien>(new BinaryOperator("daNghiViec", false));
                foreach(NhanVien nhanVien in nhanViens)
                {
                    GioCong gioCong = ObjectSpace.CreateObject<GioCong>();
                    gioCong.nguoiChamCong = nhanVien;
                    gioCong.ngay = ngayTinhCong;
                }
                ObjectSpace.CommitChanges();
                ObjectSpace.Refresh();
                View.Refresh();
            }   
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            
        }
        protected override void OnDeactivated()
        {
            
            base.OnDeactivated();
        }
    }
}
