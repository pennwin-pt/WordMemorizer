using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordMemorizer.Core.DB.Models
{
    public class ConsumeLog
    {
        public int Id { get; set; }
        public int ConsumedScore { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
