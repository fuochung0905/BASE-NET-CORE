
using Model.BASE;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS.DANHMUC.LOAITAIKHOAN.Requests
{
    public class PostLoaiTaiKhoanRequest :BaseRequest
    {
        public Guid Id { get; set; }
        
        public string? Ma { get; set; }
        [Required(AllowEmptyStrings =false,ErrorMessage = "Tên gọi bắt buộc nhập")]
        public string? TenGoi { get; set; }
    }

}
