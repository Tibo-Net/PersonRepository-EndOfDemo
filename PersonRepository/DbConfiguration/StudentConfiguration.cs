using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonRepository.Model;

namespace PersonRepository.DbConfiguration;

public class StudentConfiguration : PersonConfiguration<Student>, IEntityTypeConfiguration<Student>
{
    public override void Configure(EntityTypeBuilder<Student> builder) => base.Configure(builder);
}
