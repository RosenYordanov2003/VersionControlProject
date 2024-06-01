namespace VersionControlProject.Models
{
    using Microsoft.AspNetCore.Identity;
    using VersionControlProject.Data.Data.Models;

    public class User : IdentityUser<Guid>
    {
        public User()
        {
            OwnedRepositories = new HashSet<Repository>();
            RepositoryContributors = new HashSet<UserRepositoryContributor>();
        }
        public ICollection<Repository> OwnedRepositories { get; set; }
        public ICollection<UserRepositoryContributor> RepositoryContributors { get; set; }
    }
}