namespace FreelanceManager.ViewModels.Project
{
    public class AddProjectVM
    {
		public string Name { get; set; }
		public double Budget { get; set; }
		public double HourlyRate { get; set; }
		public string Company { get; set; }
		public string Priority { get; set; }
		public string Description { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public int ClientId { get; set; }

	}
}
