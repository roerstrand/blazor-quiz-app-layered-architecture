using Microsoft.AspNetCore.Identity;

namespace Cyberquiz.DAL.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
        public string? SecretQuestion { get; set; }
        public string? SecretAnswerHash { get; set; }
    }
}
