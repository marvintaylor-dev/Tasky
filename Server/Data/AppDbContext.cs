using Microsoft.EntityFrameworkCore;
using Tasky.Shared;

namespace Tasky.Server.Data
{
    public class AppDbContext : DbContext
    {

        protected readonly IConfiguration _configuration;

        public AppDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(_configuration.GetConnectionString("TaskDB"));
        }

        public DbSet<NoteModel> Tasks { get; set; }
        public DbSet<SubTask> SubTasks { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Note> Notes { get; set; }

    }
}
