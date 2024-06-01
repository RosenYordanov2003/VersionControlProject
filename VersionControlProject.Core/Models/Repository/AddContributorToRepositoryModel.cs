namespace VersionControlProject.Core.Models.Repository
{
    public class AddContributorToRepositoryModel
    {
        public Guid RepositoryId { get; set; }
        public Guid UserId { get; set; }
    }
}
