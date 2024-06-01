namespace VersionControlProject.Data.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;
    public class UserRepositoryContributorsEntityConfiguration : IEntityTypeConfiguration<UserRepositoryContributor>
    {
        public void Configure(EntityTypeBuilder<UserRepositoryContributor> builder)
        {
            builder.HasKey(ck => new { ck.UserId, ck.RepositoryId });

            builder.HasOne(urc => urc.User)
                .WithMany(u => u.RepositoryContributors)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(urc => urc.Repository)
                .WithMany(r => r.Contributors)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
