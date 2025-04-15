using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITIES.DBContent
{
    public class DoAnProject1ContextFactory : IDesignTimeDbContextFactory<DoAnProject1Context>
    {
        public DoAnProject1Context CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DoAnProject1Context>();
            var connectionString = "Server=DESKTOP-1PNKA10;Initial Catalog=NghienCuuKhoaHoc;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=true;";

            optionsBuilder.UseSqlServer(connectionString);

            return new DoAnProject1Context(optionsBuilder.Options);
        }
    }
}
