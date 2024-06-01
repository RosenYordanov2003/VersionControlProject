namespace VersionControlProject.Data.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;
    public class CommitEntityConfiguration : IEntityTypeConfiguration<Commit>
    {
        public void Configure(EntityTypeBuilder<Commit> builder)
        {
            builder.HasMany(c => c.Modifications)
                 .WithOne(m => m.Commit)
                 .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
