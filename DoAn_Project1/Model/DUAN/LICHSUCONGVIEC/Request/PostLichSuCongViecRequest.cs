using Model.BASE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS.DUAN.LICHSUCONGVIEC.Request
{
    public class PostLichSuCongViecRequest : BaseRequest
    {
        public Guid Id { get; set; }

        public Guid CongViecId { get; set; }
        public Guid NguoiThucHien { get; set; }
        public int TrangThaiId { get; set; }
        public Guid? NguoiDangThucHien { get; set; }
        public string? TenNguoiDangThucHien { get; set; }

    }
}
