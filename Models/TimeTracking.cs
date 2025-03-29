using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FreelanceManager.Models
{
    public class TimeTracking
    {
        public int Id { get; set; }
        public DateTime Date { get; set; } 
        public TimeSpan Duration { get; set; }
        public TimeSpan EstimateTime { get; set; }
        public int TaskId { get; set; }
        [ForeignKey(nameof(TaskId))]
        public virtual Mission Mission { get; set; }
    }
}
