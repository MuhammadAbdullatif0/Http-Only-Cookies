using Microsoft.AspNetCore.Identity;

namespace Demo.Api.Entites;

public class ApplicationUser : IdentityUser
{
    public string FullName { get; set; }
}
