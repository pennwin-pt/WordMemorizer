using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordMemorizer.Core
{
    internal class Constants
    {
        internal static readonly string MODE = "debug";
        internal static readonly string DefaultDBPwd = "123123";
        internal static readonly string DB_FILE_NAME = "WordMemorizer.db";
        internal static readonly int INVALID_DB_ID = -1;
        internal static readonly int WORDS_COUNT_PER_DAY = 6;
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
        internal static readonly double WORDS_SIMILARITY_THRESHOLD = 0.6;
    }
}
