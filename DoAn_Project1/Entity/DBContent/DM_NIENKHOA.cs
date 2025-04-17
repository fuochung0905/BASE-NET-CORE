namespace ENTITIES.DBContent
{
    public class DM_NIENKHOA
    {
        public Guid Id { get; set; }
        public string Ma { get; set; }
        public string TenGoi { get; set; }
        public bool IsHienTai { get; set; }
        public DateTime NgayTao { get; set; }

        public string NguoiTao { get; set; } = null!;

        public DateTime? NgaySua { get; set; }

        public string? NguoiSua { get; set; }

        public DateTime? NgayXoa { get; set; }

        public string? NguoiXoa { get; set; }

        public bool IsActived { get; set; }

        public bool IsDeleted { get; set; }
        public ICollection<DM_MONHOC> dM_MONHOCs { get; set; }
    }
}
