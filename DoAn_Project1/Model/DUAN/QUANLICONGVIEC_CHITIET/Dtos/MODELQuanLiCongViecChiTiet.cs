
using MODELS.BASE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS.DUAN.QUANLICONGVIEC_CHITIET.Dtos
{
    public class MODELQuanLiCongViecChiTiet
    {
        public Guid Id { get; set; }
        public string? TenCongViecCon { get; set; }
        public double? SoGioCong { get; set; }
        public DateTime? NgayHoanThanh { get; set; }
        public int? TrangThaiId { get; set; }
        public MODELCombobox? ClientTrangThaiCongViec { get; set; } = new MODELCombobox();
        public Guid? CongViecId { get; set; }
    }
}
