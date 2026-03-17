namespace Cyberquiz.Shared.DTOs.AI_DTOs
{
    // DTO for listing a user's results per category, used in AiUserSummaryDto
    public class AiCategoryResultDto
    {
        // Properties to hold information about the user's results in a category
        public string CategoryName { get; set; }
        public int CorrectPercentage { get; set; }
    }
}
