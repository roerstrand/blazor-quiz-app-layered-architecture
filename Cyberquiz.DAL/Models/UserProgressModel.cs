using System;

namespace Cyberquiz.DAL.Models
{
    public class UserProgressModel
    {
        public int Id { get; set; }

        public string UserName { get; set; } = string.Empty;

        public int SubCategoryId { get; set; }
        public SubCategoryModel SubCategory { get; set; }

        public int Score { get; set; }

        public int TotalQuestions { get; set; }

        public DateTime CompletedAt { get; set; }

        public ICollection<UserAnswerModel> UserAnswers { get; set; } = new List<UserAnswerModel>();
    }
}
