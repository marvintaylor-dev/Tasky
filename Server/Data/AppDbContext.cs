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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<sectionNoteModel>().HasKey(x => new {x.TaskId, x.SectionId});
            base.OnModelCreating(builder);
        }

        public DbSet<NoteModel> Tasks { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Section> Sections { get; set; }

        public DbSet<RelativeSize> RelativeSizes { get; set; }
        public DbSet<UserStory> UserStories { get; set; }

        public DbSet<Status> Statuses { get; set; }
        public DbSet<sectionNoteModel> SectionNoteModels { get; set; }

    }
}
