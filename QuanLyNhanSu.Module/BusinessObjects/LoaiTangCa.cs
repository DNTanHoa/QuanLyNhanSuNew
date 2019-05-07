using DevExpress.Xpo;
using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;

namespace QuanLyNhanSu.Module.BusinessObjects
{
    [XafDefaultProperty("tenLoaiTangCa")]
    [Persistent(@"LoaiTangCa")]
    [XafDisplayName("Loại Tăng Ca")]
    public class LoaiTangCa : XPLiteObject
    {
        public LoaiTangCa(Session session) : base(session) { }
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
            set { SetPropertyValue<int>("Id", ref fId, value); }
        }
        string fTenLoaiTangCa;
        [XafDisplayName("Loại Tăng Ca")]
        public string tenLoaiTangCa
        {
            get { return fTenLoaiTangCa; }
            set { SetPropertyValue("tenLoaiTangCa", ref fTenLoaiTangCa, value); }
        }
        double fHeSoNhanGio;
        [XafDisplayName("Hệ Số Nhân Giờ")]
        public double heSoNhanGio
        {
            get { return fHeSoNhanGio; }
            set { SetPropertyValue("heSoNhanGio", ref fHeSoNhanGio, value); }
        }
        string fGhiChu;
        [XafDisplayName("Ghi Chú")]
        public string ghiChu
        {
            get { return fGhiChu; }
            set { SetPropertyValue<string>("ghiChu", ref fGhiChu, value); }
        }
    }
}