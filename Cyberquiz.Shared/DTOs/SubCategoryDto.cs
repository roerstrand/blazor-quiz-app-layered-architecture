using System;
using System.Collections.Generic;
using System.Text;

namespace Cyberquiz.Shared.DTOs
{
    public class SubCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; } //Visar SubCategoryn namn
        public string Description { get; set; } = string.Empty; //Visar SubCategoryn beskrivning
        public string CategoryName { get; set; } //Visar Categoryn namn i SubCategoryn
        public int Order { get; set; }
        public bool IsLocked { get; set; }

        public bool IsCompleted { get; set; }
        public int QuestionCount { get; set; }
    }
}
