using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
using DevExpress.Xpo;
using System;
using System.ComponentModel;

namespace QuanLyNhanSu.Module.BusinessObjects
{
    [Persistent(@"CaLamViec")]
    [DefaultProperty("tenCaLamviec")]
    public class CaLamViec : XPLiteObject
    {
        public CaLamViec(Session session) : base(session) { }
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
        string fTenCaLamViec;
        [XafDisplayName("Tên Ca Làm Việc")]
        public string tenCaLamviec
        {
            get { return fTenCaLamViec; }
            set { SetPropertyValue("tenCaLamViec", ref fTenCaLamViec, value); }
        }
        DateTime fThoiGianVao;
        [XafDisplayName("Thời Gian Vào")]
        [ModelDefault("DisplayFormat","{0:HH:mm}")]
        [ModelDefault("EditMask", "{HH:mm}")]
        public DateTime thoiGianVao
        {
            get { return fThoiGianVao; }
            set { SetPropertyValue("thoiGianVao", ref fThoiGianVao, value); }
        }
        DateTime fThoiGianRaGiuaCa;
        [XafDisplayName("Thời Gian Ra Giữa Ca")]
        [ModelDefault("DisplayFormat", "{0:HH:mm}")]
        [ModelDefault("EditMask", "{HH:mm}")]
        public DateTime thoiGianRaGiuaCa
        {
            get { return fThoiGianRaGiuaCa; }
            set { SetPropertyValue("thoiGianRaGiuaCa", ref fThoiGianRaGiuaCa, value); }
        }
        DateTime fThoiGianVaoGiuaCa;
        [XafDisplayName("Thời Gian Vào Giữa Ca")]
        [ModelDefault("DisplayFormat", "{0:HH:mm}")]
        [ModelDefault("EditMask", "{HH:mm}")]
        public DateTime thoiGianVaoGiuaCa
        {
            get { return fThoiGianVaoGiuaCa; }
            set { SetPropertyValue("thoiGianVaoGiuaCa", ref fThoiGianVaoGiuaCa, value); }
        }
        DateTime fThoiGianTanCa;
        [XafDisplayName("Thời Gian Tan Ca")]
        [ModelDefault("DisplayFormat", "{0:HH:mm}")]
        [ModelDefault("EditMask", "{HH:mm}")]
        public DateTime thoiGianTanCa
        {
            get { return fThoiGianTanCa; }
            set { SetPropertyValue("thoiGianTanCa", ref fThoiGianTanCa, value); }
        }
        double fHeSoNhan;
        [XafDisplayName("Hệ Số Nhân")]
        public double heSoNhan
        {
            get { return fHeSoNhan; }
            set { SetPropertyValue("heSoNhan", ref fHeSoNhan, value); }
        }
        TimeSpan fThoiGianCongThem;
        [XafDisplayName("Thời Gian Cộng Thêm")]
        public TimeSpan thoiGianCongThem
        {
            get { return fThoiGianCongThem; }
            set { SetPropertyValue("thoiGianCongThem", ref fThoiGianCongThem, value); }
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