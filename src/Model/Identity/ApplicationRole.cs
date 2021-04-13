using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Model.Identity
{
    public class ApplicationRole : IdentityRole
    {
        // La referencia es de muchos a muchos
        public List<ApplicationUserRole> UserRoles { get; set; }
    }
}
