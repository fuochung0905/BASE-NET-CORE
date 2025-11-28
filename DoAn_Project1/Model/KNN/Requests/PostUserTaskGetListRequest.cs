using Model.BASE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS.K_MEAN.Requests
{
    public class PostUserTaskGetListRequest : GetListPagingRequest
    {
        public Guid? DonViId { get; set; }
        public Guid? PhongBanId { get; set; }
        public Guid? NienKhoaId {  get; set; }
        public Guid? VaiTroId { get; set; }
        
    }
}
