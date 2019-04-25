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
    [Appearance("soLanDiTre", BackColor = "red", FontColor = "white", Context = "ListView", TargetItems = "soLanDiTre", Criteria = "soLanDiTre != 0")]
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
                        List<CheckInOut> thoiGianVaoCas = new List<CheckInOut>();
                        DateTime thoiGianVaoHopLe = this.nguoiChamCong.caLamViec.thoiGianVao;
                        foreach (CheckInOut checkInOut in this.checkInOuts)
                        {
                            if ((checkInOut.GioCham.Hour >= (thoiGianVaoHopLe.Hour - 1)) && (checkInOut.GioCham.Hour <= (thoiGianVaoHopLe.Hour + 1)))
                            {
                                thoiGianVaoCas.Add(checkInOut);
                            }
                        }
                        if (thoiGianVaoCas != null)
                        {
                            CheckInOut checkIn = thoiGianVaoCas.FirstOrDefault();
                            if (checkIn != null)
                            {
                                //this.thoiGianVaoCaSaved = checkIn.GioCham;
                                //Session.CommitTransaction();
                                //Session.Reload();
                                return checkIn.GioCham;
                            }
                            else
                            {
                                return null;
                            }
                        }
                        else
                        {
                            return null;
                        }
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
                        List<CheckInOut> thoiGianRaGiuaCas = new List<CheckInOut>();
                        DateTime thoiGianRaHopLe = this.nguoiChamCong.caLamViec.thoiGianRaGiuaCa;
                        /*Lọc Danh Sách Các Lần chấm Công Hợp Lệ Trong Khung Giờ Quy Định*/
                        foreach (CheckInOut checkInOut in this.checkInOuts)
                        {
                            if ((checkInOut.GioCham.Hour >= (thoiGianRaHopLe.Hour - 1)) && (checkInOut.GioCham.Hour <= (thoiGianRaHopLe.Hour + 1)))
                            {
                                thoiGianRaGiuaCas.Add(checkInOut);
                            }
                        }
                        /*Trả Về Lần Quẹt Sớm Nhất*/
                        if (thoiGianRaGiuaCas != null)
                        {
                            CheckInOut checkIn = thoiGianRaGiuaCas.Min();
                            if (checkIn != null)
                            {
                                //this.thoiGianRaGiuaCaSaved = checkIn.GioCham;
                                //Session.CommitTransaction();
                                //Session.Reload();
                                return checkIn.GioCham;
                            }
                            else
                            {
                                return null;
                            }
                        }
                        else
                        {
                            return null;
                        }
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
                        List<CheckInOut> thoiGianVaoGiuaCas = new List<CheckInOut>();
                        DateTime thoiGianVaoGiuaCaHopLe = this.nguoiChamCong.caLamViec.thoiGianVaoGiuaCa;
                        foreach (CheckInOut checkInOut in this.checkInOuts)
                        {
                            if ((checkInOut.GioCham.Hour >= (thoiGianVaoGiuaCaHopLe.Hour - 2)) && (checkInOut.GioCham.Hour <= (thoiGianVaoGiuaCaHopLe.Hour + 1)))
                            {
                               thoiGianVaoGiuaCas.Add(checkInOut);
                            }
                        }
                        if (thoiGianVaoGiuaCas != null)
                        {
                            CheckInOut checkIn = thoiGianVaoGiuaCas.Max();
                            if (checkIn != null)
                            {
                                //this.thoiGianVaoGiuaCaSaved = checkIn.GioCham;
                                //Session.CommitTransaction();
                                return checkIn.GioCham;
                            }
                            else
                            {
                                return null;
                            }
                        }
                        else
                        {
                            return null;
                        }
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
                        List<CheckInOut> thoiGianTanCas = new List<CheckInOut>();
                        DateTime thoiGianTanCaHopLe = this.nguoiChamCong.caLamViec.thoiGianTanCa;
                        /*Lọc Danh Sách Các Lần chấm Công Hợp Lệ Trong Khung Giờ Quy Định*/
                        foreach (CheckInOut checkInOut in this.checkInOuts)
                        {
                            if ((checkInOut.GioCham.Hour >= (thoiGianTanCaHopLe.Hour - 1)) && (checkInOut.GioCham.Hour <= (thoiGianTanCaHopLe.Hour + 5)))
                            {
                                thoiGianTanCas.Add(checkInOut);
                            }
                        }
                        /*Trả Về Lần Quẹt Trễ Nhất*/
                        if (thoiGianTanCas != null)
                        {
                            CheckInOut checkIn = thoiGianTanCas.LastOrDefault();
                            if (checkIn != null)
                            {
                                //this.thoiGianTanCaSaved = checkIn.GioCham;
                                //Session.CommitTransaction();
                                return checkIn.GioCham;
                            }
                            else
                            {
                                return null;
                            }
                        }
                        else
                        {
                            return null;
                        }
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }
        [XafDisplayName("Số Giờ Cơ Bản")]
        public double? soGioCoBan
        {
            get
            {
                double soGioDauCa = 0;
                double soGioCuoiCa = 0;
                if ((!Equals(this.thoiGianVaoCa,null)) && (!Equals(this.thoiGianRaGiuaCa,null)))
                {
                    soGioDauCa = tinhSoGioCongDauCa(this.nguoiChamCong, (DateTime)this.thoiGianVaoCa, (DateTime)this.thoiGianRaGiuaCa);
                }
                if((!Equals(this.thoiGianVaoGiuaCa,null)) && (!Equals(this.thoiGianTanCa,null)))
                {
                    soGioCuoiCa = tinhSoGioCongCuoiCa(this.nguoiChamCong, (DateTime)this.thoiGianVaoGiuaCa, (DateTime)this.thoiGianTanCa);
                }
                return soGioDauCa + soGioCuoiCa;
            }
        }
        [XafDisplayName("Số Lần Đi Trễ")]
        public int soLanDiTre
        {
            get
            {
                int lanDiTre = 0;
                if (!Equals(this.thoiGianVaoCa, null))
                {
                    lanDiTre += tinhSoLanDiTre(this.nguoiChamCong, (DateTime)this.thoiGianVaoCa, this.nguoiChamCong.caLamViec.thoiGianVao);
                }
                if(!Equals(this.thoiGianVaoGiuaCa, null))
                {
                    lanDiTre += tinhSoLanDiTre(this.nguoiChamCong, (DateTime)this.thoiGianVaoGiuaCa, this.nguoiChamCong.caLamViec.thoiGianVaoGiuaCa);
                }
                return lanDiTre;
            }
        }
        [XafDisplayName("Số Giờ Đi Trễ")]
        public double? soGioDiTre
        {
            get
            {
                double soGioDiTreDauCa = 0;
                double soGioDiTreGiuaCa = 0;
                if(!Equals(this.thoiGianVaoCa, null))
                {
                    soGioDiTreDauCa = tinhSoGioDiTre(this.nguoiChamCong, (DateTime)this.thoiGianVaoCa, this.nguoiChamCong.caLamViec.thoiGianVao);
                }
                if(!Equals(this.thoiGianVaoGiuaCa, null))
                {
                    soGioDiTreGiuaCa = tinhSoGioDiTre(this.nguoiChamCong, (DateTime)this.thoiGianVaoGiuaCa, this.nguoiChamCong.caLamViec.thoiGianVaoGiuaCa);
                }
                return soGioDiTreDauCa + soGioDiTreGiuaCa;
            }
        }
        [XafDisplayName("Số Lần Về Sớm")]
        public int soLanVeSom
        {
            get
            {
                int lanVeSom = 0;
                if (!Equals(this.thoiGianRaGiuaCa, null))
                {
                    lanVeSom += tinhSoLanVeSom(this.nguoiChamCong, (DateTime)this.thoiGianRaGiuaCa, this.nguoiChamCong.caLamViec.thoiGianRaGiuaCa);
                }
                if (!Equals(this.thoiGianTanCa, null))
                {
                    lanVeSom += tinhSoLanVeSom(this.nguoiChamCong, (DateTime)this.thoiGianTanCa, this.nguoiChamCong.caLamViec.thoiGianTanCa);
                }
                return lanVeSom;
            }
        }
        [XafDisplayName("Số Giờ Về Sớm")]
        public double? soGioVeSom
        {
            get
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
        /* Đầy là chương trình tính thời gian làm việc của nhân viên đầu ca
         * input: Tên nhân viên, thời gian vào đầu ca, thời gian vào cuối ca
         * Atuthor: Tấn Hòa
         * Date: 25/04/2019
         * Sửa chữa: Đình Tri
         * Date: 01/05/2019
         */
        private double tinhSoGioCongDauCa(NhanVien nhanVien, DateTime thoiGianVaoCa, DateTime thoiGianNghiGiuaCa)
         {
            double soGioCongDauCa;
            DateTime thoiGianVaoCaHopLe;
            DateTime thoiGianNghiGiuaCaHopLe;
            TimeSpan gioCongDauCa = TimeSpan.Zero;
            /*Nếu thời gian vào đầu ca của nhân viên là sớm hơn thời gian qui định ở ca làm việc của nhân viên thì qui đổi giờ chấm về giờ vào trong ca*/
            if((thoiGianVaoCa.Hour < nhanVien.caLamViec.thoiGianVao.Hour))
            {
                thoiGianVaoCaHopLe = new DateTime(thoiGianVaoCa.Year, thoiGianVaoCa.Month, thoiGianVaoCa.Day, nhanVien.caLamViec.thoiGianVao.Hour, nhanVien.caLamViec.thoiGianVao.Minute, 0);
            }
            else if ((thoiGianVaoCa.Hour <= nhanVien.caLamViec.thoiGianVao.Hour) && (thoiGianVaoCa.Minute <= nhanVien.caLamViec.thoiGianVao.Minute))
            {
                thoiGianVaoCaHopLe = new DateTime(thoiGianVaoCa.Year, thoiGianVaoCa.Month, thoiGianVaoCa.Day, nhanVien.caLamViec.thoiGianVao.Hour, nhanVien.caLamViec.thoiGianVao.Minute, 0);
            }
            else
            {
                thoiGianVaoCaHopLe = thoiGianVaoCa;
            }
            if(thoiGianNghiGiuaCa.Hour > nhanVien.caLamViec.thoiGianRaGiuaCa.Hour)
            {
                thoiGianNghiGiuaCaHopLe = new DateTime(thoiGianNghiGiuaCa.Year, thoiGianNghiGiuaCa.Month, thoiGianNghiGiuaCa.Day, nhanVien.caLamViec.thoiGianRaGiuaCa.Hour, nhanVien.caLamViec.thoiGianRaGiuaCa.Minute, 0);
            }
            else if ((thoiGianNghiGiuaCa.Hour >= nhanVien.caLamViec.thoiGianRaGiuaCa.Hour) && (thoiGianNghiGiuaCa.Minute >= nhanVien.caLamViec.thoiGianRaGiuaCa.Minute))
            {
                thoiGianNghiGiuaCaHopLe = new DateTime(thoiGianNghiGiuaCa.Year, thoiGianNghiGiuaCa.Month, thoiGianNghiGiuaCa.Day, nhanVien.caLamViec.thoiGianRaGiuaCa.Hour, nhanVien.caLamViec.thoiGianRaGiuaCa.Minute, 0);
            }
            else
            {
                thoiGianNghiGiuaCaHopLe = thoiGianNghiGiuaCa;
            }
            gioCongDauCa = thoiGianNghiGiuaCaHopLe - thoiGianVaoCaHopLe;
            soGioCongDauCa = gioCongDauCa.TotalMinutes / 60;
            soGioCongDauCa = Math.Round(soGioCongDauCa, 2);
            return soGioCongDauCa;
         }
        /*
         * Đây là chương trình tính thời gian làm việc của nhân viên cuối ca
         * Input: thông tin nhân viên, thời gian vào giữa ca, thời gian tan ca
         * Author: Tấn Hòa
         * Date: 25/04/2019
         * Sửa chữa: Đình Tri
         * Date: 01/05/2019
         */
         public double tinhSoGioCongCuoiCa(NhanVien nhanVien, DateTime thoiGianVaoGiuaCa, DateTime thoiGianTanCa)
         {
            double soGioCuoiCa;
            DateTime thoiGianVaoGiuaCaHopLe = new DateTime();
            DateTime thoiGianTanCaHopLe = new DateTime();
            TimeSpan gioCongCuoiCa = TimeSpan.Zero;
            /*Chuẩn Hóa Thời Gian Vào Giữa Ca*/
            if((thoiGianVaoGiuaCa.Hour < nhanVien.caLamViec.thoiGianVaoGiuaCa.Hour))
            {
                thoiGianVaoGiuaCaHopLe = new DateTime(thoiGianVaoGiuaCa.Year, thoiGianVaoGiuaCa.Month, thoiGianVaoGiuaCa.Day, nhanVien.caLamViec.thoiGianVaoGiuaCa.Hour, nhanVien.caLamViec.thoiGianVaoGiuaCa.Minute, 0);
            }
            else if ((thoiGianVaoGiuaCa.Hour <= nhanVien.caLamViec.thoiGianVaoGiuaCa.Hour) && (thoiGianVaoGiuaCa.Minute <= nhanVien.caLamViec.thoiGianVaoGiuaCa.Minute))
            {
                thoiGianVaoGiuaCaHopLe = new DateTime(thoiGianVaoGiuaCa.Year, thoiGianVaoGiuaCa.Month, thoiGianVaoGiuaCa.Day, nhanVien.caLamViec.thoiGianVaoGiuaCa.Hour, nhanVien.caLamViec.thoiGianVaoGiuaCa.Minute, 0);
            }
            else
            {
                thoiGianVaoGiuaCaHopLe = thoiGianVaoGiuaCa;
            };
            /*Chuẩn Hóa Thời Gian Ra Cuối Ca*/
            if((thoiGianTanCa.Hour > nhanVien.caLamViec.thoiGianTanCa.Hour))
            {
                thoiGianTanCaHopLe = new DateTime(thoiGianTanCa.Year, thoiGianTanCa.Month, thoiGianTanCa.Day, nhanVien.caLamViec.thoiGianTanCa.Hour, nhanVien.caLamViec.thoiGianTanCa.Minute, 0);
            }
            else if ((thoiGianTanCa.Hour >= nhanVien.caLamViec.thoiGianTanCa.Hour) && (thoiGianTanCa.Minute >= nhanVien.caLamViec.thoiGianTanCa.Minute))
            {
                thoiGianTanCaHopLe = new DateTime(thoiGianTanCa.Year, thoiGianTanCa.Month, thoiGianTanCa.Day, nhanVien.caLamViec.thoiGianTanCa.Hour, nhanVien.caLamViec.thoiGianTanCa.Minute, 0);
            }
            else
            {
                thoiGianTanCaHopLe = thoiGianTanCa;
            }
            gioCongCuoiCa = thoiGianTanCaHopLe - thoiGianVaoGiuaCaHopLe;
            soGioCuoiCa = gioCongCuoiCa.TotalMinutes / 60;
            soGioCuoiCa = Math.Round(soGioCuoiCa, 2);
            return soGioCuoiCa;
         }
        /*
         * Đây là chương trình tính thời gian đi trễ của nhân viên
         * Input: thông tin nhân viên, thời gian vào đầu ca, thời gian giữa ca
         * Author: Đình Tri
         * Date: 01/05/2019
         */
         public double tinhSoGioDiTre(NhanVien nhanVien, DateTime thoiGianVao, DateTime thoiGianHopLe)
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
                soGioDiTre = gioDiTre.TotalMinutes / 60;
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
        public double tinhSoGioVeSom(NhanVien nhanVien, DateTime thoiGianVe, DateTime thoiGianHetCa)
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
                soGioVeSom = gioVeSom.TotalMinutes / 60;
                return soGioVeSom;
            }
        }
        /*
         * Đây là chương trình tính số lần đi trễ của nhân viên
         * Input: thông tin nhân viên, thời gian vào đầu ca, thời gian ca làm việc
         * Author: Đình Tri
         * Date: 02/05/2019
         */
        public int tinhSoLanDiTre(NhanVien nhanVien, DateTime thoiGianVao, DateTime thoiGianCaLamViec)
        {
            int soLanTre = 0;
            TimeSpan soGio = TimeSpan.Zero;
            DateTime thoiGianHopLe = new DateTime(thoiGianVao.Year, thoiGianVao.Month, thoiGianVao.Day, thoiGianCaLamViec.Hour, thoiGianCaLamViec.Minute, 0);
            if(DateTime.Compare(thoiGianVao, thoiGianHopLe) > 0)
            {
                if((thoiGianVao - thoiGianHopLe).TotalMinutes >= 4)
                {
                    soLanTre = 1;
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
        public int tinhSoLanVeSom(NhanVien nhanVien, DateTime thoiGianRa, DateTime thoiGianCaLamViec)
        {
            int soLanSom = 0;
            DateTime thoiGianHopLe = new DateTime(thoiGianRa.Year, thoiGianRa.Month, thoiGianRa.Day, thoiGianCaLamViec.Hour, thoiGianCaLamViec.Minute, 0);
            if (DateTime.Compare(thoiGianRa, thoiGianHopLe) < 0)
            {
                soLanSom = 1;
            }
            return soLanSom;
        }
    }
}
