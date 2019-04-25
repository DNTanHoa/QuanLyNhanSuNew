using DevExpress.Xpo;
using DevExpress.ExpressApp.DC;
namespace QuanLyNhanSu.Module.BusinessObjects
{
    [Persistent(@"LoaiTangCa")]
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
        int fHeSoNhanGio;
        [XafDisplayName("Hệ Số Nhân Giờ")]
        public int heSoNhanGio
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