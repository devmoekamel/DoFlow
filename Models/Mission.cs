namespace FreelanceManager.Models
{
    public class Mission
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string Priority { get; set; }
        public DateTime Deadline { get; set; }

        [ForeignKey("Project")]
        public int ProjectId { get; set; }

        public Project? Project { get; set; }
        public List<TimeTracking>? TimeTracking { get; set; }

    }
}
