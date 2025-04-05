using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordMemorizer.Core.DB.Models
{

    public class ReviewHistory
    {
        public int Id { get; set; }
        public int WordId { get; set; }
        public DateTime ReviewTime { get; set; } = DateTime.Now;
        public bool IsCorrect { get; set; }
        public string Notes { get; set; }

        // 导航属性
        public Word Word { get; set; }
    }
}
