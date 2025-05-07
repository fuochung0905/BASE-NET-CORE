using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITIES.DBContent
{
    public class DUAN_QUANLYCONGVIEC_KETQUACONGVIEC_TEPDINHKEM
    {
        public Guid Id { get; set; }

        public Guid LienKetId { get; set; }
        public DUAN_QUANLYCONGVIEC DUAN_QUANLYCONGVIEC { get; set; }

        public string TenFile { get; set; } = null!;

        public string TenMoRong { get; set; } = null!;

        public double DoLon { get; set; }

        public string Url { get; set; } = null!;
    }
}
