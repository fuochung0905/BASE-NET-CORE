using Model.BASE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS.DANHMUC.LOAIDUAN.Requests
{
    public class PostLoaiDuAnRequest : BaseRequest
    {
        public Guid Id { get; set; }

        public string? Ma { get; set; }

        public string TenGoi { get; set; } = null!;
    }
}
