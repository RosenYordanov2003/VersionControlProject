namespace VersionControlProject.Data.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using static VersionnControlProject.GlobalConstants.EntityValidations.ModificationValidation;

    public class Modification
    {
        public Modification()
        {
            FileDifferences = new HashSet<FileDifference>();
        }
       
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(Commit))]
        public Guid CommitId { get; set; }
        public Commit Commit { get; set; } = null!;
        [Required]
        public string FileName { get; set; } = null!;
        [MaxLength(MODIFICATION_TYPE_MAX_LENGTH)]
        public string ModificationType { get; set; } = null!;
        public ICollection<FileDifference> FileDifferences { get; set; }
    }
}
