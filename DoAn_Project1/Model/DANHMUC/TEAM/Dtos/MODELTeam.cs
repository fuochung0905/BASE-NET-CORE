using Model.BASE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODELS.DANHMUC.TEAM.Dtos
{
    public class MODELTeam : MODELBase
    {
        public Guid Id { get; set; }
        public string Ma { get; set; }
        public string TenGoi { get; set; } = null!;
        public string TenMonHoc { get; set; }

    }
}
