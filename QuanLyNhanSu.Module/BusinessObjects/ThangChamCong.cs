using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhanSu.Module.BusinessObjects
{
    [XafDisplayName("Tháng Chấm Công")]
    [Persistent(@"ThangChamCong")]
    public class ThangChamCong: XPLiteObject
    {
        public ThangChamCong(Session session) : base(session) { }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }
        protected override void OnLoaded()
        {
            base.OnLoaded();
            Session.CommitTransaction();
        }
        int fId;
        [Key(true)]
        [XafDisplayName("STT")]
        public int Id
        {
            get { return fId; }
            set { SetPropertyValue("Id", ref fId, value); }
        }
        BoPhan fBoPhan;
        [XafDisplayName("Bộ Phận")]
        [Association(@"ThangChamCongs-BoPhan")]
        public BoPhan boPhan
        {
            get { return fBoPhan; }
            set { SetPropertyValue("boPhan", ref fBoPhan, value); }
        }
        DateTime fNgayCapNhat;
        [XafDisplayName("Ngày Cập Nhật")]
        [ModelDefault("DisplayFormat", "{0:dd/MM/yyyy HH:MM}")]
        [ModelDefault("EditMask", "dd/MM/yyyy HH:MM")]
        [ModelDefault("AllowEdit","false")]
        public DateTime ngayCapNhat
        {
            get { return fNgayCapNhat; }
            set { SetPropertyValue("ngayCapNhat", ref fNgayCapNhat, value); }
        }
        DateTime fThangChamCong;
        [XafDisplayName("Tháng Chấm Công")]
        [ModelDefault("DisplayFormat", "{0:MM/yyyy}")]
        [ModelDefault("EditMask", "MM/yyyy")]
        [ModelDefault("AllowEdit", "false")]

        public DateTime thangChamCong
        {
            get { return fThangChamCong; }
            set { SetPropertyValue("thangChamCong", ref fThangChamCong, value); }
        }
        int fSoNgayLamViec;
        [XafDisplayName("Số Ngày Làm Việc")]
        [VisibleInListView(false)]
        public int soNgayLamViec
        {
            get
            {
                int soNgay = 0;
                if(!Equals(ngayTinhCongs, null))
                {
                    foreach(NgayTinhCong ngayTinhCong in ngayTinhCongs)
                    {
                        if((ngayTinhCong.IsHoliday != true) && (ngayTinhCong.IsSunDay != true))
                        {
                            soNgay += 1;
                        }
                    }
                }
                return soNgay;
            }
        }
        int fSoNgayChuNhat;
        [XafDisplayName("Số Ngày Chủ Nhật")]
        [VisibleInListView(false)]
        public int soNgayChuNhat
        {
            get
            {
                int soNgay = 0;
                if (!Equals(ngayTinhCongs, null))
                {
                    foreach (NgayTinhCong ngayTinhCong in ngayTinhCongs)
                    {
                        if (ngayTinhCong.IsSunDay == true)
                        {
                            soNgay += 1;
                        }
                    }
                }
                return soNgay;
            }
        }
        int fSoNgayLe;
        [XafDisplayName("Số Ngày Lễ")]
        [VisibleInListView(false)]
        public int soNgayLe
        {
            get
            {
                int soNgay = 0;
                if (!Equals(ngayTinhCongs, null))
                {
                    foreach (NgayTinhCong ngayTinhCong in ngayTinhCongs)
                    {
                        if (ngayTinhCong.IsHoliday == true)
                        {
                            soNgay += 1;
                        }
                    }
                }
                return soNgay;
            }
        }
        [XafDisplayName("Ngày Tính Công")]
        [VisibleInDetailView(false)]
        [VisibleInListView(false)]
        [Association(@"ThangChamCong-NgayTinhCongs")]
        public XPCollection<NgayTinhCong> ngayTinhCongs { get { return GetCollection<NgayTinhCong>("ngayTinhCongs"); } }
    }
}
