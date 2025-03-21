
using Model.BASE;
using MODELS;
using System.ComponentModel.DataAnnotations;

namespace MODELS.HETHONG.TAIKHOAN.Requests
{
    public class PostTaiKhoanRequest : BaseRequest
    {
        public Guid? Id { get; set; }
        [Required(ErrorMessage = "Tên đăng nhập bắt buộc nhập")]
        public string? UserName { get; set; } = null!;
        public Guid? TinhId { get; set; }
        public Guid? HuyenId { get; set; }
        public Guid? XaId { get; set; }
        [Required(ErrorMessage = "Vai trò bắt buộc nhập")]
        public Guid? VaiTroId { get; set; }
        [Required(ErrorMessage = "Đơn vị bắt buộc nhập")]
        public Guid? DonViId { get; set; }
        [Required(ErrorMessage = "Phòng ban bắt buộc nhập")]
        public Guid? PhongBanId { get; set; }
        [Required(ErrorMessage = "Chức vụ bắt buộc nhập")]
        public Guid? ChucVuId { get; set; }
        public Guid? NguoiQuanLyId { get; set; }
        [Required(ErrorMessage = "Loại tài khoản bắt buộc chọn")]
        public Guid? LoaiTaiKhoanId { get; set; }
        //Nhập số điện thoại cần 10 số
        [RegularExpression("^[Z0-9]{10}$", ErrorMessage = "Nhập 10 chữ (số)")]
        [Required(ErrorMessage = "Số điện thoại bắt buộc nhập")]
        public string SoDienThoai { get; set; } = null!;
        [Required(ErrorMessage = "Email bắt buộc nhập")]
        public string Email { get; set; } = null!;
        public string? HoLot { get; set; } = null!;
        [Required(ErrorMessage = "Tên bắt buộc nhập")]
        public string? Ten { get; set; } = null!;
        [Required(ErrorMessage = "Ngày sinh bắt buộc nhập")]
        public DateTime? NgaySinh { get; set; }
        /// <summary>
        /// 0: nam, 1: nữ
        /// </summary>
        public int? GioiTinh { get; set; } = 0;
        public string? AnhDaiDien { get; set; }
        public string? MatKhau { get; set; } = null!;
    }

 
}