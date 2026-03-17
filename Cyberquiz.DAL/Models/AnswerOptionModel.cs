using System;
using System.Collections.Generic;
using System.Text;

namespace Cyberquiz.DAL.Models
{

    // A model (single entity) representing an answer option in the database.
    public class AnswerOptionModel
    {
        public int Id { get; set; }

        public string Answer { get; set; } = string.Empty;

        public ICollection<QuestionAnswerOptionModel> QuestionAnswerOptions { get; set; }
    }
}
