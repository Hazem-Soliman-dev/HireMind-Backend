using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public enum ApplicationStatus
    {
        New,
        Shortlisted,
        Rejected,
        Hired
    }
    public class Application
    {
        [Key]
        public int Id { get; set; }
        public int JobId { get; set; }  
        public string CandidateName { get; set; }
        public string CandidateEmail { get; set; }
        public string ResumeUrl { get; set; }   
        public ApplicationStatus Status { get; set; } = ApplicationStatus.New;
        public virtual Job Job { get; set; }
    }
}
