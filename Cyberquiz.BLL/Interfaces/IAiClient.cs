namespace Cyberquiz.BLL.Interfaces
{
    public interface IAiClient
    {
        Task<string> GetFeedback(string prompt);
    }
}
