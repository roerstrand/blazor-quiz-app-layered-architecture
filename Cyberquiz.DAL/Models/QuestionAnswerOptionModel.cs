using System;
using System.Collections.Generic;
using System.Text;

namespace Cyberquiz.DAL.Models
{
    // Junction table: links a question to an answer option. The row where questionId and AnswerOptionId are linked marks whether it is the correct answer.
    public class QuestionAnswerOptionModel
    {
        public int QuestionId { get; set; }
        public QuestionModel Question { get; set; }

        public int AnswerOptionId { get; set; }
        public AnswerOptionModel AnswerOption { get; set; }

        public bool IsCorrect { get; set; }
    }
}
