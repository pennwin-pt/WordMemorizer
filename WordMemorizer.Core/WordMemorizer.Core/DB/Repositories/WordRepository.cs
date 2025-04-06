using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using WordMemorizer.Core.DB.Models;

namespace WordMemorizer.Core.DB.Repositories
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
            (Text, Language, Phonetic, ChineseMeaning, ExampleSentence, ExampleChinese, LatestScore)
            VALUES 
            (@Text, @Language, @Phonetic, @ChineseMeaning, @ExampleSentence, @ExampleChinese, @LatestScore);
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
                LatestScore = @LatestScore,
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

    

    
}