using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMind.Domain.Entites
{
    public class Feedback
    {
        public int Id { get; set; }
        public int ApplicationId { get; set; }
        public string Feedbacktext { get; set; }
        public DateTime SentAt { get; set; } = DateTime.UtcNow;
        public virtual Application Application { get; set; }
    }
}
