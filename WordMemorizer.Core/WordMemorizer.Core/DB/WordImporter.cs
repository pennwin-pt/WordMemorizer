using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

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

        public (int ImportedWordCount, int AddedToPlanCount) ImportToCurrentWeekPlan(string text)
        {
            // 1. 检查当前周计划是否存在
            if (_weeklyPlanRepo.CurrentWeekPlanExists())
            {
                throw new InvalidOperationException("本周学习计划已存在，请勿重复创建！");
            }

            // 2. 解析文本
            var words = ParseTextToWords(text);
            int importedWordCount = 0;
            int addedToPlanCount = 0;

            // 3. 创建本周计划（不使用事务）
            int planId = _weeklyPlanRepo.CreateCurrentWeekPlan();

            // 4. 导入单词并添加到计划
            foreach (var word in words)
            {
                try
                {
                    // 检查单词是否已存在（允许冗余则不需要检查）
                    // 直接插入单词（即使重复）
                    int wordId = _wordRepo.AddWord(word);
                    importedWordCount++;

                    // 添加到周计划
                    _weeklyPlanRepo.AddWordToWeeklyPlan(planId, wordId);
                    addedToPlanCount++;
                }
                catch (Exception ex)
                {
                    // 记录错误但继续导入其他单词
                    Debug.WriteLine($"导入单词失败: {word.Text}, 错误: {ex.Message}");
                }
            }

            return (importedWordCount, addedToPlanCount);
        }

        public (int ImportedWordCount, int AddedToPlanCount) SafeImportToCurrentWeekPlan(string text)
        {
            if (_weeklyPlanRepo.CurrentWeekPlanExists())
            {
                throw new InvalidOperationException("本周学习计划已存在！");
            }

            var words = ParseTextToWords(text);
            int planId = _weeklyPlanRepo.CreateCurrentWeekPlan();
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
                    Debug.WriteLine($"导入失败: {word.Text}, 错误: {ex.Message}");
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
                    Text = wordText,
                    ChineseMeaning = chineseMeaning,
                    ExampleSentence = exampleSentence,
                    ExampleChinese = exampleChinese,
                    DifficultyLevel = 3
                });
            }

            return words;
        }
    }
}
