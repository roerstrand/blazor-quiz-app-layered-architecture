using System;
using System.Collections.Generic;
using System.Text;

namespace Cyberquiz.Shared.DTOs
{
    public class AnswerOptionDto
    {
        public int Id { get; set; }

        public string Answer { get; set; } = string.Empty; //Visar svaren på frågan

    }
}
