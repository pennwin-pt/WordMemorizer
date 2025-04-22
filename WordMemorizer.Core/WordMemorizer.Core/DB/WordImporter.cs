using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using WordMemorizer.Core.DB.Models;
using WordMemorizer.Core.DB.Repositories;

namespace WordMemorizer.Core.DB
{
    public class WordImporter
    {
        private readonly WordRepository _wordRepo;
        private readonly WeeklyPlanRepository _weeklyPlanRepo;

        public WordImporter(WordRepository wordRepo, WeeklyPlanRepository weeklyPlanRepo)
        {
            _wordRepo = wordRepo;
            _weeklyPlanRepo = weeklyPlanRepo;
        }

        public (int ImportedWordCount, int AddedToPlanCount) AppendToCurrentWeekPlan(string text)
        {
            var words = ParseTextToWords(text);
            if (!_weeklyPlanRepo.CurrentWeekPlanExists())
            {
                 _weeklyPlanRepo.CreateCurrentWeekPlan();
            }
            int planId = _weeklyPlanRepo.GetCurrentWeekPlanId();

            int successCount = 0;

            foreach (var word in words)
            {
                try
                {
                    // 直接插入单词（允许冗余）
                    int wordId = _wordRepo.AddWord(word);

                    // 添加到计划
                    _weeklyPlanRepo.AddWordToWeeklyPlan(planId, wordId);
                    successCount++;
                }
                catch (Exception ex)
                {
                    LogHelper.WriteError("导入失败", $"{word.Text}, 错误: {ex.Message}");
                    // 继续处理下一个单词
                }
            }

            return (successCount, successCount); // 两者相同，因为每个单词都尝试添加到计划
        }

        private List<Word> ParseTextToWords(string text)
        {
            var words = new List<Word>();
            var lines = text.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < lines.Length; i++)
            {
                var line = lines[i].Trim();
                if (string.IsNullOrWhiteSpace(line)) continue;

                // 读取单词
                var wordText = line;

                // 读取中文释义
                if (++i >= lines.Length) break;
                var chineseMeaning = lines[i].Trim();

                // 初始化例句变量
                string exampleSentence = null;
                string exampleChinese = null;

                // 检查是否有例句
                if (i + 1 < lines.Length && lines[i + 1].StartsWith("Ex:"))
                {
                    exampleSentence = lines[i + 1].Substring(3).Trim();

                    // 检查是否有例句中文翻译
                    if (i + 2 < lines.Length )
                    {
                        exampleChinese = lines[i + 2].Trim();
                        i += 2;
                    }
                    else
                    {
                        i += 1;
                    }
                }

                words.Add(new Word
                {
                    Text = Tools.EliminatePathSeperator(wordText),
                    ChineseMeaning = Tools.EliminatePathSeperator(chineseMeaning),
                    ExampleSentence = Tools.EliminatePathSeperator(exampleSentence),
                    ExampleChinese = Tools.EliminatePathSeperator(exampleChinese),
                    LatestScore = 0
                });
            }

            return words;
        }
    }
}
