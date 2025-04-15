using ENTITIES.DBContent;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITIES.Configurations
{
    public class DUAN_DANHSACHNGUOITHUCHIENConfiguration : IEntityTypeConfiguration<DUAN_DANHSACHNGUOITHUCHIEN>
    {
        public void Configure(EntityTypeBuilder<DUAN_DANHSACHNGUOITHUCHIEN> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x=>x.DUAN_QUANLYDUAN).WithMany(q=>q.DUAN_DANHSACHNGUOITHUCHIENs).HasForeignKey(x=>x.DuAnId) ;
       
        }
    }
}
