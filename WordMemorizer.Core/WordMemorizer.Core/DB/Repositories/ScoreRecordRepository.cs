using System;
using System.Collections.Generic;
using System.Data.Common;
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
                    (BatchNumber, WordId, RecordTime, IsCorrect, AudioPath, Notes, IsPortuguese)
                    VALUES (@BatchNumber, @WordId, @RecordTime, @IsCorrect, @AudioPath, @Notes, @IsPortuguese);
                    SELECT last_insert_rowid()", record);
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
                    WHERE DATE(sr.RecordTime) = DATE(@Date)
                    ORDER BY sr.RecordTime DESC",
                    (sr, w) => { sr.Word = w; return sr; },
                    new { Date = date },
                    splitOn: "Id").ToList();
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

        public bool SetRecordInCorrect(int recordId, string notes)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                int affected = conn.Execute(@"
                    UPDATE ScoreRecord 
                    SET Notes = @Notes, IsCorrect = 0  
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
                LogHelper.WriteError("数据库", $"获取正确记录数失败: {ex.Message}");
                return -1;
            }
        }

        internal List<string> GetBatchNumbersForCurrentWeek()
        {
            try
            {
                var today = DateTime.Today;
                int daysSinceSunday = (int)today.DayOfWeek;
                var startOfWeek = today.AddDays(-daysSinceSunday);
                var endOfWeek = startOfWeek.AddDays(7).AddSeconds(-1);

                string startStr = startOfWeek.ToString("yyyyMMdd000000");
                string endStr = endOfWeek.ToString("yyyyMMdd235959");

                using (var conn = DatabaseHelper.GetConnection())
                {
                    var sql = @"
                SELECT DISTINCT BatchNumber 
                FROM ScoreRecord
                WHERE BatchNumber BETWEEN @Start AND @End
                ORDER BY BatchNumber DESC";

                    return conn.Query<string>(sql, new { Start = startStr, End = endStr }).ToList();
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("数据库", $"获取本周 BatchNumber 失败: {ex.Message}");
                return new List<string>(); // 返回空列表表示出错
            }
        }

        internal List<ScoreRecord> GetRecordsByBatchNumberEx(string batchNumber)
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    var sql = "SELECT * FROM ScoreRecord WHERE BatchNumber = @BatchNumber";
                    return conn.Query<ScoreRecord>(sql, new { BatchNumber = batchNumber }).ToList();
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("数据库", $"获取 BatchNumber 为 {batchNumber} 的记录失败: {ex.Message}");
                return new List<ScoreRecord>(); // 出错时返回空列表
            }
        }
        internal List<ScoreRecord> GetRecordsByBatchNumber(string batchNumber)
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    var sql = @"
                SELECT sr.*, w.* 
                FROM ScoreRecord sr
                JOIN Words w ON sr.WordId = w.Id
                WHERE sr.BatchNumber = @BatchNumber
                ORDER BY sr.RecordTime DESC";

                    return conn.Query<ScoreRecord, Word, ScoreRecord>(
                            sql,
                            (sr, w) => { sr.Word = w; return sr; },
                            new { BatchNumber = batchNumber },
                            splitOn: "Id"
                        ).ToList();
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteError("数据库", $"获取 BatchNumber 为 {batchNumber} 的记录失败: {ex.Message}");
                return new List<ScoreRecord>(); // 出错时返回空列表
            }
        }


    }
}
