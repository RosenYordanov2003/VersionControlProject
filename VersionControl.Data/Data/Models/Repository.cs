namespace VersionControlProject.Data.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using VersionControlProject.Models;
    using static VersionnControlProject.GlobalConstants.EntityValidations.RepositoryValidation;
    public class Repository
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(NAME_MAX_LENGTH)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(VISIBILITY_MAX_LENGTH)]
        public string Visibility { get; set; } = null!;
        public DateTime CreatedOn { get; set; }

        [ForeignKey(nameof(User))]
        public Guid Owner { get; set; }
        public User User { get; set; } = null!;
    }
}
