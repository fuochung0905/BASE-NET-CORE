
using Model.BASE;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS.HETHONG.MENU.Requests
{
    public class PostMenuRequest : BaseRequest
    {
        public Guid? Id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "ControllerName bắt buộc nhập")]
        public string? ControllerName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Controller bắt buộc nhập")]
        public string? Controller { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Action bắt buộc nhập")]
        public string? Action { get; set; } = "index";
        [Required(AllowEmptyStrings = false, ErrorMessage = "Tên gọi bắt buộc nhập")]
        public string? TenGoi { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Nhóm quyền bắt buộc nhập")]
        public Guid? NhomQuyenId { get; set; }
        public bool CoXem { get; set; } = false;
        public bool CoThem { get; set; } = false;
        public bool CoCapNhat { get; set; } = false;
        public bool CoXoa { get; set; } = false;
        public bool CoDuyet { get; set; } = false;
        public bool CoThongKe { get; set; } = false;
        public bool IsShowMenu { get; set; } = true;
    }

 
}
