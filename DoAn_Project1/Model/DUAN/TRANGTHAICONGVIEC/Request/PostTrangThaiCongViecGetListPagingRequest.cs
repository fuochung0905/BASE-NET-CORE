using Model.BASE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS.DUAN.TRANGTHAICONGVIEC.Request
{
	public class PostTrangThaiCongViecGetListPagingRequest : GetListPagingRequest
	{
		public Guid? DuAnId { get; set; }
		public Guid? GiaiDoanId { get; set; }
		public Guid? CongViecTrongGiaiDoanId { get; set; }
		public int TrangThaiId { get; set; }
		public Guid? NguoiThucHienId { get; set; }
		public Guid? NguoiKiemTraId { get; set; }
		public Guid? AssignTo { get; set; }
        public DateTime? TuNgay { get; set; }
        public DateTime? DenNgay { get; set; }
    }

}
