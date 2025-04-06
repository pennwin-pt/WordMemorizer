using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordMemorizer.Core.Score
{
    public class PointsSystem
    {

        public PointsSystem()
        {
        }

        public bool CanEarnPointsToday(int userId, string word)
        {
            return true;
        }

        public void AwardPoints(int userId, string word, float score)
        {
            
        }

        public int GetTodayTotalPoints(int userId)
        {
            return 10;
        }
    }
}
