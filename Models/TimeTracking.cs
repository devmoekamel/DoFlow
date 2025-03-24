using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FreelanceManager.Models
{
    public class TimeTracking
    {
        public int Id { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; } 

        [DataType(DataType.Time)]
        public TimeSpan Duration { get; set; }
        [DisplayFormat(DataFormatString = @"{0:hh\:mm}")]
        public TimeSpan? EstimateTime { get; set; }

        [Required]
        [ForeignKey("Tasks")] 
        public int TaskId { get; set; }
        public virtual Task Tasks { get; set; }
    }
}
