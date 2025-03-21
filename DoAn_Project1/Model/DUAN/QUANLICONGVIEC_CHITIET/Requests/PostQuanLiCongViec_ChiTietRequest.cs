using System;
using System.Collections.Generic;
using System.Linq;
using MODELS.BASE;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Model.BASE;

namespace MODELS.DUAN.QUANLICONGVIEC_CHITIET.Requests
{
    public class PostQuanLiCongViec_ChiTietRequest : BaseRequest
    {
        public Guid Id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Tên công việc bắt buộc nhập")]
        public string? TenCongViecCon { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Số giờ công không được để trống")]
        public Double? SoGioCong { get; set; }
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Ngày hoàn thành không được rỗng")]
        public DateTime? NgayHoanThanh { get; set; }
        public int? TrangThaiId { get; set; }
        [UIHint("ClientTrangThaiCongViec")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Trạng thái bắt buộc chọn")]
        public MODELCombobox? ClientTrangThaiCongViec { get; set; } = new MODELCombobox();
        public Guid? CongViecId { get; set; }
    }
}
