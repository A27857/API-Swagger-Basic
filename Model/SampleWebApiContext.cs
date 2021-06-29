using Microsoft.EntityFrameworkCore;

namespace C__ASP_.Net_Core_API.Models
{
    public class SampleWebApiContext : DbContext
    {
        public SampleWebApiContext (DbContextOptions<SampleWebApiContext> options) : base (options)
        {

        }
        public DbSet<TaskModel> TaskModels { get; set; }
    }
}