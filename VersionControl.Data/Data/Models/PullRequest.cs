namespace VersionControlProject.Data.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using VersionControlProject.Models;

    public class PullRequest
    {
        public PullRequest()
        {
            Commits = new HashSet<Commit>();
        }
        [Key]
        public int Id { get; set; }
        public ICollection<Commit> Commits { get; set; }
        [ForeignKey(nameof(Repository))]
        public Guid RepositoryId { get; set; }

        public Repository Repository { get; set; } = null!;
        [ForeignKey(nameof(Sender))]
        public Guid SenderId { get; set; }
        public User Sender { get; set; } = null!;
    }
}
