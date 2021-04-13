using Core.Api.Commons;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Model.DTOs;
using Model.Identity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Api.Controllers
{
    [ApiController]
    [Route("identity")]
    public class IdentityController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration; // No auto maper

        public IdentityController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IConfiguration configuration
        ) 
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        // identity/register
        [HttpPost("register")]
        public async Task<IActionResult> Create(ApplicationUserRegisterDto model) 
        {
            var user = new ApplicationUser
            {
                Email = model.Email,
                UserName = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName
            };

            // Al crear usuario agrega por defecto el rol de vendedor por defecto
            var result = await _userManager.CreateAsync(user, model.Password);
            await _userManager.AddToRoleAsync(user, RoleHelper.Seller);

            if (!result.Succeeded) 
            {
                throw new Exception("No se pudo crear el usuario.");
            }

            return Ok();
        }

        // identity/login
        [HttpPost("login")]
        public async Task<IActionResult> Login(ApplicationUserLoginDto model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            var check = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);

            if (check.Succeeded)
            {
                return Ok(
                    await GenerateToken(user)
                );
            }
            else 
            {
                return BadRequest("Acceso no valido al sistema.");
            }
        }

        private async Task<string> GenerateToken(ApplicationUser user) 
        {
            // Retornamos la propiedad que definimos en appsettings.json
            var secretKey = _configuration.GetValue<string>("SecretKey");
            // Lo convertimos a byte
            var key = Encoding.ASCII.GetBytes(secretKey);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.FirstName),
                new Claim(ClaimTypes.Surname, user.LastName)
            };

            var roles = await _userManager.GetRolesAsync(user);

            foreach (var role in roles) 
            {
                claims.Add(
                    new Claim(ClaimTypes.Role, role)
                );
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            // Finalmente se crea el toquen con la informacion que enviamos
            var tokenHandler = new JwtSecurityTokenHandler();
            var createdToken = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(createdToken);
        }
    }
}
