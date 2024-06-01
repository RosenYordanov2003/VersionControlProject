namespace VersionControlProject.Data
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using Data.Models;
    using VersionControlProject.Data.Data.Configurations;

    public class ApplicationDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {

        }
        public DbSet<Repository> Repositories { get; set; }
        public DbSet<Issue> Issues { get; set; }
        public DbSet<Commit> Commits { get; set; }
        public DbSet<FileDifference> FileDifferences { get; set; }
        public DbSet<Modification> Modifications { get; set; }
        public DbSet<PullRequest> PullRequests { get; set; }
        public DbSet<UserRepositoryContributor> UserRepositoryContributors { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new UserRepositoryContributorsEntityConfiguration());
            builder.ApplyConfiguration(new RepositoryEntityConfiguration());
            builder.ApplyConfiguration(new ModificationEntityConfiguration());
            builder.ApplyConfiguration(new CommitEntityConfiguration());
        }
    }
}