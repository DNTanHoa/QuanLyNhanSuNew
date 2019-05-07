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
    public partial class CapNhatXinDiTre : ViewController
    {
        public CapNhatXinDiTre()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            string condition = CriteriaOperator.And(CriteriaOperator.Parse("[ngayDuyet] Is Null")).ToString();
            CriteriaOperator criteria = CriteriaOperator.Parse(condition);
            IList<LanXinDiTre> lanXinDiTres = ObjectSpace.GetObjects<LanXinDiTre>(criteria);
            foreach (LanXinDiTre lanXinDiTre in lanXinDiTres)
            {
                CriteriaOperator criteriaOperator = CriteriaOperator.And(CriteriaOperator.Parse("[nguoiChamCong] = ?", lanXinDiTre.nguoiTaoPhieu), CriteriaOperator.Parse("[ngay.ngayChamCong] = ?", lanXinDiTre.ngayXinPhep));
                GioCong gio = ObjectSpace.FindObject<GioCong>(criteriaOperator);
                //if (!Equals(gio, null))
                //{
                //    //gio.soLanDiTre -= 1;
                //    //gio.soLanDiTre = gio.soLanDiTre - 1;
                //}

                lanXinDiTre.gioCong = gio;
            }
            ObjectSpace.CommitChanges();
            ObjectSpace.Refresh();
            View.Refresh();
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
