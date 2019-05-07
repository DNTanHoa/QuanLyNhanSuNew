using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Model;
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
    public class GioCong : XPLiteObject
    {
        public GioCong(Session session) : base(session) { }
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
        [XafDisplayName("Tên Nhân Viên")]
        //[Association("Nhân Viên - Giờ Công")]
        public NhanVien nguoiChamCong
        {
            get { return fNguoiChamCong; }
            set { SetPropertyValue("nguoiChamCong", ref fNguoiChamCong, value); }
        }
        NgayTinhCong fNgay;
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
        [XafDisplayName("Thời Gian Vào Ca")]
        [ModelDefault("DisplayFormat", "{0:HH:mm}")]
        [ModelDefault("EditMask", "{HH:mm}")]
        public DateTime? thoiGianVaoCa
        {
            get
            {
                if(!Equals(this.nguoiChamCong,null))
                {
                    List<CheckInOut> thoiGianVaoCas = new List<CheckInOut>();
                    DateTime thoiGianVaoHopLe = this.nguoiChamCong.caLamViec.thoiGianVao;
                    /*Lọc Danh Sách Các Lần chấm Công Hợp Lệ Trong Khung Giờ Quy Định*/
                    foreach (CheckInOut checkInOut in this.checkInOuts)
                    {
                        if ((checkInOut.GioCham.Hour >= (thoiGianVaoHopLe.Hour - 1)) && (checkInOut.GioCham.Hour <= (thoiGianVaoHopLe.Hour + 1)))
                        {
                            thoiGianVaoCas.Add(checkInOut);
                        }
                    }
                    /*Trả Về Lần Quẹt Sớm Nhất*/
                    if (thoiGianVaoCas != null)
                    {
                        CheckInOut checkIn = thoiGianVaoCas.FirstOrDefault();
                        if(checkIn != null)
                        {
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
        [XafDisplayName("Thời Gian Ra Giữa Ca")]
        [ModelDefault("DisplayFormat", "{0:HH:mm}")]
        [ModelDefault("EditMask", "{HH:mm}")]
        public DateTime? thoiGianRaGiuaCa
        {
            get
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
                        CheckInOut checkIn = thoiGianRaGiuaCas.FirstOrDefault();
                        if (checkIn != null)
                        {
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
        [XafDisplayName("Thời Gian Vào Giữa Ca")]
        [ModelDefault("DisplayFormat", "{0:HH:mm}")]
        [ModelDefault("EditMask", "{HH:mm}")]
        public DateTime? thoiGianVaoGiuaCa
        {
            get
            {
                if (!Equals(this.nguoiChamCong, null))
                {
                    List<CheckInOut> thoiGianVaoGiuaCas = new List<CheckInOut>();
                    DateTime thoiGianVaoGiuaCaHopLe = this.nguoiChamCong.caLamViec.thoiGianVaoGiuaCa;
                    /*Lọc Danh Sách Các Lần chấm Công Hợp Lệ Trong Khung Giờ Quy Định*/
                    foreach (CheckInOut checkInOut in this.checkInOuts)
                    {
                        if ((checkInOut.GioCham.Hour >= (thoiGianVaoGiuaCaHopLe.Hour - 2)) && (checkInOut.GioCham.Hour <= (thoiGianVaoGiuaCaHopLe.Hour + 1)))
                        {
                            thoiGianVaoGiuaCas.Add(checkInOut);
                        }
                    }
                    /*Trả Về Lần Quẹt Sớm Nhất*/
                    if (thoiGianVaoGiuaCas != null)
                    {
                        CheckInOut checkIn = thoiGianVaoGiuaCas.LastOrDefault();
                        if (checkIn != null)
                        {
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
        [XafDisplayName("Thời Gian Tan Ca")]
        [ModelDefault("DisplayFormat", "{0:HH:mm}")]
        [ModelDefault("EditMask", "{HH:mm}")]
        public DateTime? thoiGianTanCa
        {
            get
            {
                if(!Equals(this.nguoiChamCong, null))
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
                Console.WriteLine(soGioDauCa);
                Console.WriteLine(soGioCuoiCa);
                return soGioDauCa + soGioCuoiCa;
            }
        }
        /* Kiểm Tra xem ngày đó nhân viên có đi trễ hay không. Xét điều kiện nếu nhân viên có lần chấm công trễ hơn so với thời gian qui định thì tính là đi trễ ở cả hai ca
         * 
         */
        double? fSoGioTangCa;
        [XafDisplayName("Số Giờ Tăng Ca")]
        public double? soGioTangCa
        {
            get { return fSoGioTangCa; }
            set { SetPropertyValue("soGioTangCa", ref fSoGioTangCa, value); }
        }
        [Association(@"GioCong-CheckInOut")]
        [XafDisplayName("Lần Chấm Công")]
        public XPCollection<CheckInOut> checkInOuts { get { return GetCollection<CheckInOut>("checkInOuts"); } }
        [Association(@"GiocCong-LanTangCa")]
        [XafDisplayName("Lần Tăng Ca")]
        public XPCollection<LanTangCa> lanTangCas { get { return GetCollection<LanTangCa>("lanTangCas"); } }
        /* Đây là chương trình tính giờ công nhân viên cho toàn bộ ngày
         * input: nhân viên, thời gian vào đầu ca, thời gian ra cuối ca, thời gian......
         * Author: Tấn Hòa
         * Date: 25/04/2019
         */
        private double tinhSoGioCong(NhanVien nhanVien, DateTime thoiGianVaoCa, DateTime thoiGianNghiGiuaCa, DateTime thoiGianVaoGiuaCa, DateTime thoiGianTanCa)
        {
            double soGioCong = 0;
            double soGioDauCa = 0;
            double soGioCuoiCa = 0;
            TimeSpan gioCongDauCa = TimeSpan.Zero;
            TimeSpan gioCongCuoiCa = TimeSpan.Zero;
            DateTime thoiGianVaoCaHopLe = new DateTime();
            DateTime thoiGianNghiGiuaCaHopLe = new DateTime();
            DateTime thoiGianVaoGiuaCaHopLe = new DateTime();
            DateTime thoiGianTanCaHopLe = new DateTime();
            /*Nếu thời gian vào đầu ca của nhân viên là sớm hơn thời gian qui định ở ca làm việc của nhân viên thì qui đổi giờ chấm về giờ vào trong ca*/
            if((thoiGianVaoCa.Hour <= nhanVien.caLamViec.thoiGianVao.Hour)&&(thoiGianVaoCa.Minute <= nhanVien.caLamViec.thoiGianVao.Minute))
            {
                thoiGianVaoCaHopLe = new DateTime(thoiGianVaoCa.Year, thoiGianVaoCa.Month, thoiGianVaoCa.Day, nhanVien.caLamViec.thoiGianVao.Hour, nhanVien.caLamViec.thoiGianVao.Minute, 0);
            }
            else
            {
                thoiGianVaoCaHopLe = thoiGianVaoCa;
            }
            if ((thoiGianVaoGiuaCa.Hour <= nhanVien.caLamViec.thoiGianVaoGiuaCa.Hour) && (thoiGianVaoGiuaCa.Minute <= nhanVien.caLamViec.thoiGianVaoGiuaCa.Minute))
            {
                thoiGianVaoGiuaCaHopLe = nhanVien.caLamViec.thoiGianVaoGiuaCa;
            }
            else
            {
                thoiGianVaoGiuaCaHopLe = thoiGianVaoGiuaCa;
            }
            /*Nếu thời gian tan ca của nhân viên là trễ hơn thời gian qui định ở ca làm việc của nhân viên thì qui đổi thời gian về giờ tan ca trong qui định*/
            if ((thoiGianTanCa.Hour >= nhanVien.caLamViec.thoiGianTanCa.Hour) && (thoiGianTanCa.Minute >= nhanVien.caLamViec.thoiGianTanCa.Minute))
            {
                thoiGianTanCaHopLe = nhanVien.caLamViec.thoiGianTanCa;
            }
            else
            {
                thoiGianTanCaHopLe = thoiGianTanCa;
            }
            if ((thoiGianNghiGiuaCa.Hour >= nhanVien.caLamViec.thoiGianRaGiuaCa.Hour) && (thoiGianNghiGiuaCa.Minute >= nhanVien.caLamViec.thoiGianRaGiuaCa.Minute))
            {
                thoiGianNghiGiuaCaHopLe = nhanVien.caLamViec.thoiGianRaGiuaCa;
            }
            else
            {
                thoiGianNghiGiuaCaHopLe = thoiGianNghiGiuaCa;
            }
            /*Tính thời gian làm việc hợp lệ của nhân viên theo công thức lấy giờ ra hợp lệ trừ giờ vào hợp lệ*/
            gioCongDauCa = thoiGianNghiGiuaCaHopLe - thoiGianVaoCaHopLe;
            gioCongCuoiCa = thoiGianTanCaHopLe - thoiGianVaoGiuaCaHopLe;
            /*Quy đổi thời gian time span thành số giờ công làm tròn đến 1 chữ số thâp phân*/
            soGioDauCa = gioCongDauCa.TotalMinutes / 60;
            soGioCuoiCa = gioCongCuoiCa.TotalMinutes / 60;
            /*Làm tròn và cộng số giờ công của nhân viên*/
            soGioCong = Math.Round(soGioDauCa, 1) + Math.Round(soGioCuoiCa, 1);
            return soGioCong;
        }
        /* Đầy là chương trình tính thời gian làm việc của nhân viên đầu ca
         * input: Tên nhân viên, thời gian vào đầu ca, thời gian vào cuối ca
         * Atuthor: Tấn Hòa
         * Date: 25/04/2019
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
            Console.WriteLine(thoiGianVaoCaHopLe);
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
            }
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
    }
}
