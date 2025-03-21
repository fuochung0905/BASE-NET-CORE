
using MODELS.BASE;
using System.ComponentModel.DataAnnotations;

namespace MODELS.DUAN.QUANLYCONGVIEC.Requests
{
    public class PostSubTaskRequests 
    {
        public Guid Id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Tên công việc bắt buộc nhập")]
        public string? TenCongViec { get; set; }
        public DateTime? NgayBatDau { get; set; }
        public DateTime? NgayHetHan { get; set; }
        public Guid? AssignToId { get; set; }
        public int? TrangThaiId { get; set; }
        [UIHint("ClientAssignTo")]
        [Required(ErrorMessage = "AssignTo bắt buộc chọn")]
        public MODELCombobox? ClientAssignTo { get; set; } = new MODELCombobox();
        [UIHint("ClientTrangThaiCongViec")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "TrangThai bắt buộc chọn")]
        public MODELCombobox? ClientTrangThaiCongViec { get; set; } = new MODELCombobox();
        public Guid? ParentId { get; set; }
        public bool? IsThuyetTrinh { get; set; } = true;

    }

}
