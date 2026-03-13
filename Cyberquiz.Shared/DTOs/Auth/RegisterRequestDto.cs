namespace Cyberquiz.Shared.DTOs.Auth
{
    public class RegisterRequestDto
    {
        public string Username { get; set; } = "";
        public string Password { get; set; } = "";
        public string SecretQuestion { get; set; } = "";
        public string SecretAnswer { get; set; } = "";
    }
}
