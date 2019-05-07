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
    public partial class CapNhatNgayCong : ViewController
    {
        public CapNhatNgayCong()
        {
            InitializeComponent();
            //TargetViewId = "Any";
            //TargetViewType = ViewType.Any;
            // Target required Views (via the TargetXXX properties) and create their Actions.
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            int soNgayChuaCapNhat = 0;
            /*Tìm ngày cuối cùng lúc trước khi cập nhật*/
            CriteriaOperator criteria = new BinaryOperator("Id", new JoinOperand("NgayTinhCong", null, Aggregate.Max, new OperandProperty("Id")));
            var ngayTinhCongs = (NgayTinhCong)ObjectSpace.FindObject<NgayTinhCong>(criteria);
            if (Equals(ngayTinhCongs, null))
            {
                NgayTinhCong ngayTinhCong = ObjectSpace.CreateObject<NgayTinhCong>();
                ngayTinhCong.ngayChamCong = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
                IList<NhanVien> nhanViens = ObjectSpace.GetObjects<NhanVien>();// new BinaryOperator("daNghiViec", false));
                Console.WriteLine("Danh sach nhan vien");
                Console.WriteLine(nhanViens);
                if (Equals(nhanViens, null))
                {
                    MessageBox.Show("Khong co nhan vien");
                }
                else
                {
                    foreach (NhanVien nhanVien in nhanViens)
                    {
                        GioCong gioCong = ObjectSpace.CreateObject<GioCong>();
                        gioCong.nguoiChamCong = nhanVien;
                        gioCong.ngay = ngayTinhCong;
                    }
                    ObjectSpace.CommitChanges();
                    //ObjectSpace.Refresh();
                    //View.Refresh();
                }
            }
            else
            {
                DateTime ngayCuoiCung = ngayTinhCongs.ngayChamCong;

                soNgayChuaCapNhat = (int)(DateTime.Today - ngayCuoiCung).TotalDays;

                if (!Equals(soNgayChuaCapNhat, 0))
                {
                    for (int i = 1; i <= soNgayChuaCapNhat; i++)
                    {
                        NgayTinhCong ngayTinhCong = ObjectSpace.CreateObject<NgayTinhCong>();
                        ngayTinhCong.ngayChamCong = ngayCuoiCung.AddDays(i);
                        IList<NhanVien> nhanViens = ObjectSpace.GetObjects<NhanVien>();//new BinaryOperator("daNghiViec", false));
                        foreach (NhanVien nhanVien in nhanViens)
                        {
                            GioCong gioCong = ObjectSpace.CreateObject<GioCong>();
                            gioCong.nguoiChamCong = nhanVien;
                            gioCong.ngay = ngayTinhCong;
                        }
                    }
                    ObjectSpace.CommitChanges();
                    //ObjectSpace.Refresh();
                    //View.Refresh();
                }
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
