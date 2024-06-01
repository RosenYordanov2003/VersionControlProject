namespace VersionControlProject.Core.Contracts
{
    using Models.Repository;
    public interface IRepositoryService
    {
        Task CreateRepositoryAsync(Guid userId, CreateRepositoryModel model);
    }
}
