using System;
using System.Collections.Generic;
using System.Data;
using Dapper;

namespace WordMemorizer.Core.DB
{
    public class WordRepository
    {
        // 修改AddWord方法
        public int AddWord(Word word)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                return conn.ExecuteScalar<int>(@"
            INSERT INTO Words 
            (Text, Language, Phonetic, ChineseMeaning, ExampleSentence, ExampleChinese, DifficultyLevel)
            VALUES 
            (@Text, @Language, @Phonetic, @ChineseMeaning, @ExampleSentence, @ExampleChinese, @DifficultyLevel);
            SELECT last_insert_rowid()", word);
            }
        }

        public Word GetWordById(int id)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                return conn.QueryFirstOrDefault<Word>("SELECT * FROM Words WHERE Id = @Id", new { Id = id });
            }
        }

        public IEnumerable<Word> GetAllWords()
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                return conn.Query<Word>("SELECT * FROM Words ORDER BY CreatedTime DESC");
            }
        }
        

        // 修改UpdateWord方法
        public bool UpdateWord(Word word)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                return conn.Execute(@"
            UPDATE Words SET 
                Text = @Text,
                Language = @Language,
                Phonetic = @Phonetic,
                ChineseMeaning = @ChineseMeaning,
                ExampleSentence = @ExampleSentence,
                ExampleChinese = @ExampleChinese,
                DifficultyLevel = @DifficultyLevel,
                IsMastered = @IsMastered,
                ReviewCount = @ReviewCount,
                LastReviewTime = @LastReviewTime
            WHERE Id = @Id", word) > 0;
            }
        }

        public bool DeleteWord(int id)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                int affectedRows = conn.Execute("DELETE FROM Words WHERE Id = @Id", new { Id = id });
                return affectedRows > 0;
            }
        }
    }

    public class WeeklyPlanRepository
    {
        public int AddWeeklyPlan(WeeklyPlan plan)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                return conn.ExecuteScalar<int>(@"
                    INSERT INTO WeeklyPlans (WeekNumber, StartDate, EndDate, IsActive)
                    VALUES (@WeekNumber, @StartDate, @EndDate, @IsActive);
                    SELECT last_insert_rowid()", plan);
            }
        }

        public void AddWordToWeeklyPlan(int weeklyPlanId, int wordId)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                conn.Execute(@"
                    INSERT INTO WeeklyPlanWords (WeeklyPlanId, WordId)
                    VALUES (@WeeklyPlanId, @WordId)",
                    new { WeeklyPlanId = weeklyPlanId, WordId = wordId });
            }
        }


        public IEnumerable<Word> GetWordsInWeeklyPlan(int weeklyPlanId)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                return conn.Query<Word>(@"
                    SELECT w.* FROM Words w
                    INNER JOIN WeeklyPlanWords wpw ON w.Id = wpw.WordId
                    WHERE wpw.WeeklyPlanId = @WeeklyPlanId",
                    new { WeeklyPlanId = weeklyPlanId });
            }
        }

         // 检查当前周是否已有计划
    public bool CurrentWeekPlanExists()
    {
        var (startDate, endDate) = GetCurrentWeekDateRange();
        
        using (var conn = DatabaseHelper.GetConnection())
        {
            conn.Open();
            return conn.ExecuteScalar<bool>(
                "SELECT 1 FROM WeeklyPlans WHERE StartDate = @StartDate AND EndDate = @EndDate",
                new { StartDate = startDate, EndDate = endDate });
        }
    }
    
    // 获取当前周的日期范围（周日至周六）
    public (DateTime StartDate, DateTime EndDate) GetCurrentWeekDateRange()
    {
        DateTime today = DateTime.Today;
        int daysSinceSunday = (int)today.DayOfWeek; // 0=周日, 1=周一,...,6=周六
        
        DateTime startDate = today.AddDays(-daysSinceSunday);
        DateTime endDate = startDate.AddDays(6);
        
        return (startDate.Date, endDate.Date);
    }
    
    // 创建当前周计划
    public int CreateCurrentWeekPlan()
    {
        var (startDate, endDate) = GetCurrentWeekDateRange();
        int weekNumber = GetWeekNumberOfYear(startDate);
        
        var plan = new WeeklyPlan
        {
            WeekNumber = weekNumber,
            StartDate = startDate,
            EndDate = endDate,
            IsActive = true
        };
        
        return AddWeeklyPlan(plan);
    }
    
    // 获取一年中的周数
    private int GetWeekNumberOfYear(DateTime date)
    {
        var culture = System.Globalization.CultureInfo.CurrentCulture;
        return culture.Calendar.GetWeekOfYear(
            date, 
            culture.DateTimeFormat.CalendarWeekRule, 
            culture.DateTimeFormat.FirstDayOfWeek);
    }
    
    }

    public class ReviewRepository
    {
        public void AddReviewHistory(ReviewHistory history)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                conn.Execute(@"
                    INSERT INTO ReviewHistories (WordId, ReviewTime, IsCorrect, Notes)
                    VALUES (@WordId, @ReviewTime, @IsCorrect, @Notes)", history);

                // 更新单词的复习状态
                conn.Execute(@"
                    UPDATE Words SET 
                        ReviewCount = ReviewCount + 1,
                        LastReviewTime = @ReviewTime,
                        IsMastered = CASE WHEN @IsCorrect = 1 THEN IsMastered ELSE 0 END
                    WHERE Id = @WordId",
                    new { history.WordId, history.ReviewTime, history.IsCorrect });
            }
        }

        public IEnumerable<ReviewHistory> GetReviewHistoriesByWord(int wordId)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                return conn.Query<ReviewHistory>(
                    "SELECT * FROM ReviewHistories WHERE WordId = @WordId ORDER BY ReviewTime DESC",
                    new { WordId = wordId });
            }
        }
    }
}