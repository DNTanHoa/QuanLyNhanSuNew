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
    [Persistent(@"HopDongLaoDong")]
    [XafDisplayName("Hợp Đồng Lao Động")]
    public class HopDongLaoDong:XPLiteObject
    {
        public HopDongLaoDong(Session session) : base(session) { }
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
        string fSoHopDongLaoDong;
        [XafDisplayName("Số Hợp Đồng Lao Động")]
        public string soHopDongLaoDong
        {
            get { return fSoHopDongLaoDong; }
            set { SetPropertyValue("soHopDongLaoDong", ref fSoHopDongLaoDong, value); }
        }
        NhanVien fTenNhanVien;
        [XafDisplayName("Tên Nhân Viên")]
        [Association(@"NhanVien-HopDongLaoDong")]
        public NhanVien tenNhanVien
        {
            get { return fTenNhanVien; }
            set { SetPropertyValue("tenNhanVien", ref fTenNhanVien, value); }
        }
        LoaiHopDong fLoaiHopDong;
        [XafDisplayName("Loại Hợp Đồng")]
        public LoaiHopDong loaiHopDong
        {
            get { return fLoaiHopDong; }
            set { SetPropertyValue("loaiHopDong", ref fLoaiHopDong, value); }
        }
        DateTime fNgayKiHopDong;
        [XafDisplayName("Ngày Kí Hợp Đồng")]
        [ModelDefault("DisplayFormat", "{0:dd/MM/yyyy}")]
        [ModelDefault("EditMask", "dd/MM/yyyy")]
        public DateTime ngayKiHopDong
        {
            get { return fNgayKiHopDong; }
            set { SetPropertyValue("ngayKiHopDong", ref fNgayKiHopDong, value); }
        }
        DateTime fNgayBatDau;
        [XafDisplayName("Ngày Bắt Đầu")]
        [ModelDefault("DisplayFormat","{0:dd/MM/yyyy}")]
        [ModelDefault("EditMask", "dd/MM/yyyy")]
        public DateTime ngayBatDau
        {
            get { return fNgayBatDau; }
            set { SetPropertyValue("ngayBatDau", ref fNgayBatDau, value); }
        }
        [XafDisplayName("Ngày Kết Thúc")]
        [ModelDefault("DisplayFormat", "{0:dd/MM/yyyy}")]
        public DateTime? ngayKetThuc
        {
            get
            {
                if (this.loaiHopDong != null)
                {
                    if(this.loaiHopDong.loaiThoiHan == LoaiHopDong.LoaiThoiHan.vothoihan)
                    {
                        return null;
                    }
                    else
                    {
                        return this.ngayBatDau.AddMonths(this.loaiHopDong.thoiHanHopDong);
                    }
                }
                else
                {
                    return null;
                }
            }
        }
        double? fMucLuong;
        [XafDisplayName("Mức Lương")]
        public double? mucLuong
        {
            get { return fMucLuong; }
            set { SetPropertyValue("mucLuong",ref fMucLuong, value); }
        }
        string fGhiChu;
        [XafDisplayName("Ghi Chú")]
        public string ghiChu
        {
            get { return fGhiChu; }
            set { SetPropertyValue("ghiChu", ref fGhiChu, value); }
        }
        public enum TinhTrangHopDong
        {
            [XafDisplayName("Đang Có Hiệu Lực")] dangcohieuluc = 0,
            [XafDisplayName("Sắp Hết Hạn")] saphethan = 1,
            [XafDisplayName("Hết Hạn")] hethan = 2,
            [XafDisplayName("Không Xác Định")] khongxacdinh = 3
        }
        [XafDisplayName("Tình Trạng Hợp Động")]
        public TinhTrangHopDong tinhTrang
        {
            get
            {
                try
                {
                    if ((bool)this.tenNhanVien.daNghiViec)
                    {
                        return TinhTrangHopDong.hethan;
                    }
                    else
                    {
                        if (this.ngayKetThuc != null)
                        {
                            if ((this.ngayKetThuc >= DateTime.Today.AddDays(7)) && (this.ngayKetThuc <= DateTime.Today.AddDays(10)))
                            {
                                return TinhTrangHopDong.saphethan;
                            }
                            else if (this.ngayKetThuc < DateTime.Today)
                            {
                                return TinhTrangHopDong.hethan;
                            }
                            else
                            {
                                return TinhTrangHopDong.dangcohieuluc;
                            }
                        }
                        else
                        {
                            return TinhTrangHopDong.khongxacdinh;
                        }
                    }
                }
                catch { return TinhTrangHopDong.khongxacdinh; }
            }
        }
    }
}
