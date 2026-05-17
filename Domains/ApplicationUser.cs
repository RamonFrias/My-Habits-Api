using Microsoft.AspNetCore.Identity;

namespace MyHabitsApi.Domains
{
    public class ApplicationUser : IdentityUser
    {
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiresTime { get; set; }
    }
}
