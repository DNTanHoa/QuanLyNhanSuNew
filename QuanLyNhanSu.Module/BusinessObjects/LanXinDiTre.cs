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
    [Persistent(@"LanXinDiTre")]
    [XafDisplayName("Lần Xin Đi Trễ")]
    public class LanXinDiTre:XPLiteObject
    {
        public LanXinDiTre(Session session) : base(session) { }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            this.ngayTaoPhieu = DateTime.Today;
        }
        int fId;
        [Key(true)]
        [XafDisplayName("STT")]
        public int Id
        {
            get { return fId; }
            set { SetPropertyValue("Id", ref fId, value); }
        }
        DateTime fNgayTaoPhieu;
        [XafDisplayName("Ngày Tạo Phiếu Đi Trễ")]
        [ModelDefault("DisplayFormat","{0:dd/MM/yyyy}")]
        [ModelDefault("AllowEdit","false")]
        public DateTime ngayTaoPhieu
        {
            get { return fNgayTaoPhieu; }
            set { SetPropertyValue("ngayTaoPhieu", ref fNgayTaoPhieu, value); }
        }
        NhanVien fNguoiXinDiTre;
        [XafDisplayName("Nguời Xin Đi Trễ")]
        [Association(@"NhanVien-LanXinDiTre")]
        public NhanVien nguoiXinDiTre
        {
            get { return fNguoiXinDiTre; }
            set { SetPropertyValue("nguoiXinDiTre", ref fNguoiXinDiTre, value); }
        }
        DateTime fNgayXinDiTre;
        [XafDisplayName("Ngày Xin Đi Trễ")]
        [ModelDefault("DisplayFormat", "{0:dd/MM/yyyy}")]
        [ModelDefault("EditMask","dd/MM/yyyy")]
        public DateTime ngayXinDiTre
        {
            get { return fNgayXinDiTre; }
            set { SetPropertyValue("ngayXinDiTre", ref fNgayXinDiTre, value); }
        }
        NguoiDung fNguoiDuyet;
        [XafDisplayName("Người Duyệt")]
        public NguoiDung nguoiDuyet
        {
            get { return fNguoiDuyet; }
            set { SetPropertyValue("nguoiDuyet", ref fNguoiDuyet, value); }
        }
        DateTime fNgayDuyet;
        [XafDisplayName("Ngày Duyệt Thông Tin")]
        [ModelDefault("DisplayFormat", "{0:dd/MM/yyyy}")]
        [ModelDefault("EditMask", "dd/MM/yyyy")]
        public DateTime ngayDuyet
        {
            get { return fNgayDuyet; }
            set { SetPropertyValue("ngayDuyet", ref fNgayDuyet, value); }
        }
        string fLyDo;
        [XafDisplayName("Lý Do")]
        public string lyDo
        {
            get { return fLyDo; }
            set { SetPropertyValue("lyDo", ref fLyDo, value); }
        }
        string fghiChu;
        [XafDisplayName("Ghi Chú")]
        public string ghiChu
        {
            get { return fghiChu; }
            set { SetPropertyValue("ghiChu", ref fghiChu, value); }
        }
    }
}
