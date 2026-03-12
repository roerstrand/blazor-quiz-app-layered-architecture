using System;
using System.Collections.Generic;
using System.Text;

namespace Cyberquiz.BLL.AI_coach
{
    public class OpenAiClient
    {
        Task<string> GetFeedback(string prompt);
    }
}
