using Cyberquiz.BLL.DummyFilesBLL;
using Cyberquiz.BLL.Interfaces;
using Microsoft.AspNetCore.SignalR.Protocol;
using System;
using System.Collections.Generic;
using System.Text;
using static Cyberquiz.BLL.DummyFilesBLL.DummyClassCollection;


namespace Cyberquiz.BLL.Services
{
    // Reglerar åtkomst
    // Använder ResultsService för att hämta information om användarens resultat
    public class ProgressService : IProgressService // Serviceklass implementerar Interface
    {
        // Fält
        private readonly IUserResRepo _resultRepo;
        private readonly IQRepo _questionRepo;

        // Konstruktor
        public ProgressService(
            IUserResRepo resultRepo,
            IQRepo questionRepo)
        {
            _resultRepo = resultRepo;
            _questionRepo = questionRepo;
        }

        // Metod för att avgöra om en subkategori är upplåst - tar ID för användaren och underkategorin som argument
        public async Task<bool> IsSubCategoryUnlockedAsync(string userId, int subCatId)
        {
            // Lokal variabel för att hämta frågor från underkategorin
            var questions = await _questionRepo.GetQsBySubCategoryIdAsync(subCatId);
            // Lokal variabel för att hämta användarens resultat för underkategorin
            var results = await _resultRepo.GetResultsByUserIdAsync(userId, subCatId); // Denna behöver korrigeras baserat på datamodeller Dummies är ej fullständiga!

            // Om inga frågor: returnera false (kan inte låsa upp en subkategori utan frågor)
            if (!questions.Any()) {
                return false;
            }
            double resultsScore = results.Count(res => res.IsCorrect) / (double)questions.Count(); // Ger andel rätt svar i underkatergorin
            return resultsScore >= 0.80;
        }
    }
}
