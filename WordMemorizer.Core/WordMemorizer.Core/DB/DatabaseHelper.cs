using Dapper;
using System;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace WordMemorizer.Core.DB
{
    public static class DatabaseHelper
    {
        private static string _connectionString;

        public static string DatabasePath { get; } = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Constants.DB_FILE_NAME);

        static DatabaseHelper()
        {
            _connectionString = $"Data Source={DatabasePath};Version=3;";
            InitializeDatabase();
        }

        public static IDbConnection GetConnection()
        {
            return new SQLiteConnection(_connectionString);
        }

        private static void InitializeDatabase()
        {
            if (!File.Exists(DatabasePath))
            {
                SQLiteConnection.CreateFile(DatabasePath);

                using (var conn = GetConnection())
                {
                    conn.Open();

                    // 创建单词表
                    conn.Execute(@"
                        CREATE TABLE Words (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            Text TEXT NOT NULL,
                            Language TEXT DEFAULT 'pt-PT',
                            Phonetic TEXT,
                            ChineseMeaning TEXT NOT NULL,
                            ExampleSentence TEXT,
                            ExampleChinese TEXT,  -- 新增字段：例句中文含义
                            LatestScore INTEGER DEFAULT 0,
                            CreatedTime DATETIME DEFAULT CURRENT_TIMESTAMP,
                            IsMastered INTEGER DEFAULT 0,
                            ReviewCount INTEGER DEFAULT 0,
                            LastReviewTime DATETIME
                        )");

                    // 创建周计划表
                    conn.Execute(@"
                        CREATE TABLE WeeklyPlans (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            WeekNumber INTEGER NOT NULL,
                            StartDate DATETIME NOT NULL,
                            EndDate DATETIME NOT NULL,
                            IsActive INTEGER DEFAULT 0
                        )");

                    // 创建周计划单词关联表
                    conn.Execute(@"
                        CREATE TABLE WeeklyPlanWords (
                            WeeklyPlanId INTEGER NOT NULL,
                            WordId INTEGER NOT NULL,
                            AddedDate DATETIME DEFAULT CURRENT_TIMESTAMP,
                            PRIMARY KEY (WeeklyPlanId, WordId),
                            FOREIGN KEY (WeeklyPlanId) REFERENCES WeeklyPlans(Id),
                            FOREIGN KEY (WordId) REFERENCES Words(Id)
                        )");

                    // 创建复习历史表
                    conn.Execute(@"
                        CREATE TABLE ScoreRecord (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            BatchNumber Text,      --实际上是 yyyyMMddHHmmss的时间
                            WordId INTEGER NOT NULL,
                            RecordTime DATETIME DEFAULT CURRENT_TIMESTAMP,
                            IsCorrect INTEGER DEFAULT 0,
                            AudioPath TEXT,
                            Notes TEXT,
                            FOREIGN KEY (WordId) REFERENCES Words(Id)
                        )");
                }
            }
        }
    }
}
