namespace VersionControlProject.Core.Models.Repository
{
    using System.ComponentModel.DataAnnotations;
    using static VersionnControlProject.GlobalConstants.EntityValidations.RepositoryValidation;
    public class CreateRepositoryModel
    {
        [Required]
        [MaxLength(VISIBILITY_MAX_LENGTH)]
        public string Visibility { get; set; } = null!;

        [Required]
        [MaxLength(NAME_MAX_LENGTH)]
        public string Name { get; set; } = null!;
        public Guid UserId { get; set; }
    }
}
