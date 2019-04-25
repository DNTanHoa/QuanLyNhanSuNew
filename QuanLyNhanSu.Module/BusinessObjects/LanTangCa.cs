using DevExpress.Data.Filtering;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.Base;
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
        LoaiTangCa fLoaiTangCa;
        [XafDisplayName("Loại Tăng Ca")]
        public LoaiTangCa loaiTangCa
        {
            get { return fLoaiTangCa; }
            set { SetPropertyValue("loaiTangCa", ref fLoaiTangCa, value); }
        }
        [XafDisplayName("Hệ Số Nhân Giờ")]
        public int heSoNhanGio
        {
            get
            {
                if(!Equals(this.loaiTangCa,null))
                {
                    return this.loaiTangCa.heSoNhanGio;
                }
                else
                {
                    return 0;
                }
            }
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
        GioCong fgioCong;
        [VisibleInListView(false)]
        [VisibleInDetailView(false)]
        [Association(@"GiocCong-LanTangCa")]
        public GioCong gioCong
        {
            get
            {
                if(!Equals(this.ngayDuyet,null))
                {
                    CriteriaOperator criteria = CriteriaOperator.And(CriteriaOperator.Parse("[nguoiChamCong] = ?", this.nguoiTangCa), CriteriaOperator.Parse("[ngay.ngayChamCong] = ?", this.ngayDuyet));
                    GioCong gioCong = Session.FindObject<GioCong>(criteria);
                    if (!Equals(gioCong))
                    {
                        return gioCong;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            set { SetPropertyValue("gioCong", ref fgioCong, value); }
        }
    }
}
