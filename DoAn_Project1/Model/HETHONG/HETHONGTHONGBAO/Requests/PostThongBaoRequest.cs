using Model.BASE;
using MODELS.BASE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS.HETHONG.HETHONGTHONGBAO.Requests
{
    public class PostThongBaoRequest : BaseRequest
    {
        public Guid Id { get; set; }

        public string TieuDe { get; set; } = null!;

        public string? NoiDung { get; set; }

        public int? Type { get; set; }
        //TepDinhKem
        public string? FolderTemp { get; set; }
        public string? TepDinhKemIDs { get; set; }
        public List<MODELTepDinhKem>? ListTepDinhKem { get; set; }
        public bool IsTepDinhKem { get; set; } = false;
        public List<Guid> UserIds { get; set; }
    }

}
