
using MODELS.BASE;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS.DUAN.QUANLYCONGVIEC.Requests
{
    public class PostChiTietCongViecRequest
    {
        public Guid Id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Tên công việc bắt buộc nhập")]
        public string? TenCongViec { get; set; }
        public DateTime? NgayHoanThanh{ get; set; }
        public Double? SoGioCong { get; set; }
        public int? TrangThaiId { get; set; }
        [UIHint("ClientTrangThaiCongViec")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Trạng thái bắt buộc chọn")]
        public MODELCombobox? ClientTrangThaiCongViec { get; set; } = new MODELCombobox();
        public Guid? ParentId { get; set; }
    }
}
