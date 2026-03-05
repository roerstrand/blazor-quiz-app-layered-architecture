namespace Cyberquiz.Shared.DTOs
{
    public class UserProgressDto
    {
        public int Id { get; set; }

        public string UserName { get; set; } = string.Empty;

        public int SubCategoryId { get; set; }

        public string SubCategoryName { get; set; } = string.Empty;

        public int Score { get; set; }

        public int TotalQuestions { get; set; }

        public DateTime CompletedAt { get; set; }
    }
}
