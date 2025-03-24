using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FreelanceManager.Models
{
    public class TimeTracking
    {
        public int Id { get; set; }
       
        public DateTime Date { get; set; } 
        public TimeSpan Duration { get; set; }
        [DisplayFormat(DataFormatString = @"{0:hh\:mm}")]
        public TimeSpan EstimateTime { get; set; }
        [ForeignKey("Task")] 
        public int TaskId { get; set; }
        public virtual Task Task { get; set; }
    }
}
