using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApplicationV1._0.Data;

namespace WebApplicationV1._0.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController(JwtOptions jwtOptions , ApplicationDbContext _context) : ControllerBase
    {
        [HttpPost]
        public ActionResult<string> AuthenticateUser(AuthenticationRequest request)
        {
            var user = _context.Set<User>().FirstOrDefault(x => x.Name == request.UserName &&
            x.Password == request.Password);

            if (user == null)
                return Unauthorized();

            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = jwtOptions.Issuer,
                Audience = jwtOptions.Audience,
                SigningCredentials = new SigningCredentials(
                   new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.SigningKey)),
                   SecurityAlgorithms.HmacSha256),
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new (ClaimTypes.NameIdentifier , user.Id.ToString()),
                    new (ClaimTypes.NameIdentifier , user.Name),
                    new (ClaimTypes.Email, "a@b.com")
                    
                })
            }; 
            
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            var accessToken = tokenHandler.WriteToken(securityToken);

            return Ok(accessToken);
        }

    }
}
