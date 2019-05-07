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
    public partial class CapNhatThangChamCong : ViewController
    {
        public CapNhatThangChamCong()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            CriteriaOperator criteria = CriteriaOperator.And(CriteriaOperator.Parse("[thangChamCong] Is Null"));
            CriteriaOperator criteriaOperator = new BinaryOperator("Id", new JoinOperand("ThangChamCong", null, Aggregate.Max, new OperandProperty("Id")));
            var thangChamCong = (ThangChamCong)ObjectSpace.FindObject<ThangChamCong>(criteriaOperator);
            if ((Equals(thangChamCong, null)) || thangChamCong.thangChamCong.Month < DateTime.Today.Month)
            {
                ThangChamCong thang = ObjectSpace.CreateObject<ThangChamCong>();
                DateTime thangCham = DateTime.Today;
                thang.ngayCapNhat = DateTime.Now;
                thang.thangChamCong = thangCham;
            }
            else
            {
                IList<NgayTinhCong> ngayTinhCongs = ObjectSpace.GetObjects<NgayTinhCong>(criteria);
                if (!Equals(ngayTinhCongs, null))
                {
                    IList<ThangChamCong> thangChamCongs = ObjectSpace.GetObjects<ThangChamCong>();
                    foreach (NgayTinhCong ngayTinhCong in ngayTinhCongs)
                    {
                        foreach(ThangChamCong thang in thangChamCongs)
                        {
                            if((ngayTinhCong.ngayChamCong.Month == thang.thangChamCong.Month) && (ngayTinhCong.ngayChamCong.Year == thang.thangChamCong.Year))
                            {
                                ngayTinhCong.thangChamCong = thang;
                                thang.ngayCapNhat = DateTime.Now;
                            }
                        }
                    }
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
