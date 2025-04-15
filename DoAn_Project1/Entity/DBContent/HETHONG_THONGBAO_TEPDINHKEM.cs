using System;
using System.Collections.Generic;

namespace ENTITIES.DBContent;
        
public partial class HETHONG_THONGBAO_TEPDINHKEM
{
    public Guid Id { get; set; }

    public Guid LienKetId { get; set; }
    public HETHONG_THONGBAO HETHONG_THONGBAO { get; set; }

    public Guid BieuMauId { get; set; }

    public string? GhiChu { get; set; }

    public string TenFile { get; set; } = null!;

    public string TenMoRong { get; set; } = null!;

    public double DoLon { get; set; }

    public string Url { get; set; } = null!;
}
