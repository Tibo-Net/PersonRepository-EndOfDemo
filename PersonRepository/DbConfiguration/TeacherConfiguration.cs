using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonRepository.Model;

namespace PersonRepository.DbConfiguration;

public class TeacherConfiguration : PersonConfiguration<Teacher>, IEntityTypeConfiguration<Teacher>
{
    public override void Configure(EntityTypeBuilder<Teacher> builder) => base.Configure(builder);
}

