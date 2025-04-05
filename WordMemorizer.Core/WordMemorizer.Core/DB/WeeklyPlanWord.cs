using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordMemorizer.Core.DB
{
    public class WeeklyPlanWord
    {
        public int WeeklyPlanId { get; set; }
        public int WordId { get; set; }
        public DateTime AddedDate { get; set; } = DateTime.Now;
    }
}
