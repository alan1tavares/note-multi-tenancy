using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace Infrastructure
{
    public class NoteDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public DbSet<Group> Groups { get; set; }
        public DbSet<Note> Notes { get; set; }

        public NoteDbContext(DbContextOptions<NoteDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>()
                .HasOne(x => x.User)
                .WithOne()
                .HasForeignKey<ApplicationUser>(x => x.UserId)
                .IsRequired();

            builder.Entity<GroupUser>()
                .HasKey(x => x.Id);

            builder.Entity<Group>()
                .HasMany(e => e.Users)
                .WithMany(e => e.Groups)
                .UsingEntity<GroupUser>(
                    l => l.HasOne(e => e.User).WithMany(e => e.GroupUsers).OnDelete(DeleteBehavior.Restrict),
                    r => r.HasOne(e => e.Group).WithMany(e => e.GroupUsers).OnDelete(DeleteBehavior.Restrict)
                );
        }
    }
}