using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordMemorizer.Core.DB.Models;

namespace WordMemorizer.Core.DB.Repositories
{
    public class WeeklyPlanRepository
    {
        public void AddWeeklyPlan(WeeklyPlan plan)
        {
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                conn.Execute(@"
                    INSERT INTO WeeklyPlans (WeekNumber, StartDate, EndDate, IsActive)
                    VALUES (@WeekNumber, @StartDate, @EndDate, @IsActive)", plan);
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
            var (startDate, endDate) = Tools.GetCurrentWeekDateRange();
            var weekNumber = Tools.GetCurrentWeekNumberOfYear();

            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                return conn.ExecuteScalar<bool>(
                    "SELECT 1 FROM WeeklyPlans WHERE StartDate = @StartDate AND EndDate = @EndDate AND WeekNumber = @WeekNumber",
                    new { StartDate = startDate, EndDate = endDate, WeekNumber = weekNumber });
            }
        }

        // 创建当前周计划
        public void CreateCurrentWeekPlan()
        {
            var (startDate, endDate) = Tools.GetCurrentWeekDateRange();
            int weekNumber = Tools.GetCurrentWeekNumberOfYear();

            var plan = new WeeklyPlan
            {
                WeekNumber = weekNumber,
                StartDate = startDate,
                EndDate = endDate,
                IsActive = true
            };

            AddWeeklyPlan(plan);
        }

        // 获取当前周计划的ID
        public int GetCurrentWeekPlanId()
        {
            var (startDate, endDate) = Tools.GetCurrentWeekDateRange();
            var weekNumber = Tools.GetCurrentWeekNumberOfYear();

            using (var conn = DatabaseHelper.GetConnection())
            {
                int? id = conn.QueryFirstOrDefault<int?>(
                    "SELECT Id FROM WeeklyPlans WHERE WeekNumber = @WeekNumber AND StartDate = @StartDate",
                    new { WeekNumber = weekNumber, StartDate = startDate });

                return id ?? Constants.INVALID_DB_ID; // 如果null，返回-1
            }
        }

        internal void DeleteCurrentWeekPlanIfExists()
        {
            var weekNumber = Tools.GetCurrentWeekNumberOfYear();
            var (startDate, endDate) = Tools.GetCurrentWeekDateRange();
            using (var conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                conn.Execute("DELETE FROM WeeklyPlanWords WHERE WeeklyPlanId IN " +
                            "(SELECT Id FROM WeeklyPlans WHERE StartDate = @StartDate and WeekNumber = @WeekNumber)",
                            new { StartDate = startDate, WeekNumber = weekNumber });
                conn.Execute("DELETE FROM WeeklyPlans WHERE StartDate = @StartDate and WeekNumber = @WeekNumber",
                            new { StartDate = startDate, WeekNumber = weekNumber });
            }
        }
    }
}
