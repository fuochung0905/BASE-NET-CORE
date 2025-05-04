using Model.BASE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS.DANHMUC.MONHOC.Requests
{
    public class PostMonHocGetListPagingRequest : GetListPagingRequest
    {
        public Guid? NienKhoaId { get; set; }
        public Guid? PhongBanId { get; set; }
    }
}
