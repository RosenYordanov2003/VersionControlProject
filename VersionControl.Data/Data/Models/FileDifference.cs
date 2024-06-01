namespace VersionControlProject.Data.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class FileDifference
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Description { get; set; } = null!;
        [ForeignKey(nameof(Modification))]
        public int ModificationId { get; set; }
        public Modification Modification { get; set; } = null!;
    }
}
