namespace VersionControlProject.Core.Models.Repository
{
    public class RepositoryModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public int CommitsCount { get; set; }
        public int ContributorsCount { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
