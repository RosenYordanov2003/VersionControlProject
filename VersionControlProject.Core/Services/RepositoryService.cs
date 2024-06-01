namespace VersionControlProject.Core.Services
{
    using System;
    using System.Threading.Tasks;
    using VersionControlProject.Core.Contracts;
    using VersionControlProject.Core.Models.Repository;
    using VersionControlProject.Data;
    using VersionControlProject.Data.Data.Models;

    public class RepositoryService : IRepositoryService
    {
        private readonly ApplicationDbContext _dbContext;

        public RepositoryService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateRepositoryAsync(Guid userId, CreateRepositoryModel model)
        {
            Repository repository = new Repository()
            {
                CreatedOn = DateTime.UtcNow,
                Name = model.Name,
                OwnerId = userId,
                Visibility = model.Visibility,
            };

            await _dbContext.Repositories.AddAsync(repository);
            await _dbContext.SaveChangesAsync();
        }
    }
}
