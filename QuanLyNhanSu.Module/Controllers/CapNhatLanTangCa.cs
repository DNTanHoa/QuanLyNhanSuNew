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
    public partial class CapNhatLanTangCa : ViewController
    {
        public CapNhatLanTangCa()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            string condition = CriteriaOperator.And(CriteriaOperator.Parse("[ngayDuyet] Is Null")).ToString();
            CriteriaOperator criteria = CriteriaOperator.Parse(condition);
            IList<LanTangCa> lanTangCas = ObjectSpace.GetObjects<LanTangCa>(criteria);
            Console.WriteLine("Cap nhat lan tang ca");
            foreach (LanTangCa lanTangCa in lanTangCas)
            {
                CriteriaOperator criteriaOperator = CriteriaOperator.And(CriteriaOperator.Parse("[nguoiChamCong] = ?", lanTangCa.nguoiTangCa), CriteriaOperator.Parse("[ngay.ngayChamCong] = ?", lanTangCa.ngayTangCa));
                GioCong gio = ObjectSpace.FindObject<GioCong>(criteriaOperator);
                if (!Equals(gio, null))
                {
                    gio.soGioTangCa = lanTangCa.thoiGianTangCa;
                    gio.duyetTangCa = false;
                }

                lanTangCa.gioCong = gio;
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
