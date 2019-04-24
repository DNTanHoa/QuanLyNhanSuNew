using DevExpress.Data.Filtering;
using DevExpress.ExpressApp.ConditionalAppearance;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
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
        protected override void OnChanged(string propertyName, object oldValue, object newValue)
        {
            base.OnChanged(propertyName, oldValue, newValue);
            if(!Equals(this.ngayNghiViec, null))
            {
                this.daNghiViec = true;
            }
            else
            {
                this.daNghiViec = false;
            }
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
        bool? fDaNghiviec;
        [XafDisplayName("Đã Nghỉ Việc")]
        [ModelDefault("AllowEdit","false")]
        public bool? daNghiViec
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
        int fMaChamCong;
        [XafDisplayName("Mã Chấm Công")]
        public int MaChamCong
        {
            get { return fMaChamCong; }
            set { SetPropertyValue("MaChamCong", ref fMaChamCong, value); }
        }
        public enum TinhTrangNhanVien
        {
            [XafDisplayName("Đang Bàn Giao")] thutuc = 0,
            [XafDisplayName("Đã Nghỉ Việc")] nghiviec = 1,
            [XafDisplayName("Đang Làm Việc")] hieuluc =2,
            [XafDisplayName("Đang Đánh Giá")] danhgia = 3
        }
        [XafDisplayName("Tình Trạng Nhân Viên")]
        public TinhTrangNhanVien tinhTrangNv
        {
            get
            {
                if ((bool)this.daNghiViec)
                {
                    return TinhTrangNhanVien.nghiviec;
                }
                else
                {
                    if (Equals(hopDongLaoDongs, null))
                    {
                        return TinhTrangNhanVien.thutuc;
                    }
                    else
                    {
                        var a = TinhTrangNhanVien.thutuc;
                        foreach (HopDongLaoDong hd in hopDongLaoDongs)
                        {
                            if (hd.tinhTrang == HopDongLaoDong.TinhTrangHopDong.dangcohieuluc)
                            {
                                a = TinhTrangNhanVien.hieuluc;
                                break;
                            }
                            if(hd.tinhTrang == HopDongLaoDong.TinhTrangHopDong.hethan)
                            {
                                a = TinhTrangNhanVien.danhgia;
                            }
                        }
                        return a;
                    }
                }
            }
        }
        //public enum DiemDanh
        //{
        //    [XafDisplayName("Chưa chấm công")] chua = 0,
        //    [XafDisplayName("Chấm công thiếu")] thieu = 1,
        //    [XafDisplayName("Chấm công đủ")] du = 2
        //}
        //[XafDisplayName("Tình Trạng Chấm Công")]
        //public DiemDanh diemDanhNgay
        //{
        //    get
        //    {
        //        CheckInOut cks = Session.GetObjectByKey<CheckInOut>(new BinaryOperator("NgayCham", DateTime.Now));
        //        if()
        //    }
        //}
        [XafDisplayName("Mức Lương Hiện Tại")]
        [VisibleInListView(false)]
        public double? mucLuongHienTai
        {
            get
            {
                HopDongLaoDong hopDong = this.hopDongLaoDongs.LastOrDefault<HopDongLaoDong>();
                if(!Equals(hopDong, null))
                {
                    return hopDong.mucLuong;
                }
                else
                {
                    return null;
                }
            }
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
