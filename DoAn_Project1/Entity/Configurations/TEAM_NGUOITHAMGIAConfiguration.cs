using ENTITIES.DBContent;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ENTITIES.Configurations
{
    public class TEAM_NGUOITHAMGIAConfiguration : IEntityTypeConfiguration<TEAM_NGUOITHAMGIA>
    {
        public void Configure(EntityTypeBuilder<TEAM_NGUOITHAMGIA> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.TAIKHOAN).WithMany(x => x.tEAM_NGUOITHAMGIAs).HasForeignKey(x => x.TaiKhoanId);
            builder.HasOne(x => x.DM_TEAM).WithMany(x => x.tEAM_NGUOITHAMGIAs).HasForeignKey(x => x.TeamId);
        }
    }
}
