using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhanSu.Module.BusinessObjects
{
    [DefaultClassOptions]
    [Persistent(@"CheckInOut2")]
    [XafDisplayName("Giờ Chấm Công")]
    public class CheckInOut2 : XPLiteObject
    {
        public CheckInOut2(Session session) : base(session) { }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }
        protected override void OnLoaded()
        {
            base.OnLoaded();
            //IEnumerable<CheckInOut> checkInOuts = 
        }
        int fId;
        [Key(true)]
        [XafDisplayName("STT")]
        public int Id
        {
            get { return fId; }
            set { SetPropertyValue("Id", ref fId, value); }
        }
        NhanVien fNguoiChamCong;
        [XafDisplayName("Người Chấm Công")]
        [Association(@"NhanVien-CheckInOut")]
        public NhanVien nguoiChamCong
        {
            get { return fNguoiChamCong; }
            set { SetPropertyValue("nguoiChamCong", ref fNguoiChamCong, value); }
        }
        int fMaChamCong;
        [XafDisplayName("Mã Chấm Công")]
        public int MaChamCong
        {
            get { return fMaChamCong; }
            set { SetPropertyValue("MaChamCong", ref fMaChamCong, value); }
        }
        DateTime fNgayCham;
        [XafDisplayName("Ngày Chấm")]
        public DateTime NgayCham
        {
            get { return fNgayCham; }
            set { SetPropertyValue("NgayCham", ref fNgayCham, value); }
        }
        DateTime fGioCham;
        [XafDisplayName("Giờ Chấm")]
        public DateTime GioCham
        {
            get { return fGioCham; }
            set { SetPropertyValue("GioCham", ref fGioCham, value); }
        }
        int fKieuCham;
        [XafDisplayName("Kiểu Chấm")]
        public int KieuCham
        {
            get { return fKieuCham; }
            set { SetPropertyValue("KieuCham", ref fKieuCham, value); }
        }
        int fNguonCham;
        [XafDisplayName("Nguồn Chấm")]
        public int NguonCham
        {
            get { return fNguonCham; }
            set { SetPropertyValue("NguonCham", ref fNguonCham, value); }
        }
        int fMaSoMay;
        [XafDisplayName("Mã Số Máy")]
        public int MaSoMay
        {
            get { return fMaSoMay; }
            set { SetPropertyValue("MaSoMay", ref fMaSoMay, value); }
        }
        string fTenMay;
        public string TenMay
        {
            get { return fTenMay; }
            set { SetPropertyValue("TenMay", ref fTenMay, value); }
        }
    }
}
