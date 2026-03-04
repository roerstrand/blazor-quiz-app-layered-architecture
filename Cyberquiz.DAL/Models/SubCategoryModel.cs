using System;
using System.Collections.Generic;
using System.Text;

namespace Cyberquiz.DAL.Models
{
    public class SubCategoryModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; } = string.Empty;

        public int Order { get; set; }

        public int CategoryId { get; set; }
        public CategoryModel Category { get; set; }

        public ICollection<QuestionModel> Questions { get; set; }

        public int QuestionCount => Questions?.Count ?? 0;
    }
}
