using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMind.Domain.Entites
{
    public enum InterviewStatus
    {
        Scheduled,
        Completed,
        Canceled
    }
    public class Interview
    {
        public int Id { get; set; }
        public DateTime ScheduledAt { get; set; }
        public string ZoomLink { get; set; }    
        public InterviewStatus Status { get; set; }=InterviewStatus.Scheduled;
        public int ApplicationId { get; set; }
        public virtual Application Application { get; set; }
    }
}
