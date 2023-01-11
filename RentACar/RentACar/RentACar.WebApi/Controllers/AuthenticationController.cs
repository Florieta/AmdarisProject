using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RentACar.Application.Abstract;
using RentACar.Domain.Entitites;
using RentACar.Domain.Entitites.Identity;
using RentACar.WebApi.ViewModels.Users;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace RentACar.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IDealerRepository _repo;
        private readonly IRenterRepository _repoRenter;
        private readonly IUnitOfWork _unitOfWork;
        public AuthenticationController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IDealerRepository repo, IUnitOfWork unitOfWork, IRenterRepository repoRenter)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _repo = repo;
            _unitOfWork = unitOfWork;
            _repoRenter = repoRenter;
        }

        [HttpPost]
        [Route("login")]

        public async Task<IActionResult> Login([FromBody] UserLoginViewModel userLoginModel)
        {
            var user = await _userManager.FindByNameAsync(userLoginModel.UserName);
            var id = await _userManager.GetUserIdAsync(user);

            if (user != null && await _userManager.CheckPasswordAsync(user, userLoginModel.Password))
            {
                var authClaims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, userLoginModel.UserName),
                    new Claim("user_id",id)


                };

                var userRoles = await _userManager.GetRolesAsync(user);
                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }
                var authSigInKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("this is my custom Secret key for authentication"));

                var token = new JwtSecurityToken(
                    issuer: "https://localhost:7016/",
                    claims: authClaims,
                    expires: DateTime.Now.AddHours(1),
                    signingCredentials: new SigningCredentials(authSigInKey, SecurityAlgorithms.HmacSha256)
                    );
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo,
                    token_id = id,
                    user = user
                });

            }
            return Unauthorized();
        }


        [HttpPost]
        [Route("register/dealer")]
        public async Task<IActionResult> RegisterAsDealer([FromBody] UserAuthViewModel userAuthModel)
        {
            var userExists = await _userManager.FindByNameAsync(userAuthModel.UserName);

            if (userExists != null)
                return BadRequest("User is already registered");


            ApplicationUser newUser = new ApplicationUser
            {
                FirstName = userAuthModel.FirstName,
                LastName = userAuthModel.LastName,
                PhoneNumber = userAuthModel.PhoneNumber,
                Email = userAuthModel.Email,
                UserName = userAuthModel.UserName,
            };

            var result = await _userManager.CreateAsync(newUser, userAuthModel.Password);

            Dealer dealer = new Dealer
            {
                CompanyName = userAuthModel.CompanyName,
                CompanyNumber = userAuthModel.CompanyNumber,
                Address = userAuthModel.Address,
                ApplicationUser = newUser,
                ApplicationUserId = newUser.Id
            };
            await _repo.AddAsync(dealer);
            await _unitOfWork.SaveAsync();

            if (!result.Succeeded)
            {
                return BadRequest("Failed to create user");
            }
            return Ok("User Created Succesfuly");
        }

        [HttpPost]
        [Route("register/renter")]
        public async Task<IActionResult> RegisterAsRenter([FromBody] UserRenterViewModel userRenterModel)
        {
            var userExists = await _userManager.FindByNameAsync(userRenterModel.UserName);

            if (userExists != null)
                return BadRequest("User is already registered");


            ApplicationUser newUser = new ApplicationUser
            {
                FirstName = userRenterModel.FirstName,
                LastName = userRenterModel.LastName,
                PhoneNumber = userRenterModel.PhoneNumber,
                Email = userRenterModel.Email,
                UserName = userRenterModel.UserName,
            };

            var result = await _userManager.CreateAsync(newUser, userRenterModel.Password);

           Renter renter = new Renter
            {
                Age = userRenterModel.Age,
                DrivingLicenceNumber = userRenterModel.DrivingLicenceNumber,
                ExpiredDate = userRenterModel.ExpiredDate,
                Address = userRenterModel.Address,
                ApplicationUser = newUser,
                ApplicationUserId = newUser.Id
            };
            await _repoRenter.AddAsync(renter);
            await _unitOfWork.SaveAsync();

            if (!result.Succeeded)
            {
                return BadRequest("Failed to create user");
            }
            return Ok("User Created Succesfuly");
        }

        [HttpPost]
        [Route("logout")]
        [Authorize]
        public IActionResult Logout()
        {

            Response.Headers.Remove("Authorization");
            //_logger.LogInformation($"User [{userName}] logged out the system.");
            return Ok();
        }

    }
}
