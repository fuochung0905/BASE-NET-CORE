using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.BASE;
using MODELS;

namespace MODELS.DUAN.LICHSUCONGVIEC.Dtos
{
    public class MODELLichSuCongViec : MODELBase
    {
        public string? CongViec { get; set; }
        public string? NguoiThucHien { get; set; }
        public string? TrangThai { get; set; }
        public DateTime? NgayBatDau { get; set; }
        public string? NguoiKiemTra { get; set; }
        public Guid? NguoiDangThucHien { get; set; }
        public string? TenNguoiDangThucHien { get; set; }


    }
}
