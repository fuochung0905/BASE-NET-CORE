using System;
using System.Collections.Generic;

namespace ENTITIES.DBContent;

public partial class THONGBAO_NGUOIDUNG
{
    public Guid Id { get; set; }

    public Guid TaiKhoanId { get; set; }
    public TAIKHOAN TAIKHOAN { get; set; }

    public Guid ThongBaoId { get; set; }
    public HETHONG_THONGBAO HETHONG_THONGBAO { get; set; }

    public bool? Is_Read { get; set; }

    public DateTime? Read_At { get; set; }

    public DateTime? Delivered_At { get; set; }
}
