using System;
using System.Collections.Generic;
using Dapper;

namespace WordMemorizer.Core.DB.Models
{
    public class Word
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Language { get; set; } = "pt-PT";
        public string Phonetic { get; set; }
        public string ChineseMeaning { get; set; }
        public string ExampleSentence { get; set; }
        public string ExampleChinese { get; set; } // 新增属性

        public int DifficultyLevel { get; set; } = 3;
        public DateTime CreatedTime { get; set; } = DateTime.Now;
        public bool IsMastered { get; set; }
        public int ReviewCount { get; set; }
        public DateTime? LastReviewTime { get; set; }
    }
}
