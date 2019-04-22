using DevExpress.ExpressApp.DC;
using DevExpress.Xpo;

namespace QuanLyNhanSu.Module.BusinessObjects
{
    [Persistent(@"LoaiHopDong")]
    [XafDisplayName("Loại Hợp Đồng")]
    [XafDefaultProperty("tenHopDong")]
    public class LoaiHopDong:XPLiteObject
    {
        public LoaiHopDong(Session session) : base(session) { }
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
        string fTenHopDong;
        [XafDisplayName("Tên Hợp Đồng")]
        public string tenHopDong
        {
            get { return fTenHopDong; }
            set { SetPropertyValue("tenHopDong",ref fTenHopDong, value);}
        }
        public enum LoaiThoiHan
        {
            [XafDisplayName("Có Thời Hạn")] cothoihan = 0,
            [XafDisplayName("Vô Thời Hạn")] vothoihan = 1,
            [XafDisplayName("Học Việc")] hocviec = 2
        }
        LoaiThoiHan fLoaiThoiHan;
        [XafDisplayName("Loại Thời Hạn")]
        public LoaiThoiHan loaiThoiHan
        {
            get { return fLoaiThoiHan; }
            set { SetPropertyValue("loaiThoiHan", ref fLoaiThoiHan, value); }
        }
        int fThoiHanHopDong;
        [XafDisplayName("Thời Hạn Họp Đồng")]
        public int thoiHanHopDong
        {
            get { return fThoiHanHopDong; }
            set { SetPropertyValue("thoiHanHopDong", ref fThoiHanHopDong, value); }
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