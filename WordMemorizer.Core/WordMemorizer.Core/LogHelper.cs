﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordMemorizer.Core
{
    internal class LogHelper
    {
        private static readonly object obj = new object();
        /// <summary>  
        /// 操作日志  
        /// </summary>  
        /// <param name="s">日志内容</param>  
        public static void WriteLog(string title, string content)
        {
            WriteLogs(title, content, "操作日志");
        }
        /// <summary>  
        /// 错误日志  
        /// </summary>  
        /// <param name="s">日志内容</param>  
        public static void WriteError(string title, string content)
        {
            WriteLogs(title, content, "错误日志");
        }
        /// <summary>  
        /// debug日志  
        /// </summary>  
        /// <param name="s">日志内容</param>  
        public static void WriteDebug(string title, string content)
        {
            lock (obj)
            {
                string path = AppDomain.CurrentDomain.BaseDirectory;
                if (!string.IsNullOrEmpty(path))
                {
                    path = AppDomain.CurrentDomain.BaseDirectory + "debugLog";
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    path = path + "\\" + DateTime.Now.ToString("yyyyMM");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    path = path + "\\" + DateTime.Now.ToString("yyyyMMdd") + ".log";
                    if (!File.Exists(path))
                    {
                        FileStream fs = File.Create(path);
                        fs.Close();
                    }
                    if (File.Exists(path))
                    {
                        StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.Default);
                        sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff") + " " + title);
                        sw.WriteLine("" + content);
                        sw.WriteLine("----------------------------------------");
                        sw.Close();
                    }
                }
            }
        }

        public static void WriteLogs(string title, string content, string type)
        {
            lock (obj)
            {
                string path = AppDomain.CurrentDomain.BaseDirectory;
                if (!string.IsNullOrEmpty(path))
                {
                    path = AppDomain.CurrentDomain.BaseDirectory + "log";
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    path = path + "\\" + DateTime.Now.ToString("yyyyMM");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    path = path + "\\" + DateTime.Now.ToString("yyyyMMdd") + ".log";
                    if (!File.Exists(path))
                    {
                        FileStream fs = File.Create(path);
                        fs.Close();
                    }
                    if (File.Exists(path))
                    {
                        StreamWriter sw = new StreamWriter(path, true, System.Text.Encoding.Default);
                        sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " " + title);
                        sw.WriteLine("日志类型：" + type);
                        sw.WriteLine("详情：" + content);
                        sw.WriteLine("----------------------------------------");
                        sw.Close();
                    }
                }
            }
        }
    }
}
