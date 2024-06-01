namespace VersionControlProject.Data.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Commit
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        [Required]
        public string Title { get; set; } = null!;
        [ForeignKey(nameof(Repository))]
        public int RepositoryId { get; set; }
        public Repository Repository { get; set; } = null!;
    }
}
