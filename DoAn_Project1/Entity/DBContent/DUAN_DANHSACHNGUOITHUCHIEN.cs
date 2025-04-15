using System;
using System.Collections.Generic;

namespace ENTITIES.DBContent;

public partial class DUAN_DANHSACHNGUOITHUCHIEN
{
    public Guid Id { get; set; }

    public Guid DuAnId { get; set; }
    public DUAN_QUANLYDUAN DUAN_QUANLYDUAN { get; set; }

    public Guid NguoiThucHienId { get; set; }
    public TAIKHOAN TAIKHOAN { get; set; }
}
