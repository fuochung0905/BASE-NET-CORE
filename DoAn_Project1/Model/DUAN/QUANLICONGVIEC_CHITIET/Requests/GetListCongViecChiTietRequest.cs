using Model.BASE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS.DUAN.QUANLICONGVIEC_CHITIET.Requests
{
    public class GetListCongViecChiTietRequest: GetListPagingRequest
    {
        public Guid? TaiKhoanId { get; set; }
    }
}
