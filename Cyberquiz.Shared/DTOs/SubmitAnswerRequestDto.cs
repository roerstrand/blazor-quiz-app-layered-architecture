using System;
using System.Collections.Generic;
using System.Text;

namespace Cyberquiz.Shared.DTOs
{
    public class SubmitAnswerRequestDto
    {
        public int SubCategoryId { get; set; }
        public int QuestionId { get; set; }
        public int AnswerOptionId { get; set; }
        public string? UserName { get; set; }
    }
}
