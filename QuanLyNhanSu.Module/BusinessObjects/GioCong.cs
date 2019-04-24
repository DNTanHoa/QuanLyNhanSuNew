using DevExpress.ExpressApp.DC;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhanSu.Module.BusinessObjects
{
    [Persistent(@"GioCong")]
    [XafDisplayName("Bảng Giờ Công")]
    public class GioCong : XPLiteObject
    {
        public GioCong(Session session) : base(session) { }
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
        NhanVien fNguoiChamCong;
        [XafDisplayName("Tên Nhân Viên")]
        public NhanVien nguoiChamCong
        {
            get { return fNguoiChamCong; }
            set { SetPropertyValue("nguoiChamCong", ref fNguoiChamCong, value); }
        }
        DateTime? fNgay;
        [XafDisplayName("Ngày Chấm Công")]
        public DateTime? ngay
        {
            get { return fNgay; }
            set { SetPropertyValue("ngay", ref fNgay, value); }
        }
        int? fSoLanQuet;
        [XafDisplayName("Số Lần Chấm Công")]
        public int? soLanQuet
        {
            get { return fSoLanQuet; }
            set { SetPropertyValue("soLanQuet", ref fSoLanQuet, value); }
        }
        double? fSoGioCoBan;
        [XafDisplayName("Số Giờ Cơ Bản")]
        public double? soGioCoBan
        {
            get { return fSoGioCoBan; }
            set { SetPropertyValue("soGioCoBan", ref fSoGioCoBan, value); }
        }
        double? fSoGioTangCa;
        [XafDisplayName("Số Giờ Tăng Ca")]
        public double? soGioTangCa
        {
            get { return fSoGioTangCa; }
            set { SetPropertyValue("soGioTangCa", ref fSoGioTangCa, value); }
        }
    }
}
