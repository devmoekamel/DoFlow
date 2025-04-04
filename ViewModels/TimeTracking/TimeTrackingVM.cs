using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FreelanceManager.ViewModels.TimeTracking
{
    public class TimeTrackingVM
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }
        public TimeSpan Duration { get; set; }
        [DisplayFormat(DataFormatString = @"{0:hh\:mm}")]
        public TimeSpan EstimateTime { get; set; }
        public bool IsDeleted { get; set; }

        public int MissionId { get; set; }
        [ForeignKey(nameof(MissionId))]
        public string MissionName { get; set; }
    }
}
