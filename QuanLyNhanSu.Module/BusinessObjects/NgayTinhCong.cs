using DevExpress.Data.Filtering;
using DevExpress.ExpressApp.ConditionalAppearance;
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
    [XafDisplayName("Ngày Tính Công")]
    [Persistent(@"NgayTinhCong")]
    [XafDefaultProperty("ngayChamCong")]
    [Appearance("IsSunday",BackColor = "olive", FontColor ="white",Context ="ListView", TargetItems ="ngayChamCong", Criteria ="IsSunDay = true")]
    [Appearance("IsHoliday", BackColor = "darkgreen", FontColor = "white", Context = "ListView", TargetItems = "ngayChamCong", Criteria = "IsHoliday = true")]
    public class NgayTinhCong : XPLiteObject
    {
        public NgayTinhCong(Session session) : base(session) { }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }
        protected override void OnSaving()
        {
            base.OnSaving();
            if(Equals(this.ngayChamCong,null))
            {
                this.Delete();
            }
        }
        int fId;
        [Key(true)]
        [XafDisplayName("STT")]
        public int Id
        {
            get { return fId; }
            set { SetPropertyValue("Id", ref fId, value); }
        }
        DateTime fNgayChamCong;
        [XafDisplayName("Ngày Chấm Công")]
        public DateTime ngayChamCong
        {
            get { return fNgayChamCong; }
            set { SetPropertyValue("ngayChamCong", ref fNgayChamCong, value); }
        }
        [VisibleInListView(false)]
        [VisibleInDetailView(false)]
        [XafDisplayName("Ngày Chủ Nhật")]
        public bool? IsSunDay
        {
            get
            {
                if(!Equals(this.ngayChamCong,null))
                {
                    DateTime ngay = Convert.ToDateTime(this.ngayChamCong);
                    if(ngay.DayOfWeek == 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return null;
                }
            }
        }
        [VisibleInListView(false)]
        [VisibleInDetailView(false)]
        public bool? IsHoliday
        {
            get
            {
                if (!Equals(this.ngayChamCong, null))
                {
                    string condition = CriteriaOperator.And(CriteriaOperator.Parse("[ngayBatDauNghi] <= ?",this.ngayChamCong),CriteriaOperator.Parse("[ngayKetThuc] >= ?",this.ngayChamCong)).ToString();
                    CriteriaOperator criteria = CriteriaOperator.Parse(condition);
                    NgayLe ngayLe = Session.FindObject<NgayLe>(criteria);
                    if (Equals(ngayLe, null))
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                else
                {
                    return null;
                }
            }
        }
        [Association(@"NgayChamCong-GioCong")]
        [XafDisplayName("Giờ Công Nhân Viên")]
        public XPCollection<GioCong> gioCongs { get { return GetCollection<GioCong>("gioCongs"); } }
    }
}
