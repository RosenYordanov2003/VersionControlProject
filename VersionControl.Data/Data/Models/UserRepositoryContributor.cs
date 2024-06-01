namespace VersionControlProject.Data.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;
    using VersionControlProject.Models;
    public class UserRepositoryContributor
    {
        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;
        [ForeignKey(nameof(Repository))]
        public Guid RepositoryId { get; set; }
        public Repository Repository { get; set; } = null!;
    }
}
