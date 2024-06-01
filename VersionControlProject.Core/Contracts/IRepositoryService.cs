namespace VersionControlProject.Core.Contracts
{
    using Models.Repository;
    public interface IRepositoryService
    {
        Task CreateRepositoryAsync(Guid userId, CreateRepositoryModel model);
        Task<bool> CheckIfRepositoryExistsAsync(Guid repositoryId);
        Task AddContributorToRepository(Guid contributorId, Guid repositoryId);
        Task<IEnumerable<RepositoryModel>> GetUserRepositoriesAsync(Guid userId);
    }
}
