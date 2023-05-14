using AutoMapper;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using OnlineStoreApp.DTOs;
using OnlineStoreApp.Exceptions;
using OnlineStoreApp.Interfaces;
using OnlineStoreApp.Interfaces.IServices;
using OnlineStoreApp.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BC = BCrypt.Net;

namespace OnlineStoreApp.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        public AuthService(IUnitOfWork unitOfWork, IConfiguration configuration, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
            _mapper = mapper;
        }

        public async Task<string> Login(LoginDTO loginDTO)
        {
            var user = await _unitOfWork.Users.Get(x => x.Email == loginDTO.Email);
            if(user == null)
                throw new NotFoundException($"Incorrect email. Try again.");

            if (!BC.BCrypt.Verify(loginDTO.Password, user.Password))
                throw new BadRequestException("Invalid password");

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                new Claim("Id", user.Id.ToString()),
                new Claim("Email", user.Email!),
                new Claim("Type", user.Type.ToString())
            };
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: signIn);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public void Logout()
        {
            throw new NotImplementedException();
        }

        public async Task Register(RegisterDTO registerDTO)
        {
            if ((await _unitOfWork.Users.Get(x => x.Email == registerDTO.Email)) != null)
                throw new BadRequestException("Email already exists.");

            if ((await _unitOfWork.Users.Get(x => x.Username == registerDTO.Username)) != null)
                throw new BadRequestException("Username already exists.");

            registerDTO.Password = BC.BCrypt.HashPassword(registerDTO.Password);

            var user = _mapper.Map<User>(registerDTO);
            await _unitOfWork.Users.Insert(user);
            await _unitOfWork.Save();
        }
    }
}
