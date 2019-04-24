using DevExpress.ExpressApp.DC;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhanSu.Module.BusinessObjects
{
    [XafDisplayName("Danh Mục Ngày Lễ")]
    [Persistent("NgayLe")]
    [XafDefaultProperty("tenNgayLe")]
    public class NgayLe : XPLiteObject
    {
        public NgayLe(Session session) : base(session) { }
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
        string fTenNgayLe;
        [XafDisplayName("Tên Ngày Lễ")]
        public string tenNgayLe
        {
            get { return fTenNgayLe; }
            set { SetPropertyValue("tenNgayLe", ref fTenNgayLe, value); }
        }
        DateTime fngayBatDauNghi;
        [XafDisplayName("Ngày Bắt Đầu Nghỉ")]
        public DateTime ngayBatDauNghi
        {
            get { return fngayBatDauNghi; }
            set { SetPropertyValue("ngayBatDauNghi", ref fngayBatDauNghi, value); }
        }
        int? fSoNgayNghi;
        [XafDisplayName("Số Ngày Nghỉ")]
        public int? soNgayNghi
        {
            get { return fSoNgayNghi; }
            set { SetPropertyValue("soNgayNghi", ref fSoNgayNghi, value); }
        }
   
        [XafDisplayName("Ngày Kết Thúc")]
        public DateTime? ngayKetThuc
        {
            get
            {
                if(!Equals(this.ngayBatDauNghi,null) && !Equals(this.soNgayNghi, null))
                {
                    return this.ngayBatDauNghi.AddDays((int)this.soNgayNghi-1);
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
    }
}
