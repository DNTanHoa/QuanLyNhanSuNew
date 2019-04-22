using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhanSu.Module.BusinessObjects
{
    [Persistent(@"LanTangCa")]
    public class LanTangCa:XPLiteObject
    {
        public LanTangCa(Session session) : base(session) { }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }
        int fId;
        [Key(true)]
        [XafDisplayName("STT")]
        public int Id
        {
            get { return fId; }
            set { SetPropertyValue("Id", ref fId, value); }
        }
        NhanVien fNguoiTangCa;
        [XafDisplayName("Nguời Tăng Ca")]
        [Association(@"NhanVien-LanTangCa")]
        public NhanVien nguoiTangCa
        {
            get { return fNguoiTangCa; }
            set { SetPropertyValue("nguoiTangCa", ref fNguoiTangCa, value); }
        }
        DateTime fNgayTangCa;
        [XafDisplayName("Ngày Tăng Ca")]
        [ModelDefault("DisplayFormat","{0:dd/mm/yyyy}")]
        [ModelDefault("EditMask", "dd/mm/yyyy")]
        public DateTime ngayTangCa
        {
            get { return fNgayTangCa; }
            set { SetPropertyValue("ngayTangCa", ref fNgayTangCa, value); }
        }
        DateTime fThoiGianBatDau;
        [XafDisplayName("Thời Gian Bắt Đàu")]
        [ModelDefault("DisplayFormat", "{0:HH:mm}")]
        [ModelDefault("EditMask", "HH:mm")]
        public DateTime thoiGianBatDau
        {
            get { return fThoiGianBatDau; }
            set { SetPropertyValue("thoiGianBatDau", ref fThoiGianBatDau, value); }
        }
        DateTime fThoiGianKetThuc;
        [XafDisplayName("Thời Gian Kết Thúc")]
        [ModelDefault("DisplayFormat", "{0:HH:mm}")]
        [ModelDefault("EditMask", "HH:mm")]
        public DateTime thoiGianKetThuc
        {
            get { return fThoiGianKetThuc; }
            set { SetPropertyValue("thoiGianKetThuc", ref fThoiGianKetThuc, value); }
        }
        NhanVien fNguoiDuyet;
        [XafDisplayName("Người Duyệt")]
        public NhanVien nguoiDuyet
        {
            get { return fNguoiDuyet; }
            set { SetPropertyValue("nguoiDuyet", ref fNguoiDuyet, value); }
        }
        DateTime fNgayDuyet;
        [XafDisplayName("Ngày Duyệt")]
        public DateTime ngayDuyet
        {
            get { return fNgayDuyet; }
            set { SetPropertyValue("ngayDuyet", ref fNgayDuyet, value); }
        }
        string fGhiChu;
        [XafDisplayName("Ghi Chú")]
        public string ghiChu
        {
            get { return fGhiChu; }
            set { SetPropertyValue("ghiChu", ref fGhiChu, value); }
        }
    }
}
