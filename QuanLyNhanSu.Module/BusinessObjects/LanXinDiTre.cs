using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhanSu.Module.BusinessObjects
{
    [DefaultClassOptions]
    [Persistent(@"LanXinDiTre")]
    [XafDisplayName("Phiếu Xin Đi Trễ - Về Sớm")]
    public class LanXinDiTre:XPLiteObject
    {
        public LanXinDiTre(Session session) : base(session) { }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            this.ngayTaoPhieu = DateTime.Today;
        }
        protected override void OnSaving()
        {
            base.OnSaving();
            //if (Equals(this.nguoiTaoPhieu,null))
            //{
            //    this.Delete();
            //}
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
        [XafDisplayName("Ngày Tạo Phiếu")]
        [ModelDefault("DisplayFormat","{0:dd/MM/yyyy}")]
        [ModelDefault("AllowEdit","false")]
        public DateTime ngayTaoPhieu
        {
            get { return fNgayTaoPhieu; }
            set { SetPropertyValue("ngayTaoPhieu", ref fNgayTaoPhieu, value); }
        }
        NhanVien fNguoiTaoPhieu;
        //[RuleRequiredField(DefaultContexts.Save, TargetCriteria = "")]
        [XafDisplayName("Nguời Tạo Phiếu")]
        [Association(@"NhanVien-LanXinDiTre")]
        public NhanVien nguoiTaoPhieu
        {
            get { return fNguoiTaoPhieu; }
            set { SetPropertyValue("nguoiTaoPhieu", ref fNguoiTaoPhieu, value); }
        }
        public enum XinPhep
        {
            [XafDisplayName("Về Sớm")] vesom = 0,
            [XafDisplayName("Đi Trễ")] ditre = 1
        }
        XinPhep fLoaiPhep;
        [XafDisplayName("Loại Phép")]
        public XinPhep loaiPhep
        {
            get { return fLoaiPhep; }
            set { SetPropertyValue("loaiPhep", ref fLoaiPhep, value); }
        }
        DateTime fNgayXinPhep;
        [XafDisplayName("Ngày Xin Phép")]
        [ModelDefault("DisplayFormat", "{0:dd/MM/yyyy}")]
        [ModelDefault("EditMask","dd/MM/yyyy")]
        public DateTime ngayXinPhep
        {
            get { return fNgayXinPhep; }
            set { SetPropertyValue("ngayXinPhep", ref fNgayXinPhep, value); }
        }
        NguoiDung fNguoiDuyet;
        [XafDisplayName("Người Duyệt")]
        public NguoiDung nguoiDuyet
        {
            get { return fNguoiDuyet; }
            set { SetPropertyValue("nguoiDuyet", ref fNguoiDuyet, value); }
        }
        DateTime? fNgayDuyet;
        [XafDisplayName("Ngày Duyệt Thông Tin")]
        [ModelDefault("DisplayFormat", "{0:dd/MM/yyyy}")]
        [ModelDefault("EditMask", "dd/MM/yyyy")]
        public DateTime? ngayDuyet
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
        GioCong fgioCong;
        [XafDisplayName("Giờ Công")]
        [VisibleInListView(false)]
        [VisibleInDetailView(false)]
        [Association(@"GioCong-LanXinDiTre")]
        public GioCong gioCong
        {
            get { return fgioCong; }
            set { SetPropertyValue("gioCong", ref fgioCong, value); }
        }
    }
}
