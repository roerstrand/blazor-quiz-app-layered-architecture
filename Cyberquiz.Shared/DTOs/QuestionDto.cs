using System;
using System.Collections.Generic;
using System.Text;

namespace Cyberquiz.Shared.DTOs
{
    public class QuestionDto
    {
        public int Id { get; set; }

        public string Question { get; set; }

        public ICollection<AnswerOptionDto> AnswerOptions { get; set; } // Hämtar svarsalternativen för frågan
    }
}
