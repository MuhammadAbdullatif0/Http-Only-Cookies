using Demo.Api.Entites;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Demo.Api.Data;

public class StoreContext(DbContextOptions<StoreContext> options) : IdentityDbContext<ApplicationUser>(options)
{
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        string userId = Guid.NewGuid().ToString();
        var hasher = new PasswordHasher<ApplicationUser>();
        var user = new ApplicationUser
        {
            Id = userId,
            UserName = "Muhammad",
            NormalizedUserName = "MUHAMMAD",
            Email = "test@test.com",
            NormalizedEmail = "TEST@TEST.COM",
            EmailConfirmed = true,
            FullName = "M TEFA",
            SecurityStamp = Guid.NewGuid().ToString("D")
        };
        user.PasswordHash = hasher.HashPassword(user, "Test@0123");

        builder.Entity<ApplicationUser>().HasData(user);     
    }
}
