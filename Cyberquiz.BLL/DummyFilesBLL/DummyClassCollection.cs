using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cyberquiz.BLL.DummyFilesBLL
{
    public class DummyClassCollection
    {
        // Dummy-klasser
        public class Category { }
        public class SubCategory { }
        public class Question
        {
            public AnswerOption AnswerOption { get; internal set; } = new();
        }
        public class AnswerOption
        {
            public int Id { get; set; }
        }
        public class CorrectAnswer 
        {
            public bool IsCorrect;
        }
        public class UserResult 
        {
            public string UserId { get; set; }
            public int QuestionId { get; set; }
            public bool IsCorrect { get; set; }
        }

    }
}
