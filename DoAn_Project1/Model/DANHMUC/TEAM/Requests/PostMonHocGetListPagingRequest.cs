using Model.BASE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS.DANHMUC.TEAM.Requests
{
    public class PostMonHocGetListPagingRequest : GetListPagingRequest
    {
        public Guid? MonHocId { get; set; }
    }
}
