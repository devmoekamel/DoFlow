using System.ComponentModel.DataAnnotations.Schema;

namespace FreelanceManager.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public string Currency { get; set; }
        public string Notes { get; set; }

        public int ProjectId { get; set; }

        [ForeignKey(nameof(ProjectId))]
        public Project? Project { get; set; }
    }
}
