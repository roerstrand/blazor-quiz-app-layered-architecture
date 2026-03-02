using System;
using System.Collections.Generic;
using System.Text;
using static Cyberquiz.BLL.DummyFilesBLL.DummyClassCollection; // Kan tas bort senare

namespace Cyberquiz.BLL.DummyFilesBLL
{
    public interface IUserResRepo
    {
        Task AddAsync(UserResult result);
        Task<UserResult?> GetLatestAsync(string userId, int subCategoryId);
        Task<List<UserResult>> GetByUserAsync(string userId);
        Task<List<UserResult>> GetResultsByUserIdAsync(string userId, int subCatId);
        Task SaveAsync(UserResult userResult);
    }
}
