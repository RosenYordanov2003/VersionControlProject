namespace VersionControlProject.Core.Services
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;
    using Contracts;
    using Models.Repository;
    using Data;
    using Data.Data.Models;

    public class RepositoryService : IRepositoryService
    {
        private readonly ApplicationDbContext _dbContext;

        public RepositoryService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddContributorToRepository(Guid contributorId, Guid repositoryId)
        {
            UserRepositoryContributor userRepositoryContributor = new UserRepositoryContributor()
            {
                RepositoryId = repositoryId,
                UserId = contributorId
            };
            await _dbContext.UserRepositoryContributors.AddAsync(userRepositoryContributor);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> CheckIfRepositoryExistsAsync(Guid repositoryId)
        {
            return await _dbContext.Repositories.AnyAsync(r => r.Id == repositoryId);
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
