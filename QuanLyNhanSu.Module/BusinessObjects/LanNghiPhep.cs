using DevExpress.ExpressApp.DC;
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
            set { SetPropertyValue("fNgayNghi", ref fNgayTaoDonXin, value); }
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
