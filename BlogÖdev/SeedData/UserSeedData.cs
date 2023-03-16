using BlogÖdev.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogÖdev.SeedData
{
    public class UserSeedData : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
                new User { Id = 1, Username = "Admin", Password = "12345" },
                new User { Id = 2, Username = "Member", Password = "1234" });
               
        }
    }
}
