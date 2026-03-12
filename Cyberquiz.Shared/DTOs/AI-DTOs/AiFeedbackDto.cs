using System;
using System.Collections.Generic;
using System.Text;

namespace Cyberquiz.Shared.DTOs.AI_DTOs
{
    // DTO för att ta emot AI-coachens feedback som text att dela med användaren
    public class AiFeedbackDto
    {
        // TODO: Formatera feedbacken (som sammanfattningen)
        public string Feedback { get; set; }
    }
}
