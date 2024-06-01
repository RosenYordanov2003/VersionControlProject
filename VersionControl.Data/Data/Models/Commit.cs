namespace VersionControlProject.Data.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using VersionControlProject.Models;

    public class Commit
    {
        public Commit()
        {
            Modifications = new HashSet<Modification>();
        }
        [Key]
        public Guid Id { get; set; }
        public DateTime CreatedOn { get; set; }
        [Required]
        public string Title { get; set; } = null!;
        [ForeignKey(nameof(Repository))]
        public Guid RepositoryId { get; set; }
        public Repository Repository { get; set; } = null!;
        [ForeignKey(nameof(Creator))]
        public Guid CreatorId { get; set; }
        public User Creator { get; set; } = null!;
        public ICollection<Modification> Modifications { get; set; }
    }
}
