namespace VersionControlProject.Data.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    public class RepositoryEntityConfiguration : IEntityTypeConfiguration<Repository>
    {
        public void Configure(EntityTypeBuilder<Repository> builder)
        {
            builder.HasMany(r => r.Commits)
                 .WithOne(c => c.Repository)
                 .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(r => r.Issues)
                 .WithOne(i => i.Repository)
                 .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(r => r.PullRequests)
                 .WithOne(pr => pr.Repository)
                 .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
