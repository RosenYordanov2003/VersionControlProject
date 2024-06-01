namespace VersionControlProject.Data.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using VersionControlProject.Models;
    using static VersionnControlProject.GlobalConstants.EntityValidations.RepositoryValidation;
    public class Repository
    {
        public Repository()
        {
            Commits = new HashSet<Commit>();
            Contributors = new HashSet<UserRepositoryContributor>();
            Issues = new HashSet<Issue>();
            PullRequests = new HashSet<PullRequest>();
        }
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(NAME_MAX_LENGTH)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(VISIBILITY_MAX_LENGTH)]
        public string Visibility { get; set; } = null!;
        public DateTime CreatedOn { get; set; }

        [ForeignKey(nameof(Owner))]
        public Guid OwnerId { get; set; }
        public User Owner { get; set; } = null!;
        public ICollection<Commit> Commits { get; set; }
        public ICollection<Issue> Issues { get; set; }
        public ICollection<UserRepositoryContributor> Contributors { get; set; }
        public ICollection<PullRequest> PullRequests { get; set; }
    }
}
