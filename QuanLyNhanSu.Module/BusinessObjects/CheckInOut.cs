using DevExpress.ExpressApp.DC;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhanSu.Module.BusinessObjects
{
    [Persistent(@"ChecKInOut")]
    [XafDisplayName("Giờ Chấm Công")]
    public class CheckInOut : XPLiteObject
    {
        public CheckInOut(Session session) : base(session) { }
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
        NhanVien fNguoiChamCong;
        [XafDisplayName("Người Chấm Công")]
        [Association(@"NhanVien-CheckInOut")]
        public NhanVien nguoiChamCong
        {
            get { return fNguoiChamCong; }
            set { SetPropertyValue("nguoiChamCong", ref fNguoiChamCong, value); }
        }
        DateTime fThoiGianChamCong;
        [XafDisplayName("Thời Gian Chấm Công")]
        public DateTime thoiGianChamCong
        {
            get { return fThoiGianChamCong; }
            set { SetPropertyValue("thoiGianChamCong", ref fThoiGianChamCong, value); }
        }
    }
}
