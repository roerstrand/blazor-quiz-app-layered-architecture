namespace Cyberquiz.Shared.DTOs.AI_DTOs
{
    // DTO för att lista en användares resultat per kategori, används i AiUserSummaryDto
    public class AiCategoryResultDto
    {
        // Egenskaper för att hålla information om användarens resultat i en kategori
        public string CategoryName { get; set; }
        public int CorrectPercentage { get; set; }
    }
}