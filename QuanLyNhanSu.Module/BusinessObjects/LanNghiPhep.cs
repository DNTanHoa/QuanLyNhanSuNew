using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhanSu.Module.BusinessObjects
{
    [Persistent(@"LanNghiPhep")]
    [XafDisplayName("Lần Nghỉ Phép")]
    public class LanNghiPhep:XPLiteObject
    {
        public LanNghiPhep(Session session):base(session)
        {

        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            this.soNgayNghi = 1;
        }
        int fId;
        [Key(true)]
        [XafDisplayName("STT")]
        public int Id
        {
            get { return fId; }
            set { SetPropertyValue("Id", ref fId, value); }
        }
        NhanVien fNguoiNghiPhep;
        [XafDisplayName("Người Xin Nghỉ Phép")]
        [Association(@"NhanVien-LanNghiPheps")]
        public NhanVien nguoiNghiPhep
        {
            get { return fNguoiNghiPhep; }
            set { SetPropertyValue("nguoiNghiPhep", ref fNguoiNghiPhep, value); }
        }
        DateTime? fNgayTaoDonXin;
        [XafDisplayName("Ngày Tạo Đơn Xin")]
        public DateTime? ngayTaoDonXin
        {
            get { return fNgayTaoDonXin; }
            set { SetPropertyValue("ngayTaoDonXin", ref fNgayTaoDonXin, value); }
        }
        DateTime? fNgayNghi;
        [XafDisplayName("Ngày Xin Nghỉ")]
        public DateTime? ngayNghi
        {
            get { return fNgayNghi; }
            set { SetPropertyValue("ngayNghi", ref fNgayNghi, value); }
        }
        double fSoNgayNghi;
        [VisibleInDetailView(false)]
        [VisibleInListView(false)]
        [XafDisplayName("Số Ngày Xin Nghỉ")]
        public double soNgayNghi
        {
            get { return fSoNgayNghi; }
            set { SetPropertyValue("soNgayNghi", ref fSoNgayNghi, value); }
        }
        NguoiDung fNguoiDuyet;
        [XafDisplayName("Người Duyệt")]
        public NguoiDung nguoiDuyet
        {
            get { return fNguoiDuyet; }
            set { SetPropertyValue("nguoiDuyet", ref fNguoiDuyet, value); }
        }
        DateTime? fNgayDuyet;
        [XafDisplayName("Ngày Duyệt")]
        public DateTime? ngayDuyet
        {
            get { return fNgayDuyet; }
            set { SetPropertyValue("ngayDuyet", ref fNgayDuyet, value); }
        }
        NguoiDung fDuyetBGD;
        [XafDisplayName("Ban Giám Đốc")]
        public NguoiDung duyetBGD
        {
            get { return fDuyetBGD; }
            set { SetPropertyValue("duyetBGD", ref fDuyetBGD, value); }
        }
        DateTime? fNgayBGDDuyet;
        [XafDisplayName("Ngày Ban Giám Đốc Duyệt")]
        public DateTime? ngayBGDDuyet
        {
            get { return fNgayBGDDuyet; }
            set { SetPropertyValue("ngayBGDDuyet", ref fNgayBGDDuyet, value); }
        }
        string fGhiChu;
        [XafDisplayName("Lý Do")]
        public string ghiChu
        {
            get { return fGhiChu; }
            set { SetPropertyValue("ghiChu", ref fGhiChu, value); }
        }
    }
}
