namespace Cyberquiz.Shared.DTOs.Auth
{
    public class ResetPasswordRequestDto
    {
        public string Username { get; set; } = "";
        public string SecretAnswer { get; set; } = "";
        public string NewPassword { get; set; } = "";
    }
}
