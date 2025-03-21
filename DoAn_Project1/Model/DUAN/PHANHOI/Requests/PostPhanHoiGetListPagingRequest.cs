using Model.BASE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS.DUAN.PHANHOI.Requests
{
    public class PostPhanHoiGetListPagingRequest : GetListPagingRequest
    {
        public Guid? CongViecId { get; set; }
    }
}
