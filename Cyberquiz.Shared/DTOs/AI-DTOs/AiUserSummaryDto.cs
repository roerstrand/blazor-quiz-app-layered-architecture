using System;
using System.Collections.Generic;
using System.Text;

namespace Cyberquiz.Shared.DTOs.AI_DTOs
{
    // DTO för att sammanfatta en användares quizresultat per kategori att skicka till AI-coachen
    public class AiUserSummaryDto
    {
        // Egenskap för att lista användarens quizresultat per kategori
        public List<AiCategoryResultDto> CategoryResults { get; set; }
    }
}
