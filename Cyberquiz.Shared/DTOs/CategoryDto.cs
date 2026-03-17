using System;
using System.Collections.Generic;
using System.Text;

namespace Cyberquiz.Shared.DTOs
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty; // Shows the category name
        public string Description { get; set; } = string.Empty; // Shows the category description

        public int CompletedSubCategories { get; set; } // Shows how many subcategories are completed in the category
        public int TotalSubCategories { get; set; } // Shows how many subcategories exist in the category
        public int QuestionCount { get; set; } // Shows the total number of questions in the category
        public List<SubCategoryDto> SubCategories { get; set; } = new(); // Shows a list of subcategories in the category

    }
}
