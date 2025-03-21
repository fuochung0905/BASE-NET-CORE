using System;
using System.Collections.Generic;

namespace ENTITIES.DBContent;

public partial class QUANLYDUAN_NGUOIDUNG
{
    public Guid Id { get; set; }

    public Guid DuAnId { get; set; }

    public Guid TaiKhoanId { get; set; }

    public bool IsActived { get; set; }

    public bool IsDeleted { get; set; }
}
