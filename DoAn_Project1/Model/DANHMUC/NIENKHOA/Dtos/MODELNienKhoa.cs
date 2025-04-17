using Model.BASE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS.DANHMUC.NIENKHOA.Dtos
{
    public class MODELNienKhoa :MODELBase
    {
        public Guid Id { get; set; }
        public string Ma { get; set; }
        public string TenGoi { get; set; }
        public bool IsHienTai { get; set; }
    }
}
