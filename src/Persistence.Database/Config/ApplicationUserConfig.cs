using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Identity;

namespace Persistence.Database.Config
{
    public class ApplicationUserConfig
    {
        public ApplicationUserConfig(EntityTypeBuilder<ApplicationUser> entityBuilder)
        {
            entityBuilder.Property(e => e.FirstName).IsRequired().HasMaxLength(50);
            entityBuilder.Property(e => e.LastName).IsRequired().HasMaxLength(100);

            // Hecemos las relaciones
            entityBuilder.HasMany(e => e.UserRoles) // Tiene relacion muchos a muchos
                         .WithOne(e => e.User) // rl campo en comun
                         .HasForeignKey(e => e.UserId) // ey el campo
                         .IsRequired(); // es requerido
        }
    }
}
