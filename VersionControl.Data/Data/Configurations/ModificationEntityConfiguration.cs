namespace VersionControlProject.Data.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    public class ModificationEntityConfiguration : IEntityTypeConfiguration<Modification>
    {
        public void Configure(EntityTypeBuilder<Modification> builder)
        {
            builder.HasMany(m => m.FileDifferences)
                 .WithOne(fd => fd.Modification)
                 .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
