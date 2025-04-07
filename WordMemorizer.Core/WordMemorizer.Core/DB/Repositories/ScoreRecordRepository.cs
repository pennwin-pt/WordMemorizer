using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Dapper;
using WordMemorizer.Core.DB.Models;

namespace WordMemorizer.Core.DB.Repositories
{
    public class ScoreRecordRepository
    {
        /// <summary>
        /// 添加一条评分记录
        /// </summary>
        public int AddScoreRecord(ScoreRecord record)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                return conn.ExecuteScalar<int>(@"
                    INSERT INTO ScoreRecord 
                    (WordId, ReviewTime, IsCorrect, AudioPath, Notes)
                    VALUES (@WordId, @ReviewTime, @IsCorrect, @AudioPath, @Notes);
                    SELECT last_insert_rowid()", record);
            }
        }

        /// <summary>
        /// 获取单词的所有评分记录
        /// </summary>
        public List<ScoreRecord> GetRecordsByWord(int wordId)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                return conn.Query<ScoreRecord, Word, ScoreRecord>(@"
                    SELECT sr.*, w.* 
                    FROM ScoreRecord sr
                    JOIN Words w ON sr.WordId = w.Id
                    WHERE sr.WordId = @WordId
                    ORDER BY sr.ReviewTime DESC",
                    (sr, w) => { sr.Word = w; return sr; },
                    new { WordId = wordId },
                    splitOn: "Id").ToList();
            }
        }

        /// <summary>
        /// 获取用户某天的评分记录
        /// </summary>
        public List<ScoreRecord> GetRecordsByDate(DateTime date)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                return conn.Query<ScoreRecord, Word, ScoreRecord>(@"
                    SELECT sr.*, w.* 
                    FROM ScoreRecord sr
                    JOIN Words w ON sr.WordId = w.Id
                    WHERE DATE(sr.ReviewTime) = DATE(@Date)
                    ORDER BY sr.ReviewTime DESC",
                    (sr, w) => { sr.Word = w; return sr; },
                    new { Date = date },
                    splitOn: "Id").ToList();
            }
        }

        /// <summary>
        /// 获取单词的最后一次评分记录
        /// </summary>
        public ScoreRecord GetLatestRecordForWord(int wordId)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                return conn.QueryFirstOrDefault<ScoreRecord>(@"
                    SELECT * FROM ScoreRecord
                    WHERE WordId = @WordId
                    ORDER BY ReviewTime DESC
                    LIMIT 1",
                    new { WordId = wordId });
            }
        }

        /// <summary>
        /// 更新记录的备注信息
        /// </summary>
        public bool UpdateRecordNotes(int recordId, string notes)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                int affected = conn.Execute(@"
                    UPDATE ScoreRecord 
                    SET Notes = @Notes 
                    WHERE Id = @Id",
                    new { Id = recordId, Notes = notes });

                return affected > 0;
            }
        }

        public bool SetRecordCorrect(int recordId, string notes)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                int affected = conn.Execute(@"
                    UPDATE ScoreRecord 
                    SET Notes = @Notes, IsCorrect = 1  
                    WHERE Id = @Id",
                    new { Id = recordId, Notes = notes });

                return affected > 0;
            }
        }

        /// <summary>
        /// 删除指定记录
        /// </summary>
        public bool DeleteRecord(int recordId)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                int affected = conn.Execute(@"
                    DELETE FROM ScoreRecord 
                    WHERE Id = @Id",
                    new { Id = recordId });

                return affected > 0;
            }
        }

        internal int GetAllCorrectRecordsCount()
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    return conn.ExecuteScalar<int>(
                        "SELECT COUNT(*) FROM ScoreRecord WHERE IsCorrect = 1");
                }
            }
            catch (Exception ex)
            {
                // 记录日志并返回-1表示错误
                Debug.WriteLine($"获取正确记录数失败: {ex.Message}");
                return -1;
            }
        }
    }
}
