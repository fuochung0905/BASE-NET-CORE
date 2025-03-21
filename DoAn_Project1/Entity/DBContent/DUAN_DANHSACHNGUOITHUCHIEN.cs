using System;
using System.Collections.Generic;

namespace ENTITIES.DBContent;

public partial class DUAN_DANHSACHNGUOITHUCHIEN
{
    public Guid Id { get; set; }

    public Guid DuAnId { get; set; }

    public Guid NguoiThucHienId { get; set; }
}
