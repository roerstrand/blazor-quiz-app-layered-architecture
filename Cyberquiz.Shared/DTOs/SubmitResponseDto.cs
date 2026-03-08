using System;
using System.Collections.Generic;
using System.Text;

namespace Cyberquiz.Shared.DTOs
{
    public class SubmitResponseDto
    {
        public bool IsCorrect { get; set; }
        public int CorrectAnswerOptionId { get; set; }
        public double SubCategoryScorePercent { get; set; } 
        public bool SubCategoryCompleted { get; set; }
        public bool UnlockedNextSubCategory { get; set; }
    }
}
