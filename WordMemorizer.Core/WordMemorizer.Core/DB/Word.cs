using System;
using System.Collections.Generic;
using Dapper;

namespace WordMemorizer.Core.DB
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

        // 导航属性
        public List<WeeklyPlan> WeeklyPlans { get; set; } = new List<WeeklyPlan>();
        public List<ReviewHistory> ReviewHistories { get; set; } = new List<ReviewHistory>();
    }

    public class WeeklyPlan
    {
        public int Id { get; set; }
        public int WeekNumber { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }

        // 导航属性
        public List<Word> Words { get; set; } = new List<Word>();
    }

    public class WeeklyPlanWord
    {
        public int WeeklyPlanId { get; set; }
        public int WordId { get; set; }
        public DateTime AddedDate { get; set; } = DateTime.Now;
    }

    public class ReviewHistory
    {
        public int Id { get; set; }
        public int WordId { get; set; }
        public DateTime ReviewTime { get; set; } = DateTime.Now;
        public bool IsCorrect { get; set; }
        public string Notes { get; set; }

        // 导航属性
        public Word Word { get; set; }
    }
}
