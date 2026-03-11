using Microsoft.AspNetCore.Identity;

namespace Cyberquiz.UI.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        /// <summary>
        /// Datum när användaren skapades
        /// </summary>
        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
