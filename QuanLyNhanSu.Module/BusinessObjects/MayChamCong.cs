using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhanSu.Module.BusinessObjects
{
    [Persistent(@"MayChamCong")]
    [XafDisplayName("Máy Chấm Công")]
    [XafDefaultProperty("tenMCC")]
    public class MayChamCong:XPLiteObject
    {
        public MayChamCong(Session session) : base(session) { }
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
        string fMaMCC;
        [XafDisplayName("Mã Máy Chấm Công")]
        public string maMCC
        {
            get { return fMaMCC; }
            set { SetPropertyValue("maMCC", ref fMaMCC, value); }
        }
        string fTenMCC;
        [XafDisplayName("Tên Máy Chấm Công")]
        public string tenMCCC
        {
            get { return fTenMCC; }
            set { SetPropertyValue("tenMCC", ref fTenMCC, value); }
        }
        string fKieuKetNoi;
        [XafDisplayName("Kiểu Kết Nối")]
        public string kieuKetNoi
        {
            get { return fKieuKetNoi; }
            set { SetPropertyValue("kieuKetNoi", ref fKieuKetNoi, value); }
        }
        string fDiaChiIP;
        [XafDisplayName("Địa Chỉ IP")]
        public string diaChiIP
        {
            get { return fDiaChiIP; }
            set { SetPropertyValue("diaChiIP", ref fDiaChiIP, value); }
        }
        string fPort;
        [XafDisplayName("Port")]
        public string port
        {
            get { return fPort; }
            set { SetPropertyValue("port", ref fPort, value); }
        }
        string fCongCOM;
        [XafDisplayName("Cổng COM")]
        public string congCOM
        {
            get { return fCongCOM; }
            set { SetPropertyValue("congCOM", ref fCongCOM, value); }
        }
        int fTocDoTruyen;
        [XafDisplayName("Tốc Độ Truyền")]
        public int tocDoTruyen
        {
            get { return fTocDoTruyen; }
            set { SetPropertyValue("tocDoTruyen", ref fTocDoTruyen, value); }
        }
        string fDiaChiWeb;
        [XafDisplayName("Địa Chỉ Trang Web")]
        [Appearance("Email", Context = "Any", FontColor = "blue", TargetItems = "email", FontStyle = System.Drawing.FontStyle.Underline)]
        public string diaChiWeb
        {
            get { return fDiaChiWeb; }
            set { SetPropertyValue("diaChiWeb", ref fDiaChiWeb, value); }
        }
        DateTime fNgayDangKyTenMien;
        [XafDisplayName("Ngày Đăng Ký Tên Miền")]
        public DateTime ngayDangKyTenMien
        {
            get { return fNgayDangKyTenMien; }
            set { SetPropertyValue("ngayDangKyTenMien", ref fNgayDangKyTenMien, value); }
        }
        bool? fSuDungWeb;
        [XafDisplayName("Sử Dụng Trang Web")]
        public bool? suDungWeb
        {
            get { return fSuDungWeb; }
            set { SetPropertyValue("suDungWeb", ref fSuDungWeb, value); }
        }
        string fSerial;
        [XafDisplayName("Số Seri")]
        public string serail
        {
            get { return fSerial; }
            set { SetPropertyValue("serial", ref fSerial, value); }
        }
        string fSoDangKy;
        [XafDisplayName("Số Đăng Ký")]
        public string soDangKy
        {
            get { return fSoDangKy; }
            set { SetPropertyValue("soDangKy", ref fSoDangKy, value); }
        }
        Image fHinhAnh;
        [XafDisplayName("Hình Ảnh Thiết Bị")]
        [ImageEditor(ListViewImageEditorMode = ImageEditorMode.PictureEdit, DetailViewImageEditorMode = ImageEditorMode.PictureEdit, ListViewImageEditorCustomHeight = 50)]
        [ValueConverter(typeof(DevExpress.Xpo.Metadata.ImageValueConverter))]
        public Image HinhAnh
        {
            get { return fHinhAnh; }
            set { SetPropertyValue("HinhAnh", ref fHinhAnh, value); }
        }
    }
}
