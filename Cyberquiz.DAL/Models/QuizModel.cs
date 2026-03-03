using System;
using System.Collections.Generic;
using System.Text;

namespace Cyberquiz.DAL.Models
{
    public class QuizModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public ICollection<QuestionModel> Questions { get; set; }

        public int? SubCategoryId { get; set; }
        public SubCategoryModel? SubCategory { get; set; }
    }
}

