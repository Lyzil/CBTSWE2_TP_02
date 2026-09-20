using Microsoft.EntityFrameworkCore;
using CBTSWE2_TP02.Models;

namespace CBTSWE2_TP02.Data
{
    public class CBTSWE2_TP02Context : DbContext
    {
        public CBTSWE2_TP02Context(DbContextOptions<CBTSWE2_TP02Context> options)
            : base(options)
        {
        }

        public DbSet<BL> BLs { get; set; }

        public DbSet<ContainerOBJ> Containers { get; set; }
    }
}
