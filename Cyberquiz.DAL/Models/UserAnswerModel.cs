using System;

namespace Cyberquiz.DAL.Models
{
    public class UserAnswerModel
    {
        public int Id { get; set; }

        public string UserName { get; set; } = string.Empty;

        public int QuestionId { get; set; }
        public QuestionModel Question { get; set; }

        public int AnswerOptionId { get; set; }
        public AnswerOptionModel AnswerOption { get; set; }

        public bool IsCorrect { get; set; }

        public DateTime AnsweredAt { get; set; }

        public int UserProgressId { get; set; }
        public UserProgressModel UserProgress { get; set; }
    }
}
