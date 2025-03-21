using Model.BASE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS.DUAN.PHANHOI.Requests
{
    public class PostPhanHoiRequest : BaseRequest
    {
        public Guid Id { get; set; }

        public Guid? ParentId { get; set; }

        public Guid LienKetId { get; set; }

        public Guid? NguoiGuiId { get; set; }

        public DateTime? NgayGui { get; set; }

        public string? NoiDungHtml { get; set; } = null!;
        public string? PhanHoiByUsername { get; set; }
        public bool IsDeleted { get; set; }
    }
}
