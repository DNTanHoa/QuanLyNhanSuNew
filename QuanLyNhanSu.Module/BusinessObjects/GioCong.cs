using DevExpress.ExpressApp.ConditionalAppearance;
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
    [Persistent(@"GioCong")]
    [XafDisplayName("Bảng Giờ Công")]
    [XafDefaultProperty("nguoiChamCong")]
    [Appearance("diTreSang", BackColor = "red", FontColor = "white", Context = "ListView", TargetItems = "thoiGianVaoCa", Criteria = "diTreSang = true")]
    [Appearance("diTreChieu", BackColor = "red", FontColor = "white", Context = "ListView", TargetItems = "thoiGianVaoGiuaCa", Criteria = "diTreChieu = true")]
    [Appearance("veSomSang", BackColor = "red", FontColor = "white", Context = "ListView", TargetItems = "thoiGianRaGiuaCa", Criteria = "veSomSang = true")]
    [Appearance("veSomChieu", BackColor = "red", FontColor = "white", Context = "ListView", TargetItems = "thoiGianTanCa", Criteria = "veSomChieu = true")]
    [Appearance("soLanVeSom", BackColor = "red", FontColor = "white", Context = "ListView", TargetItems = "soLanVeSom", Criteria = "soLanVeSom != 0")]
    [Appearance("duyetTangCa", BackColor = "red", FontColor = "white", Context = "ListView", TargetItems = "soGioTangCa", Criteria = "duyetTangCa = false")]
    public class GioCong : XPLiteObject
    {
        public GioCong(Session session) : base(session) { }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
        }
        protected override void OnLoaded()
        {
            base.OnLoaded();
            this.thoiGianVaoCaSaved = this.thoiGianVaoCa;
            this.thoiGianRaGiuaCaSaved = this.thoiGianRaGiuaCa;
            this.fThoiGianVaoGiuaCaSaved = this.thoiGianVaoGiuaCa;
            this.thoiGianTanCaSaved = this.thoiGianTanCa;
            this.soGioCoBanSaved = this.soGioCoBan;
            this.soGioDiTreSaved = this.soGioDiTre;
            this.soGioVeSomSaved = this.soGioVeSom;
            this.soGioDauCaSaved = this.soGioDauCa;
            this.soGioCuoiCaSaved = this.soGioCuoiCa;
            Session.CommitTransaction();
        }
        protected override void EndEdit()
        {
            base.EndEdit();
            GioCong.AutoSaveOnEndEdit = true;
        }
        protected override void OnChanged(string propertyName, object oldValue, object newValue)
        {
            base.OnChanged(propertyName, oldValue, newValue);
            AutoSaveOnEndEdit = true;
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
        [XafDisplayName("Tên Nhân Viên")]
        public NhanVien nguoiChamCong
        {
            get { return fNguoiChamCong; }
            set { SetPropertyValue("nguoiChamCong", ref fNguoiChamCong, value); }
        }
        NgayTinhCong fNgay;
        [ModelDefault("DisplayFormat", "{0:dd/MM/yyyy}")]
        [ModelDefault("EditMask", "dd/MM/yyyy")]
        [Association(@"NgayChamCong-GioCong")]
        [XafDisplayName("Ngày Chấm Công")]
        public NgayTinhCong ngay
        {
            get { return fNgay; }
            set { SetPropertyValue("ngay", ref fNgay, value); }
        }
        [XafDisplayName("Số Lần Chấm Công")]
        public int? soLanQuet
        {
            get
            {
                return this.checkInOuts.Count;
            }
        }
        DateTime? fThoiGianVaoCaSaved;
        [VisibleInDetailView(false)]
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        public DateTime? thoiGianVaoCaSaved
        {
            get => fThoiGianVaoCaSaved;
            set => SetPropertyValue("thoiGianVaoCaSaved", ref fThoiGianVaoCaSaved, value);
        }
        DateTime? fThoiGianRaGiuaCaSaved;
        [VisibleInDetailView(false)]
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        public DateTime? thoiGianRaGiuaCaSaved
        {
            get => fThoiGianRaGiuaCaSaved;
            set => SetPropertyValue("thoiGianRaGiuaCaSaved", ref fThoiGianRaGiuaCaSaved, value);
        }
        DateTime? fThoiGianVaoGiuaCaSaved;
        [VisibleInDetailView(false)]
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        public DateTime? thoiGianVaoGiuaCaSaved
        {
            get => fThoiGianVaoGiuaCaSaved;
            set => SetPropertyValue("thoiGianVaoGiuaCaSaved", ref fThoiGianVaoGiuaCaSaved, value);
        }
        DateTime? fThoiGianTanCaSaved;
        [VisibleInDetailView(false)]
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        public DateTime? thoiGianTanCaSaved
        {
            get => fThoiGianTanCaSaved;
            set => SetPropertyValue("thoiGianTanCaSaved", ref fThoiGianTanCaSaved, value);
        }
        double? fSoGioCoBanSaved;
        [VisibleInDetailView(false)]
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        public double? soGioCoBanSaved
        {
            get => fSoGioCoBanSaved;
            set => SetPropertyValue("soGioCoBanSaved", ref fSoGioCoBanSaved, value);
        }
        double? fSoGioDiTreSaved;
        [VisibleInDetailView(false)]
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        public double? soGioDiTreSaved
        {
            get => fSoGioDiTreSaved;
            set => SetPropertyValue("soGioDiTreSaved", ref fSoGioDiTreSaved, value);
        }
        double? fSoGioVeSomSaved;
        [VisibleInDetailView(false)]
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        public double? soGioVeSomSaved
        {
            get => fSoGioVeSomSaved;
            set => SetPropertyValue("soGioVeSomSaved", ref fSoGioVeSomSaved, value);
        }
        double? fSoGioDauCaSaved;
        [VisibleInDetailView(false)]
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        public double? soGioDauCaSaved
        {
            get => fSoGioDauCaSaved;
            set => SetPropertyValue("soGioDauCaSaved", ref fSoGioDauCaSaved, value);
        }
        double? fSoGioCuoiCaSaved;
        [VisibleInDetailView(false)]
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        public double? soGioCuoiCaSaved
        {
            get => fSoGioCuoiCaSaved;
            set => SetPropertyValue("soGioCuoiCaSaved", ref fSoGioCuoiCaSaved, value);
        }
        [XafDisplayName("Thời Gian Vào Ca")]
        [ModelDefault("DisplayFormat", "{0:HH:mm}")]
        [ModelDefault("EditMask", "{HH:mm}")]
        public DateTime? thoiGianVaoCa
        {
            get
            {
                if(!Equals(this.thoiGianVaoCaSaved,null))
                {
                    return this.thoiGianVaoCaSaved;
                }
                else
                {
                    if (!Equals(this.nguoiChamCong, null))
                    {
                        IEnumerable<CheckInOut> gioVaoCa = this.checkInOuts.Where(p => p.loaiChamCong == CheckInOut.LoaiGio.vaodauca);
                        if (gioVaoCa.Min() != null)
                        {
                            return gioVaoCa.Min().GioCham;
                        }
                        else return null;
                    }
                    else
                    {
                        return null;
                    }
                }
                
            }
        }
        [XafDisplayName("Thời Gian Ra Giữa Ca")]
        [ModelDefault("DisplayFormat", "{0:HH:mm}")]
        [ModelDefault("EditMask", "{HH:mm}")]
        public DateTime? thoiGianRaGiuaCa
        {
            get
            {
                if(!Equals(this.thoiGianRaGiuaCaSaved,null))
                {
                    return this.thoiGianRaGiuaCaSaved;
                }
                else
                {
                    if (!Equals(this.nguoiChamCong, null))
                    {
                        IEnumerable<CheckInOut> gioRaGiuaCa = this.checkInOuts.Where(p => p.loaiChamCong == CheckInOut.LoaiGio.ravaogiuaca);
                        if (gioRaGiuaCa.Min() != null)
                        {
                            return gioRaGiuaCa.Min().GioCham;
                        }
                        else return null;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }
        [XafDisplayName("Thời Gian Vào Giữa Ca")]
        [ModelDefault("DisplayFormat", "{0:HH:mm}")]
        [ModelDefault("EditMask", "{HH:mm}")]
        public DateTime? thoiGianVaoGiuaCa
        {
            get
            {
                if(!Equals(this.thoiGianVaoGiuaCaSaved,null))
                {
                    return this.thoiGianVaoGiuaCaSaved;
                }
                else
                {
                    if (!Equals(this.nguoiChamCong, null))
                    {
                        IEnumerable<CheckInOut> gioVaoGiuaCa = this.checkInOuts.Where(p => p.loaiChamCong == CheckInOut.LoaiGio.ravaogiuaca);
                        if (gioVaoGiuaCa.Max() != null)
                        {
                            return gioVaoGiuaCa.Max().GioCham;
                        }
                        else return null;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }
        [XafDisplayName("Thời Gian Tan Ca")]
        [ModelDefault("DisplayFormat", "{0:HH:mm}")]
        [ModelDefault("EditMask", "{HH:mm}")]
        public DateTime? thoiGianTanCa
        {
            get
            { 
                if(!Equals(this.thoiGianTanCaSaved,null))
                {
                    return this.thoiGianTanCaSaved;
                }
                else
                {
                    if (!Equals(this.nguoiChamCong, null))
                    {
                        IEnumerable<CheckInOut> gioTanCa = this.checkInOuts.Where(p => p.loaiChamCong == CheckInOut.LoaiGio.tanca);
                        if (gioTanCa.Min() != null)
                        {
                            return gioTanCa.Min().GioCham;
                        }
                        else return null;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }
        [VisibleInDetailView(false)]
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        public double? soGioDauCa
        {
            get
            {
                if(!Equals(this.soGioDauCaSaved,null) && this.soGioDauCaSaved != 0)
                {
                    return this.soGioDauCaSaved;
                }
                else
                {
                    double soGio = 0;
                    if ((!Equals(this.thoiGianVaoCa, null)) && (!Equals(this.thoiGianRaGiuaCa, null)))
                    {
                        soGio = tinhSoGioCong(this.nguoiChamCong, (DateTime)this.thoiGianVaoCa, (DateTime)this.thoiGianRaGiuaCa, (DateTime)this.nguoiChamCong.caLamViec.thoiGianVao, (DateTime)this.nguoiChamCong.caLamViec.thoiGianRaGiuaCa);
                    }
                    return soGio;
                }
            }
        }
        [VisibleInDetailView(false)]
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        public double? soGioCuoiCa
        {
            get
            {
                if (!Equals(this.soGioCuoiCaSaved, null) && this.soGioCuoiCaSaved != 0)
                {
                    return this.soGioCuoiCaSaved;
                }
                else
                {
                    double soGio = 0;
                    if ((!Equals(this.thoiGianVaoGiuaCa, null)) && (!Equals(this.thoiGianTanCa, null)))
                    {
                        soGio = tinhSoGioCong(this.nguoiChamCong, (DateTime)this.thoiGianVaoGiuaCa, (DateTime)this.thoiGianTanCa, (DateTime)this.nguoiChamCong.caLamViec.thoiGianVaoGiuaCa, (DateTime)this.nguoiChamCong.caLamViec.thoiGianTanCa);
                    }
                    return soGio;
                }
            }
        }
        [XafDisplayName("Số Giờ Cơ Bản")]
        public double? soGioCoBan
        {
            get
            {
                //if (!Equals(this.soGioCoBanSaved, null) && this.soGioCoBanSaved != 0)
                //{
                //    return this.soGioCoBanSaved;
                //}
                //else
                //{
                return this.soGioDauCa + this.soGioCuoiCa;
               // }
            }
        }
        [VisibleInDetailView(false)]
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        public bool diTreSang
        {
            get
            {
                bool lanDiTre = false;
                if (!Equals(this.thoiGianVaoCa, null))
                {
                    lanDiTre = tinhSoLanDiTre(this.nguoiChamCong, (DateTime)this.thoiGianVaoCa, this.nguoiChamCong.caLamViec.thoiGianVao);
                }
                return lanDiTre;
            }
        }
        [VisibleInDetailView(false)]
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        public bool diTreChieu
        {
            get
            {
                bool lanDiTre = false;
                if (!Equals(this.thoiGianVaoGiuaCa, null))
                {
                    lanDiTre = tinhSoLanDiTre(this.nguoiChamCong, (DateTime)this.thoiGianVaoGiuaCa, this.nguoiChamCong.caLamViec.thoiGianVaoGiuaCa);
                }
                return lanDiTre;
            }
        }
        [XafDisplayName("Số Giờ Đi Trễ")]
        public double? soGioDiTre
        {
            get
            {
                if (!Equals(this.soGioDiTreSaved, null) && this.soGioDiTreSaved != 0)
                {
                    return this.soGioDiTreSaved;
                }
                else
                {
                    double soGioDiTreDauCa = 0;
                    double soGioDiTreGiuaCa = 0;
                    if (!Equals(this.thoiGianVaoCa, null))
                    {
                        soGioDiTreDauCa = tinhSoGioDiTre(this.nguoiChamCong, (DateTime)this.thoiGianVaoCa, this.nguoiChamCong.caLamViec.thoiGianVao);
                    }
                    if (!Equals(this.thoiGianVaoGiuaCa, null))
                    {
                        soGioDiTreGiuaCa = tinhSoGioDiTre(this.nguoiChamCong, (DateTime)this.thoiGianVaoGiuaCa, this.nguoiChamCong.caLamViec.thoiGianVaoGiuaCa);
                    }
                    return soGioDiTreDauCa + soGioDiTreGiuaCa;
                }
            }
        }
        [VisibleInDetailView(false)]
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        public bool veSomSang
        {
            get
            {
                bool lanVeSom = false;
                if (!Equals(this.thoiGianRaGiuaCa, null))
                {
                    lanVeSom = tinhSoLanVeSom(this.nguoiChamCong, (DateTime)this.thoiGianRaGiuaCa, this.nguoiChamCong.caLamViec.thoiGianRaGiuaCa);
                }
                return lanVeSom;
            }
        }
        [VisibleInDetailView(false)]
        [VisibleInListView(false)]
        [VisibleInLookupListView(false)]
        public bool veSomChieu
        {
            get
            {
                bool lanVeSom = false;
                if (!Equals(this.thoiGianTanCa, null))
                {
                    lanVeSom = tinhSoLanVeSom(this.nguoiChamCong, (DateTime)this.thoiGianTanCa, this.nguoiChamCong.caLamViec.thoiGianTanCa);
                }
                return lanVeSom;
            }
        }
        [XafDisplayName("Số Giờ Về Sớm")]
        public double? soGioVeSom
        {
            get
            {
                if (!Equals(this.soGioVeSomSaved, null) && this.soGioVeSomSaved != 0)
                {
                    return this.soGioVeSomSaved;
                }
                else
                {
                    double soGioVeSomGiuaCa = 0;
                    double soGioVeSomCuoiCa = 0;
                    if (!Equals(this.thoiGianRaGiuaCa, null))
                    {
                        soGioVeSomGiuaCa = tinhSoGioVeSom(this.nguoiChamCong, (DateTime)this.thoiGianRaGiuaCa, (DateTime)this.nguoiChamCong.caLamViec.thoiGianRaGiuaCa);
                    }
                    if (!Equals(this.thoiGianTanCa, null))
                    {
                        soGioVeSomCuoiCa = tinhSoGioVeSom(this.nguoiChamCong, (DateTime)this.thoiGianTanCa, (DateTime)this.nguoiChamCong.caLamViec.thoiGianTanCa);
                    }
                    return soGioVeSomGiuaCa + soGioVeSomCuoiCa;
                }
            }
        }
        double fSoGioTangCa;
        [XafDisplayName("Số Giờ Tăng Ca")]
        public double soGioTangCa
        {
            get { return fSoGioTangCa; }
            set { SetPropertyValue("soGioTangCa", ref fSoGioTangCa, value); }
        }
        bool? fDuyetTangCa;
        [XafDisplayName("Duyệt Tăng Ca")]
        [VisibleInDetailView(false)]
        [VisibleInListView(false)]
        public bool? duyetTangCa
        {
            get { return fDuyetTangCa; }
            set { SetPropertyValue("duyetTangCa", ref fDuyetTangCa, value); }
        }
        [Association(@"GioCong-CheckInOut")]
        [XafDisplayName("Lần Chấm Công")]
        public XPCollection<CheckInOut> checkInOuts { get { return GetCollection<CheckInOut>("checkInOuts"); } }
        [Association(@"GiocCong-LanTangCa")]
        [XafDisplayName("Lần Tăng Ca")]
        public XPCollection<LanTangCa> lanTangCas { get { return GetCollection<LanTangCa>("lanTangCas"); } }
        [Association(@"GioCong-LanXinDiTre")]
        [XafDisplayName("Lần Xin Đi Trễ")]
        public XPCollection<LanXinDiTre> lanXinDiTres { get { return GetCollection<LanXinDiTre>("lanXinDiTres"); } }
        /*
         * Đây là chương trình tính giờ của nhân viên
         * Input: thông tin nhân viên, thời gian vào ca, thời gian ra ca đó, thời gian theo ca làm việc
         * Author: Đình Tri
         * Date: 08/05/2019
         */
        private double tinhSoGioCong(NhanVien nhanVien, DateTime thoiGianVao, DateTime thoiGianRa, DateTime thoiGianVaoHopLe, DateTime thoiGianRaHopLe)
        {
            double soGioCong = 0;
            TimeSpan tongSoGio = TimeSpan.Zero;
            DateTime vaoHopLe = new DateTime(thoiGianVao.Year, thoiGianVao.Month, thoiGianVao.Day, thoiGianVaoHopLe.Hour, thoiGianVaoHopLe.Minute, 0);
            DateTime raHopLe = new DateTime(thoiGianRa.Year, thoiGianRa.Month, thoiGianRa.Day, thoiGianRaHopLe.Hour, thoiGianRaHopLe.Minute, 0);
            if(DateTime.Compare(thoiGianVao,vaoHopLe) <= 0)
            {
                thoiGianVao = vaoHopLe;
            }
            if(DateTime.Compare(thoiGianRa, raHopLe) >= 0)
            {
                thoiGianRa = raHopLe;
            }
            tongSoGio = thoiGianRa - thoiGianVao;
            soGioCong = tongSoGio.TotalMinutes / 60;
            soGioCong = Math.Round(soGioCong, 2);
            return soGioCong;
        }
        /*
         * Đây là chương trình tính thời gian đi trễ của nhân viên
         * Input: thông tin nhân viên, thời gian vào đầu ca, thời gian giữa ca
         * Author: Đình Tri
         * Date: 01/05/2019
         */
         private double tinhSoGioDiTre(NhanVien nhanVien, DateTime thoiGianVao, DateTime thoiGianHopLe)
         {
            double soGioDiTre = 0;
            TimeSpan gioDiTre = TimeSpan.Zero;
            DateTime thoiGianVaoHopLe = new DateTime(thoiGianVao.Year, thoiGianVao.Month, thoiGianVao.Day, thoiGianHopLe.Hour, thoiGianHopLe.Minute, 0);
            if(DateTime.Compare(thoiGianVao, thoiGianVaoHopLe) <= 0)
            {
                return soGioDiTre;
            }
            else
            {
                gioDiTre = thoiGianVao - thoiGianVaoHopLe;
                soGioDiTre = Math.Round(gioDiTre.TotalMinutes / 60,2);
                if(gioDiTre.TotalMinutes >= 4)
                {
                    return soGioDiTre;
                }
                else
                {
                    return 0;
                }
            }
         }
        /*
         * Đây là chương trình tính thời gian về sớm của nhân viên
         * Input: thông tin nhân viên, thời gian vào đầu ca, thời gian giữa ca
         * Author: Đình Tri
         * Date: 01/05/2019
         */
        private double tinhSoGioVeSom(NhanVien nhanVien, DateTime thoiGianVe, DateTime thoiGianHetCa)
        {
            double soGioVeSom = 0;
            DateTime thoiGianHopLe = new DateTime(thoiGianVe.Year, thoiGianVe.Month, thoiGianVe.Day, thoiGianHetCa.Hour, thoiGianHetCa.Minute, 0);
            TimeSpan gioVeSom = TimeSpan.Zero;
            if(DateTime.Compare(thoiGianVe, thoiGianHopLe) > 0)
            {
                return soGioVeSom;
            }
            else
            {
                gioVeSom = thoiGianHopLe - thoiGianVe;
                soGioVeSom = Math.Round(gioVeSom.TotalMinutes / 60, 2);
                return soGioVeSom;
            }
        }
        /*
         * Đây là chương trình tính số lần đi trễ của nhân viên
         * Input: thông tin nhân viên, thời gian vào đầu ca, thời gian ca làm việc
         * Author: Đình Tri
         * Date: 02/05/2019
         */
        private bool tinhSoLanDiTre(NhanVien nhanVien, DateTime thoiGianVao, DateTime thoiGianCaLamViec)
        {
            bool soLanTre = false;
            TimeSpan soGio = TimeSpan.Zero;
            DateTime thoiGianHopLe = new DateTime(thoiGianVao.Year, thoiGianVao.Month, thoiGianVao.Day, thoiGianCaLamViec.Hour, thoiGianCaLamViec.Minute, 0);
            if(DateTime.Compare(thoiGianVao, thoiGianHopLe) > 0)
            {
                if((thoiGianVao - thoiGianHopLe).TotalMinutes >= 4)
                {
                    soLanTre = true;
                }
            }
            return soLanTre;
        }
        /*
         * Đây là chương trình tính số lần về sớm của nhân viên
         * Input: thông tin nhân viên, thời gian ra khỏi ca, thời gian ca làm việc
         * Author: Đình Tri
         * Date: 02/05/2019
         */
        private bool tinhSoLanVeSom(NhanVien nhanVien, DateTime thoiGianRa, DateTime thoiGianCaLamViec)
        {
            bool soLanSom = false;
            DateTime thoiGianHopLe = new DateTime(thoiGianRa.Year, thoiGianRa.Month, thoiGianRa.Day, thoiGianCaLamViec.Hour, thoiGianCaLamViec.Minute, 0);
            if (DateTime.Compare(thoiGianRa, thoiGianHopLe) < 0)
            {
                soLanSom = true;
            }
            return soLanSom;
        }
    }
}
