using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Model;
using Model.Identity;
using Persistence.Database.Config;

namespace Persistence.Database
{
    //Esta clase realiza las consultas a la base de datos atrabes del ORM EntitiFrameworkCore e instalamoDbContext
    //instalamos identityiCore para generar las tablas de usuario y creamos clases perrsonalizadas para poder modificar sus propiedades

    public class ApplicationDbContext : 
        IdentityDbContext<ApplicationUser, ApplicationRole, string, IdentityUserClaim<string>,
        ApplicationUserRole, IdentityUserLogin<string>,
        IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        // Los DbSet son las propiedades que nos permiten manipular las tablas
        // Se crea un DbSet por cada Clase
        // update-database

        public DbSet<Client> Clients { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder) 
        {
            base.OnModelCreating(builder);

            new ClientConfig(builder.Entity<Client>());
            new OrderConfig(builder.Entity<Order>());
            new OrderDetailConfig(builder.Entity<OrderDetail>());
            new ProductConfig(builder.Entity<Product>());

            //Instancia de las tablas de usuarios
            new ApplicationUserConfig(builder.Entity<ApplicationUser>());
            new ApplicationRoleConfig(builder.Entity<ApplicationRole>());
        }
    }
    //Seleccionamos appCore como proyect predeterminado y hacemos la migracion desde este proyect con: add-migration Initialize
    // Imstalamos las tools de EFCT 
}
