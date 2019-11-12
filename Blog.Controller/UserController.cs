namespace Blog.Controller
{
    using Model.Models;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Identity;
    using Newtonsoft.Json.Linq;
    using Blog.Transportation.Helper;
    using Microsoft.Extensions.Options;
    using System.Threading.Tasks;
    using System;
    using System.Text;
    using Microsoft.IdentityModel.Tokens;
    using System.Security.Claims;
    using System.IdentityModel.Tokens.Jwt;
    using Blog.Controller.Models;
    using System.Linq;

    [Route("api/[controller]")]
    public class UserController: Controller
    {
        private readonly UserManager<IdentityUser> userManager;

        private readonly SignInManager<IdentityUser> signManager;

        private readonly AppSettings jwtToken;
        private readonly BlogDbContext db;

        public UserController(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            IOptions<AppSettings> jwtToken,
            BlogDbContext db
            )
        {
            this.userManager = userManager;
            this.signManager = signInManager;
            this.jwtToken = jwtToken.Value;
            this.db = db;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
        {
            // Will hold all the errors related to registration
            List<string> errorList = new List<string>();

            var user = new IdentityUser
            {
                Email = model.Email,
                UserName = model.Username,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var result = await userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, "Customer");
                return Ok(new { username = user.UserName, email = user.Email, status = 1, message = "Registration Successful" });

            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                    errorList.Add(error.Description);
                }
            }

            return BadRequest(new JsonResult(errorList));
        }

        // Login Method
        [HttpPost("[action]")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            // Get the User from Database
            var user = await userManager.FindByNameAsync(model.Username);

            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtToken.Secret));

            double tokenExpiryTime = Convert.ToDouble(jwtToken.ExpireTime);

            if (user != null && await userManager.CheckPasswordAsync(user, model.Password))
            {

                // THen Check If Email Is confirmed
                if (!await userManager.IsEmailConfirmedAsync(user))
                {
                    ModelState.AddModelError(string.Empty, "User Has not Confirmed Email.");

                    return Unauthorized(new { LoginError = "We sent you an Confirmation Email. Please Confirm Your Registration With Techhowdy.com To Log in." });
                }

                // get user Role
                var roles = await userManager.GetRolesAsync(user);

                var tokenHandler = new JwtSecurityTokenHandler();

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, model.Username),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(ClaimTypes.NameIdentifier, user.Id),
                        new Claim(ClaimTypes.Role, roles.FirstOrDefault()),
                        new Claim("LoggedOn", DateTime.Now.ToString()),

                     }),

                    SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature),
                    Issuer = jwtToken.Site,
                    Audience = jwtToken.Audience,
                    Expires = DateTime.UtcNow.AddMinutes(tokenExpiryTime)
                };

                // Generate Token

                var token = tokenHandler.CreateToken(tokenDescriptor);

                return Ok(new { token = tokenHandler.WriteToken(token), expiration = token.ValidTo, username = user.UserName, userRole = roles.FirstOrDefault() });

            }

            // return error
            ModelState.AddModelError("", "Username/Password was not Found");
            return Unauthorized(new { LoginError = "Please Check the Login Credentials - Ivalid Username/Password was entered" });
        }

        [HttpGet("[action]")]
        public IActionResult getRoles()
        {
            return Ok(db.Roles.ToList());
        }

        [HttpGet("[action]")]
        public IActionResult getNumbers()
        {
            return Ok("abc");
        }

        public IActionResult getArticles()
            => Ok(db.Articles.ToList());
    }
}
