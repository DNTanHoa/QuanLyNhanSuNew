using DevExpress.ExpressApp.DC;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhanSu.Module.BusinessObjects
{
    [Persistent(@"HopDongLaoDong")]
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
        NhanVien fTenNhanVien;
        [XafDisplayName("Tên Nhân Viên")]
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

    }
}
