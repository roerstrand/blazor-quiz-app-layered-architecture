using System;
using System.Collections.Generic;
using System.Text;
using Cyberquiz.Shared.DTOs.AI_DTOs;

namespace Cyberquiz.BLL.AI_coach
{
    public interface IAiPromptBuilder
    {
        string BuildUserAnalysisPrompt(AiUserSummaryDto summary);
    }
}
