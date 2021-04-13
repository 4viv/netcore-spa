using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model.Identity;
using System;

namespace Persistence.Database.Config
{
    public class ApplicationRoleConfig
    {
        public ApplicationRoleConfig(EntityTypeBuilder<ApplicationRole> entityBuilder)
        {
            // Hecemos las relaciones
            entityBuilder.HasMany(e => e.UserRoles) // Tiene relacion muchos a muchos
                         .WithOne(e => e.Role) // rl campo en comun
                         .HasForeignKey(e => e.RoleId) // ey el campo
                         .IsRequired(); // es requerido

            // Creando los roles para los usuarios

            // Role de Admin
            entityBuilder.HasData(
                new ApplicationRole {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Admin",
                    NormalizedName = "Admin"
                },
                // Role Seller
                new ApplicationRole
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Seller",
                    NormalizedName = "Seller"
                }
            );
        }
    }
}
