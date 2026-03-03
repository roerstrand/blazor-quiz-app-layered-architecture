using System;
using System.Collections.Generic;
using System.Text;

namespace Cyberquiz.DAL.Models
{
    public class QuestionModel
    {
        public int Id { get; set; }

        public string Question { get; set; }

        public ICollection<QuestionAnswerOptionModel> QuestionAnswerOptions { get; set; }

        public int CategoryId { get; set; }
        public CategoryModel Category { get; set; }

        public int SubCategoryId { get; set; }
        public SubCategoryModel SubCategory { get; set; }
    }
}
