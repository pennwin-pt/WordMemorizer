using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordMemorizer.Core.DB.Models
{
    public class WeeklyPlan
    {
        public int Id { get; set; }
        public int WeekNumber { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }

        // 导航属性
        public List<Word> Words { get; set; } = new List<Word>();
    }
}
