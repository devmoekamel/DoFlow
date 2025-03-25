using System.ComponentModel.DataAnnotations.Schema;

namespace FreelanceManager.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public String Status { get; set; }
        public String Currency { get; set; }
        public String Notes { get; set; }

        public int ProjectId { get; set; }

        [ForeignKey(nameof(ProjectId))]
        public Project? project { get; set; }
    }
}
