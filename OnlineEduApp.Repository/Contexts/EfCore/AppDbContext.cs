using Microsoft.EntityFrameworkCore;
using OnlineEduApp.Core.Entities.Concretes;
using System.Reflection;

namespace OnlineEduApp.Repository.Contexts.EfCore
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Banner>  Banners { get; set; }
        public DbSet<About>  Abouts { get; set; }
        public DbSet<Blog>  Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<Subscriber> Subscribers { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }   

    }
}
