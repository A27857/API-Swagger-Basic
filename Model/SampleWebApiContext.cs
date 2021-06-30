using Microsoft.EntityFrameworkCore;

namespace API29v6v21.Models
{
    public class SampleWebApiContext : DbContext
    {
        public SampleWebApiContext(DbContextOptions<SampleWebApiContext> options) : base(options)
        {
        }
        public DbSet<TaskModel> TaskModels { get; set; }
    }
}