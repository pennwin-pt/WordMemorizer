using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordMemorizer.Core
{
    public class Constants
    {
        internal static readonly string MODE = "debug";
        internal static readonly string DefaultDBPwd = "123123";
        internal static readonly string DB_FILE_NAME = "WordMemorizer.db";
        internal static readonly int INVALID_DB_ID = -1;
        internal static readonly int WORDS_COUNT_PER_DAY = 6;
        internal static readonly string UNLOCK_PASSWORD = "7771";

        /// <summary>
        /// INI文件的key
        /// </summary>
        internal static readonly string AUDIO_PATH_KEY = "AudioFolder";


        /// <summary>
        /// 文件夹路径
        /// </summary>
        internal static readonly string AUDIO_PATH_WORDS = "words";
        internal static readonly string AUDIO_PATH_SENTENCES = "sentences";
        internal static readonly string RECORDING_PATH = "recordings";
        internal static readonly string DEFAULT_AUDIO_PATH = "../../audio";
        internal static readonly string CORRECT_AUDIO_PATH = "./SoundEffect/success.wav";
        internal static readonly string INCORRECT_AUDIO_PATH = "./SoundEffect/failed.wav";
        internal static readonly string INCORRECT_IMAGE_PATH = "./Images/failed.gif";
        internal static readonly string CORRECT_IMAGE_PATH = "./Images/correct.gif";
        internal static readonly string PROCESSING_IMAGE_PATH = "./Images/processing.gif";
        internal static readonly string LISTENING_IMAGE_PATH = "./Images/listening.gif";
        internal static readonly string GIVEUP_RECORDING_PATH = INCORRECT_AUDIO_PATH;


        /// <summary>
        /// 一些值
        /// </summary>
        internal static readonly double WORDS_SIMILARITY_THRESHOLD_PT = 0.6;
        internal static readonly double WORDS_SIMILARITY_THRESHOLD_ZH = 0.3;
        internal static readonly int SCORES_PER_WORD = 5;

        /// <summary>
        /// 按钮文本
        /// </summary>
        internal static readonly string BTN_TEXT_RESTART = "重新开始";
        internal static readonly string BTN_TEXT_CONTINUE = "继续";

        public enum DayType
        {
            Yesterday = 0,
            Today = 1,
            Tomorrow = 2
        }
    }
}
