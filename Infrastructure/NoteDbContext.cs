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

            builder.Entity<Group>()
                .HasMany(e => e.Users)
                .WithMany(e => e.Groups)
                .UsingEntity<GroupUser>(
                    l => l.HasOne<User>().WithMany().HasForeignKey(e => e.UserId).OnDelete(DeleteBehavior.Restrict),
                    r => r.HasOne<Group>().WithMany().HasForeignKey(e => e.GroupId).OnDelete(DeleteBehavior.Restrict)
                );
        }
    }
}