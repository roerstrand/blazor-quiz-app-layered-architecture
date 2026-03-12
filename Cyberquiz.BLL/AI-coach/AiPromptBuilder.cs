using Cyberquiz.Shared.DTOs.AI_DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cyberquiz.BLL.AI_coach
{
    public class AiPromptBuilder : IAiPromptBuilder
    {
        // Promptbuilder för att formatera användarens quizresultat för AI att analysera och feedbacka
        // Separerad från Servicen: uppfyller single responsibility-principen
        public string BuildUserAnalysisPrompt(AiUserSummaryDto summary)
        {
            var categories = string.Join("\n",
                summary.CategoryResults.Select(c =>
                    $"- {c.CategoryName}: {c.CorrectPercentage}% correct"));

            return $"""
                    You are an AI learning coach helping a user improve their quiz performance.

                    User quiz statistics:
                    {categories}

                    Your task:
                    1. Identify the user's strengths
                    2. Identify the user's weaknesses
                    3. Recommend what the user should practice next

                    Keep the answer short and structured.

                    Format:

                    Strengths:
                    - ...

                    Weaknesses:
                    - ...

                    Recommendations:
                    - ...
                    """;
        }
    }
}
