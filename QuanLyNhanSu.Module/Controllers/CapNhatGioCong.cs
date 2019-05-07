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
    public partial class CapNhatGioCong : ViewController
    {
        public CapNhatGioCong()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            string condition = CriteriaOperator.And(CriteriaOperator.Parse("[gioCong] Is Null")).ToString();
            CriteriaOperator criteria = CriteriaOperator.Parse(condition);
            IList<CheckInOut> checkInOuts = ObjectSpace.GetObjects<CheckInOut>(criteria);
            foreach (CheckInOut checkInOut in checkInOuts)
            {
                CheckInOut check = ObjectSpace.GetObjectByKey<CheckInOut>(checkInOut.Id);
                CriteriaOperator criteriaOperator = CriteriaOperator.And(CriteriaOperator.Parse("[nguoiChamCong] = ?", check.nguoiChamCong), CriteriaOperator.Parse("[ngay.ngayChamCong] = ?", check.NgayCham));
                GioCong gio = ObjectSpace.FindObject<GioCong>(criteriaOperator);
                check.gioCong = gio;
            }
            ObjectSpace.CommitChanges();
            ObjectSpace.Refresh();
            View.Refresh();
            Console.WriteLine(checkInOuts);
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }
    }
}
