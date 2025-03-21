
using Model.BASE;
using MODELS.DUAN.QUANLYCONGVIEC.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS.DUAN.TRANGTHAICONGVIEC.Request
{
    public class PostCongViecByTrangThaiRequest : BaseRequest
    {
        public Guid Id { get; set; }
        public DateTime? ThucTeTuNgay { get; set; }

        public DateTime? ThucTeDenNgay { get; set; }

        public int? SoGioThucTe { get; set; }
        public int? ThoiGianTest { get; set; }
        public double? TienDo { get; set; }
        public Guid? AssignTo { get; set; }
        public string? KetQuaCongViec { get; set; }

        public string? HuongDanSuDungNhanh { get; set; }
    }

}
