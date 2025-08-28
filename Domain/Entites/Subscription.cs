using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HireMind.Domain.Entites
{
   public enum PlantypeSubscription
    {
        Free,
        Pro,
    }
    public class Subscription
    {
        public int Id { get; set; }
        public PlantypeSubscription Plantype { get; set; }=PlantypeSubscription.Free;
        public DateTime Startdate { get; set; }=DateTime.Now;
        public DateTime Enddate { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
