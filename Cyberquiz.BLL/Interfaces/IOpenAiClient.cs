namespace Cyberquiz.BLL.Interfaces
{
    public interface IOpenAiClient
    {
        Task<string> GetFeedback(string prompt);
    }
}
