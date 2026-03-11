using System;
using System.Collections.Generic;
using System.Text;

namespace Cyberquiz.Shared.DTOs
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty; //Visar Categoryn namn
        public string Description { get; set; } = string.Empty; //Visar Categoryn beskrivning

        public int CompletedSubCategories { get; set; } //Visar hur många SubCategoryn som är avklarade i Categoryn
        public int TotalSubCategories { get; set; } //Visar hur många SubCategoryn det finns i Categoryn
        public int QuestionCount { get; set; } //Visar totalt antal frågor i Categoryn
        public List<SubCategoryDto> SubCategories { get; set; } = new(); //Visar en lista av SubCategoryn i Categoryn

    }
}