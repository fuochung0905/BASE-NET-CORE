using System;
using System.Collections.Generic;

namespace ENTITIES.DBContent;

public partial class SYS_TRANGTHAICONGVIEC
{
    public int Id { get; set; }

    public string TenGoi { get; set; } = null!;
    public ICollection<DUAN_LICHSUGIAOVIEC>  DUAN_LICHSUGIAOVIECs { get; set; }
    public ICollection<DUAN_QUANLYCONGVIEC> DUAN_QUANLYCONGVIEC { get; set; }
    public ICollection<DUAN_QUANLYCONGVIEC_CHITIET> dUAN_QUANLYCONGVIEC_CHITIETs { get; set; }
}
