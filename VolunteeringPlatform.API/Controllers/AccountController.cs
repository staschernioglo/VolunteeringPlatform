using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using VolunteeringPlatform.API.Infrastructure.Configurations;
using VolunteeringPlatform.Bll.Interfaces;
using VolunteeringPlatform.Common.Dtos.Account;
using VolunteeringPlatform.Domain.Auth;

namespace VolunteeringPlatform.API.Controllers
{
    [AllowAnonymous]
    [Route("api/account")]
    public class AccountController : BaseController
    {
        private readonly AuthOptions _authenticationOptions;
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly IAzureStorageService _azureStorageService;
        private readonly IMapper _mapper;

        public AccountController(IOptions<AuthOptions> authenticationOptions, SignInManager<User> signInManager,
            UserManager<User> userManager, RoleManager<Role> roleManager, IAzureStorageService azureStorageService, IMapper mapper)
        {
            _authenticationOptions = authenticationOptions.Value;
            _signInManager = signInManager;
            _userManager = userManager;
            _azureStorageService = azureStorageService;
            _mapper = mapper;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {
            var checkingPasswordResult = await _signInManager.PasswordSignInAsync(userForLoginDto.Username, userForLoginDto.Password, false, false);

            if (checkingPasswordResult.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(userForLoginDto.Username);
                var userId = user.Id.ToString();
                var claims = new List<Claim> { new Claim(JwtRegisteredClaimNames.NameId, userId) };

                var signinCredentials = new SigningCredentials(_authenticationOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256);
                var jwtSecurityToken = new JwtSecurityToken(
                     issuer: _authenticationOptions.Issuer,
                     audience: _authenticationOptions.Audience,
                     claims: claims,
                     expires: DateTime.Now.AddDays(30),
                     signingCredentials: signinCredentials
                );

                var tokenHandler = new JwtSecurityTokenHandler();

                var encodedToken = tokenHandler.WriteToken(jwtSecurityToken);

                return Ok(new { AccessToken = encodedToken });
            }

            return Unauthorized();
        }

        [HttpPost("register/user")]
        public async Task<IActionResult> RegisterUser(UserForRegisterDto userForRegisterDto)
        {
            if (ModelState.IsValid)
            {
                User user = _mapper.Map<User>(userForRegisterDto);

                if (userForRegisterDto.Photo != null)
                {
                    var imageProps = await _azureStorageService.UploadAsync(userForRegisterDto.Photo, "users");
                    user.ImageName = imageProps.ImageName;
                    user.ImageUrl = imageProps.ImageUrl;
                }
                else
                {
                    user.ImageUrl = "https://msdocsstoragefunc.blob.core.windows.net/users/default.png";
                }

                var result = await _userManager.CreateAsync(user, userForRegisterDto.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "user");
                    await _signInManager.SignInAsync(user, false);
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return Ok(userForRegisterDto);
        }

        [HttpPost("register/organization")]
        public async Task<IActionResult> RegisterOrganization(OrganizationForRegisterDto organizationForRegisterDto)
        {
            if (ModelState.IsValid)
            {
                User user = _mapper.Map<Organization>(organizationForRegisterDto);

                if (organizationForRegisterDto.Image != null)
                {
                    var imageProps = await _azureStorageService.UploadAsync(organizationForRegisterDto.Image, "users");
                    user.ImageName = imageProps.ImageName;
                    user.ImageUrl = imageProps.ImageUrl;
                }
                else
                {
                    user.ImageUrl = "https://msdocsstoragefunc.blob.core.windows.net/users/default.png";
                }

                var result = await _userManager.CreateAsync(user, organizationForRegisterDto.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "organization");
                    await _signInManager.SignInAsync(user, false);
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return Ok(organizationForRegisterDto);
        }

        [HttpPost("register/volunteer")]
        public async Task<IActionResult> RegisterVolunteer(VolunteerForRegisterDto volunteerForRegisterDto)
        {
            if (ModelState.IsValid)
            {
                User user = _mapper.Map<Volunteer>(volunteerForRegisterDto);

                if (volunteerForRegisterDto.Photo != null)
                {
                    var imageProps = await _azureStorageService.UploadAsync(volunteerForRegisterDto.Photo, "users");
                    user.ImageName = imageProps.ImageName;
                    user.ImageUrl = imageProps.ImageUrl;
                }
                else
                {
                    user.ImageUrl = "https://msdocsstoragefunc.blob.core.windows.net/users/default.png";
                }

                var result = await _userManager.CreateAsync(user, volunteerForRegisterDto.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "volunteer");
                    await _signInManager.SignInAsync(user, false);
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return Ok(volunteerForRegisterDto);
        }

        //[HttpPost]
        //public async Task<IActionResult> CreateSomething(IFormFile file)
        //{

        //    await _azureStorageService.UploadAsync(file, "users");

        //    return Ok();
        //}

    }
}
