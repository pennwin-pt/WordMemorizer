using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordMemorizer.Core.DB.Models;

namespace WordMemorizer.Core.DB.Repositories
{
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
