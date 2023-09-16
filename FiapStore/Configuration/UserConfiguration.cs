using FiapStore.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FiapStore.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).HasColumnType("INT").UseIdentityColumn();
            builder.Property(u => u.Name).HasColumnType("VARCHAR(100)");
            builder.Property(u => u.UserName).HasColumnType("VARCHAR(50)").IsRequired();
            builder.Property(u => u.Passaword).HasColumnType("VARCHAR(50)").IsRequired();
            builder.Property(u => u.Passaword).HasConversion<int>().IsRequired(); //string salvaria a descrição do enum, int irá gravar o numero
            builder.HasMany(u => u.OrderList)
                .WithOne(o => o.User)
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
