using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using WordMemorizer.Core.DB.Models;

namespace WordMemorizer.Core.DB.Repositories
{
    public class ConsumeLogRepository
    {

        public ConsumeLogRepository()
        {
        }

        /// <summary>
        /// 添加消费记录
        /// </summary>
        /// <param name="consumedScore">消费的积分数</param>
        /// <returns>新记录的ID</returns>
        public int AddConsumeRecord(int consumedScore)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                return conn.ExecuteScalar<int>(@"
                    INSERT INTO ConsumeLog (ConsumedScore)
                    VALUES (@ConsumedScore);
                    SELECT last_insert_rowid()",
                    new { ConsumedScore = consumedScore });
            }
        }

        /// <summary>
        /// 获取累计消费积分总和
        /// </summary>
        public int GetTotalConsumedScore()
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                return conn.ExecuteScalar<int>("SELECT SUM(ConsumedScore) FROM ConsumeLog");
            }
        }

        /// <summary>
        /// 获取所有消费记录（按时间倒序）
        /// </summary>
        public List<ConsumeLog> GetAllConsumeLogs()
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                return conn.Query<ConsumeLog>(
                    "SELECT * FROM ConsumeLog ORDER BY CreatedTime DESC").ToList();
            }
        }

        
    }
}