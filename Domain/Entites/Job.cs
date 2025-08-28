using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMind.Domain.Entites
{
    public enum JobStatus
    {
        Draft,
        Opened,
        Closed
    }
    public class Job
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public JobStatus Status { get; set; } = JobStatus.Draft;
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual List<Application> Applications { get; set; }
        public List<string> Requirmement { get; set; }

    }
}
