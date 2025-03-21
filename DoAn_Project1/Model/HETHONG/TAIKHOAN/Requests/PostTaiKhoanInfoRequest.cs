
using MODELS;
using System.ComponentModel.DataAnnotations;

namespace MODELS.HETHONG.TAIKHOAN.Requests
{
    public class PostTaiKhoanInfoRequest
    {
        public Guid? Id { get; set; }
        //Nhập số điện thoại cần 10 số
        [RegularExpression("^[Z0-9]{10}$", ErrorMessage = "Nhập 10 chữ (số)")]
        [Required(ErrorMessage = "Số điện thoại không được rỗng")]
        public string SoDienThoai { get; set; } = null!;
        [Required(ErrorMessage = "Email không được rỗng")]
        public string Email { get; set; } = null!;
        [Required(ErrorMessage = "Họ không được rỗng")]
        public string? HoLot { get; set; } = null!;
        [Required(ErrorMessage = "Tên không được rỗng")]
        public string? Ten { get; set; } = null!;
        [Required(ErrorMessage = "Ngày sinh không được rỗng")]
        public DateTime? NgaySinh { get; set; }
        /// <summary>
        /// 0: nam, 1: nữ
        /// </summary>
        public int? GioiTinh { get; set; } = 0;
        public string? AnhDaiDien { get; set; }
        public string? FolderUpload { get;} = Guid.NewGuid().ToString();
    }


}