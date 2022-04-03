using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonRepository.Model;

namespace PersonRepository.DbConfiguration;

public abstract class PersonConfiguration<TPerson> : IEntityTypeConfiguration<TPerson> where TPerson : Person
{
    public virtual void Configure(EntityTypeBuilder<TPerson> builder)
    {
        builder.Property(x => x.FirstName).HasMaxLength(50);
        builder.Property(x => x.LastName).HasMaxLength(50);
        //builder.Navigation(x => x.Birthday).AutoInclude();
        builder.OwnsOne(x => x.Birthday);
    }
}
