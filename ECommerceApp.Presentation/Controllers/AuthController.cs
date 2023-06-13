using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System;
using ECommerceApp.Presentation.Models;
using ECommerceApp.Business.Interfaces;
using ECommerceApp.Business.DTOs;
using AutoMapper;

namespace ECommerceApp.Presentation.Controllers
{
    [Route("auth")]
    public class AuthController : Controller
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public AuthController(IUserService userService, IConfiguration configuration, IMapper mapper)
        {
            _userService = userService;
            _configuration = configuration;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult CreateToken([FromBody] UserParam userParam)
        {
            var user = _userService.GetByEmailAndPassword(userParam.Email, userParam.Password);
            if (user is null) throw new InvalidOperationException();
            Token token = new Token();
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Token:SecurityKey"]));
            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            token.Expiration = DateTime.Now.AddDays(1);
            JwtSecurityToken securityToken = new JwtSecurityToken(
                issuer: _configuration["Token:Issuer"],
                audience: _configuration["Token:Audience"],
                expires:token.Expiration,
                notBefore:DateTime.Now,
                signingCredentials: credentials
            );
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            token.AccessToken = tokenHandler.WriteToken(securityToken);
            token.RefreshToken = Guid.NewGuid().ToString();

            user.RefreshToken = token.RefreshToken;
            user.RefreshTokenExpireDate = token.Expiration.AddHours(1);
            _userService.AuthUpdate(user.Id, _mapper.Map<UpdateUserDTO>(user));
            return Ok(token);
        }
        
        [HttpPost("register")]
        public IActionResult GetToken([FromBody] UserParam userParam)
        {
            var id = "userID";

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configuration["Token:SecurityKey"]);

            var tokenDesc = new SecurityTokenDescriptor
            {
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key)
                , SecurityAlgorithms.HmacSha256),
                Expires = DateTime.UtcNow.AddDays(1),
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, id),
                })
            };

            var token = tokenHandler.CreateToken(tokenDesc);
            var tokenString = tokenHandler.WriteToken(token);

            return View();
        }
    }
}
