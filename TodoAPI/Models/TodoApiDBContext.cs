using Microsoft.EntityFrameworkCore;

namespace TodoAPI.Models
{
    public partial class TodoApiDBContext : DbContext
    {
        public virtual DbSet<Todo> Todos { get; set; }
        public virtual DbSet<User> Users { get; set; }

        public TodoApiDBContext(DbContextOptions<TodoApiDBContext> options) : base(options) {
            // base(options) -> base constructor is executed first.
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Todo>( entity =>
            {
                entity.Property(e => e.DueDate)
                    .IsRequired(false);
                entity.Property(e => e.Title)
                    .HasMaxLength(200);
                entity.Property(e => e.Description)
                    .HasMaxLength(500);
            });
            /*modelBuilder.Entity<Todo>()
                .Property(prop => prop.DueDate)
                .IsRequired(false);
            modelBuilder.Entity<Todo>()
                .Property(prop => prop.Title)
                .HasMaxLength(200);
            modelBuilder.Entity<Todo>()
                .Property(prop => prop.Description)
                .HasMaxLength(500);*/

            base.OnModelCreating(modelBuilder);
        }

        partial void OnModelCreatingpartial(ModelBuilder modelBuilder);
    }
}
