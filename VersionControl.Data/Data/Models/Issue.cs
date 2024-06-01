namespace VersionControlProject.Data.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using VersionControlProject.Models;
    using static VersionnControlProject.GlobalConstants.EntityValidations.IssueValidataion;

    public class Issue
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey(nameof(Creator))]
        public Guid CreatorId { get; set; }
        public User Creator { get; set; } = null!;
        [Required]
        [MaxLength(TITLE_MAX_LENGTH)]
        public string Title { get; set; } = null!;
        [Required]
        [MaxLength(STATUS_MAX_LENGTH)]
        public string Status { get; set; } = null!;
        public DateTime CreatedOn { get; set; }
        [ForeignKey(nameof(Repository))]
        public Guid RepositoryId { get; set; }
        public Repository Repository { get; set; } = null!;
    }
}
