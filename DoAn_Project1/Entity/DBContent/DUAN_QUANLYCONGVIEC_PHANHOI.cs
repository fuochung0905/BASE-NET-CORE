using System;
using System.Collections.Generic;

namespace ENTITIES.DBContent;

public partial class DUAN_QUANLYCONGVIEC_PHANHOI
{
    public Guid Id { get; set; }

    public Guid? ParentId { get; set; }

    public Guid LienKetId { get; set; }

    public Guid NguoiGuiId { get; set; }

    public DateTime NgayGui { get; set; }

    public string NoiDungHtml { get; set; } = null!;

    public bool IsDeleted { get; set; }
}
