using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhanSu.Module.BusinessObjects
{
    [Persistent(@"NhanVien")]
    [DefaultProperty("hoTen")]
    [XafDisplayName("Nhân Viên")]
    public class NhanVien:XPLiteObject
    {
        public NhanVien(Session session):base(session)
        {

        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }
        int fId;
        [XafDisplayName("STT")]
        [Key(true)]
        public int Id
        {
            get { return fId; }
            set { SetPropertyValue("Id", ref fId, value); }
        }
        string fHoTen;
        [XafDisplayName("Họ Và Tên")]
        public string hoTen
        {
            get { return fHoTen;}
            set { SetPropertyValue("hoTen", ref fHoTen, value); }
        }
        string fMaNhanVien;
        [XafDisplayName("Mã Nhân Viên")]
        public string maNhanVien
        {
            get { return fMaNhanVien; }
            set { SetPropertyValue("maNhanVien", ref fMaNhanVien, value); }
        }
        string fDienThoaiLienLac;
        [XafDisplayName("Điện Thoại Liên Lạc")]
        public string dienThoaiLienLac
        {
            get { return fDienThoaiLienLac; }
            set { SetPropertyValue("dienThoaiLienLac", ref fDienThoaiLienLac, value); }
        }
        string fEmail;
        [XafDisplayName("E-mail")]
        [Appearance("Email", Context="Any", FontColor="blue", TargetItems ="email", FontStyle =System.Drawing.FontStyle.Underline)]
        public string email
        {
            get { return fEmail; }
            set { SetPropertyValue("Email", ref fEmail, value); }
        }
        string fCMND;
        [XafDisplayName("Chứng Minh Nhân Dân")]
        public string cmnd
        {
            get { return fCMND; }
            set { SetPropertyValue("cmnd", ref fCMND, value); }
        }
        bool fDaNghiviec;
        [XafDisplayName("Đã Nghỉ Việc")]
        public bool daNghiViec
        {
            get { return fDaNghiviec; }
            set { SetPropertyValue("daNghiViec",ref fDaNghiviec, value); }
        }
        DateTime? fNgayNghiViec;
        [XafDisplayName("Ngày Nghỉ Việc")]
        public DateTime? ngayNghiViec
        {
            get { return fNgayNghiViec; }
            set { SetPropertyValue("ngayNghiViec", ref fNgayNghiViec, value); }
        }
        BoPhan fBoPhan;
        [XafDisplayName("Bộ Phận Làm Việc")]
        [Association(@"NhanVien-BoPhan")]
        public BoPhan boPhan
        {
            get { return fBoPhan; }
            set { SetPropertyValue("boPhan", ref fBoPhan, value); }
        }
        Image fHinhAnh;
        [XafDisplayName("Hình Ảnh Cá Nhân")]
        [ImageEditor(ListViewImageEditorMode = ImageEditorMode.PictureEdit, DetailViewImageEditorMode = ImageEditorMode.PictureEdit, ListViewImageEditorCustomHeight = 50)]
        [ValueConverter(typeof(DevExpress.Xpo.Metadata.ImageValueConverter))]
        public Image HinhAnh
        {
            get { return fHinhAnh; }
            set { SetPropertyValue("HinhAnh", ref fHinhAnh, value); }
        }
        ChucVu fChucVu;
        [XafDisplayName("Chức Vụ")]
        public ChucVu chucVuNhanVien
        {
            get { return fChucVu; }
            set { SetPropertyValue("chucVuNhanVien", ref fChucVu, value); }
        }
        CaLamViec fCaLamViec;
        [XafDisplayName("Ca Làm Việc")]
        public CaLamViec caLamViec
        {
            get { return fCaLamViec; }
            set { SetPropertyValue("caLamViec", ref fCaLamViec, value); }
        }
        string fGhiChu;
        [XafDisplayName("Ghi Chú")]
        public string ghiChu
        {
            get { return fGhiChu; }
            set { SetPropertyValue("ghiChu", ref fGhiChu, value); }
        }
        [Association(@"NhanVien-CheckInOut")]
        [XafDisplayName("Thời Gian Chấm Công")]
        public XPCollection<CheckInOut> thoiGianChamCongs { get { return GetCollection<CheckInOut>("thoiGianChamCongs"); } }
        [Association(@"NhanVien-LanNghiPheps")]
        [XafDisplayName("Lần Nghỉ Phép")]
        public XPCollection<LanNghiPhep> lanNghiPheps { get { return GetCollection<LanNghiPhep>("lanNghiPheps"); } }
        [Association(@"NhanVien-LanTangCa")]
        [XafDisplayName("Lần Tăng Ca")]
        public XPCollection<LanTangCa> lanTangCas { get { return GetCollection<LanTangCa>("lanTangCas"); } }
        [Association(@"NhanVien-LanBoSungGio")]
        [XafDisplayName("Lần Bố Sung Giờ")]
        public XPCollection<LanBoSungGio> lanBoSungGios { get { return GetCollection<LanBoSungGio>("lanBoSungGios"); } }
        [Association(@"NhanVien-HopDongLaoDong")]
        [XafDisplayName("Hợp Đồng Lao Động")]
        public XPCollection<HopDongLaoDong> hopDongLaoDongs { get { return GetCollection<HopDongLaoDong>("hopDongLaoDongs"); } }
    }
}
