using System;
using System.Collections.Generic;

namespace ENTITIES.DBContent;

public partial class DUAN_QUANLYCONGVIEC_TEPDINHKEM
{
    public Guid Id { get; set; }

    public Guid LienKetId { get; set; }

    public string TenFile { get; set; } = null!;

    public string TenMoRong { get; set; } = null!;

    public double DoLon { get; set; }

    public string Url { get; set; } = null!;
}
