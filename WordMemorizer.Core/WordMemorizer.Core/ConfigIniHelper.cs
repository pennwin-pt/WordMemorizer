using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordMemorizer.Core
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading;

    public sealed class ConfigIniHelper : IDisposable
    {
        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        private static extern long WritePrivateProfileString(string section, string key, string value, string filePath);

        private const string FileName = "config.ini";
        private const string DefaultSection = "Settings";
        private readonly string _filePath;

        public ConfigIniHelper()
        {
            _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, FileName);
            EnsureFileExists();
        }

        /// <summary>
        /// 动态获取配置值（键不存在时自动添加并返回默认值 "0"）
        /// </summary>
        public string GetValue(string key, string defaultValue = "0")
        {
            string value = GetIniValue(DefaultSection, key);
            if (value == null)
            {
                // 再次检查（避免并发时重复添加）
                value = GetIniValue(DefaultSection, key);
                if (value == null)
                {
                    SetIniValue(DefaultSection, key, defaultValue);
                    return defaultValue;
                }
                return value;
            }
            return value;
        }

        /// <summary>
        /// 动态设置配置值（键不存在时自动添加）
        /// </summary>
        public void SetValue(string key, string value)
        {
             SetIniValue(DefaultSection, key, value);
        }

        /// <summary>
        /// 确保配置文件存在（不存在时创建空文件）
        /// </summary>
        private void EnsureFileExists()
        {
            if (!File.Exists(_filePath))
            {
                File.WriteAllText(_filePath, $"[{DefaultSection}]\n");
            }
        }

        /// <summary>
        /// 从INI文件中读取值（返回null表示键不存在）
        /// </summary>
        private string GetIniValue(string section, string key)
        {
            if (!File.Exists(_filePath))
                return null;

            bool inCorrectSection = false;

            foreach (var line in File.ReadLines(_filePath))
            {
                string trimmedLine = line.Trim();

                // 跳过空行和注释
                if (string.IsNullOrEmpty(trimmedLine) || trimmedLine.StartsWith(";") || trimmedLine.StartsWith("#"))
                    continue;

                // 检查节名
                if (trimmedLine.StartsWith("[") && trimmedLine.EndsWith("]"))
                {
                    string currentSection = trimmedLine.Substring(1, trimmedLine.Length - 2).Trim();
                    inCorrectSection = currentSection.Equals(section, StringComparison.OrdinalIgnoreCase);
                    continue;
                }

                // 如果在正确的节内，查找键值对
                if (inCorrectSection)
                {
                    int equalSignPos = trimmedLine.IndexOf('=');
                    if (equalSignPos > 0)
                    {
                        string currentKey = trimmedLine.Substring(0, equalSignPos).Trim();
                        if (currentKey.Equals(key, StringComparison.OrdinalIgnoreCase))
                        {
                            return trimmedLine.Substring(equalSignPos + 1).Trim();
                        }
                    }
                }
            }

            return null; // 键不存在
        }

        /// <summary>
        /// 写入INI键值（自动添加不存在的键或节）
        /// </summary>
        private void SetIniValue(string section, string key, string value)
        {
            var lines = File.Exists(_filePath) ? File.ReadAllLines(_filePath).ToList() : new List<string>();
            bool sectionFound = false;
            bool keyFound = false;
            int sectionLineIndex = -1;

            for (int i = 0; i < lines.Count; i++)
            {
                string trimmedLine = lines[i].Trim();

                // 检查节名
                if (trimmedLine.StartsWith("[") && trimmedLine.EndsWith("]"))
                {
                    string currentSection = trimmedLine.Substring(1, trimmedLine.Length - 2).Trim();
                    if (currentSection.Equals(section, StringComparison.OrdinalIgnoreCase))
                    {
                        sectionFound = true;
                        sectionLineIndex = i;
                    }
                    continue;
                }

                // 如果在正确的节内，查找键
                if (sectionFound)
                {
                    int equalSignPos = trimmedLine.IndexOf('=');
                    if (equalSignPos > 0)
                    {
                        string currentKey = trimmedLine.Substring(0, equalSignPos).Trim();
                        if (currentKey.Equals(key, StringComparison.OrdinalIgnoreCase))
                        {
                            lines[i] = $"{key}={value}";
                            keyFound = true;
                            break;
                        }
                    }
                }
            }

            // 处理键不存在的情况
            if (!keyFound)
            {
                if (!sectionFound)
                {
                    // 添加新节和新键
                    lines.Add($"[{section}]");
                    lines.Add($"{key}={value}");
                }
                else
                {
                    // 在节下方添加新键
                    int insertPos = sectionLineIndex + 1;
                    while (insertPos < lines.Count &&
                           !string.IsNullOrWhiteSpace(lines[insertPos]) &&
                           !lines[insertPos].Trim().StartsWith("["))
                    {
                        insertPos++;
                    }
                    lines.Insert(insertPos, $"{key}={value}");
                }
            }

            File.WriteAllLines(_filePath, lines);
        }

        public void Dispose()
        {
        }
    }
}
