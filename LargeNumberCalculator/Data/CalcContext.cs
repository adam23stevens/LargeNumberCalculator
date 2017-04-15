using Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class CalcContext : DbContext
    {
        public CalcContext(DbContextOptions<CalcContext> options) : base(options) { }       

        public DbSet<Calculation> Calculations { get; set; }
    }
}
