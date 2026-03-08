using System;
using System.Collections.Generic;
using System.Text;
using Cyberquiz.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Cyberquiz.DAL.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<CategoryModel> Categories { get; set; } = null!;

        public DbSet<SubCategoryModel> SubCategories { get; set; } = null!;

        public DbSet<AnswerOptionModel> AnswerOptions { get; set; } = null!;

        public DbSet<QuestionAnswerOptionModel> QuestionAnswerOptions { get; set; } = null!;

        public DbSet<UserProgressModel> UserProgress { get; set; } = null!;

        public DbSet<QuestionModel> Questions { get; set; } = null!;

        public DbSet<UserAnswerModel> UserAnswers { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Explicit junction entity med payload (IsCorrect)
            modelBuilder.Entity<QuestionAnswerOptionModel>()
                .HasKey(x => new { x.QuestionId, x.AnswerOptionId });

            modelBuilder.Entity<QuestionAnswerOptionModel>()
                .HasOne(x => x.Question)
                .WithMany(q => q.QuestionAnswerOptions)
                .HasForeignKey(x => x.QuestionId);

            modelBuilder.Entity<QuestionAnswerOptionModel>()
                .HasOne(x => x.AnswerOption)
                .WithMany(a => a.QuestionAnswerOptions)
                .HasForeignKey(x => x.AnswerOptionId);

            // Undvik multipla cascade-paths: Category → SubCategory → Question
            modelBuilder.Entity<QuestionModel>()
                .HasOne(q => q.SubCategory)
                .WithMany(sc => sc.Questions)
                .HasForeignKey(q => q.SubCategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<QuestionModel>()
                .HasOne(q => q.Category)
                .WithMany(c => c.Questions)
                .HasForeignKey(q => q.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserAnswerModel>()
                .HasOne(a => a.UserProgress)
                .WithMany(p => p.UserAnswers)
                .HasForeignKey(a => a.UserProgressId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
