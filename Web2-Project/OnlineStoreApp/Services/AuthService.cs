using AutoMapper;
using Microsoft.AspNetCore.Identity;
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
        private readonly IMailService _mailService;

        public AuthService(IUnitOfWork unitOfWork, IConfiguration configuration, IMapper mapper, IMailService mailService)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
            _mapper = mapper;
            _mailService = mailService;
        }

        public async Task<string> Login(LoginDTO loginDTO)
        {
            var user = await _unitOfWork.Users.Get(x => x.Email == loginDTO.Email);
            if(user == null)
                throw new NotFoundException($"Incorrect email. Try again.");

            if (!BC.BCrypt.Verify(loginDTO.Password, user.Password))
                throw new BadRequestException("Invalid password");

            if(user.Type == UserType.Seller)
            {
                if(user.VerificationStatus == VerificationStatus.Waiting)
                    throw new BadRequestException("You are not verified. Wait to be verified by administrators.");
                if (user.VerificationStatus == VerificationStatus.Declined)
                    throw new BadRequestException("You were declined by administrators. Contact to see why.");
            }   
                

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Username!),
                new Claim(ClaimTypes.Role, user.Type.ToString()),
                new Claim("Id", user.Id.ToString()),
                new Claim("Email", user.Email!),
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
            if(registerDTO.Type == UserType.Administrator)
                throw new BadRequestException("Can't register admin user!");

            if ((await _unitOfWork.Users.Get(x => x.Email == registerDTO.Email)) != null)
                throw new BadRequestException("Email already exists.");

            if ((await _unitOfWork.Users.Get(x => x.Username == registerDTO.Username)) != null)
                throw new BadRequestException("Username already exists.");

            registerDTO.Password = BC.BCrypt.HashPassword(registerDTO.Password);

            var user = _mapper.Map<User>(registerDTO);
            user.VerificationStatus = user.Type == UserType.Seller ? VerificationStatus.Waiting : VerificationStatus.Accepted;
            
            if (user.Type == UserType.Seller)
                await _mailService.SendEmail("Account verification", "Sorry to keep you waiting, the first available administrator will verify your account.", user.Email!);
            await _unitOfWork.Users.Insert(user);
            await _unitOfWork.Save();
        }
    }
}
