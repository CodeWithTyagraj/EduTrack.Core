using BCrypt.Net;
using EduTrack.Core.Application;
using EduTrack.Core.Application.DTOs;
using EduTrack.Core.Application.Interfaces;
using EduTrack.Core.Application.Mapper;
using EduTrack.Core.Domain.Common;
using EduTrack.Core.Domain.Entities;
using EduTrack.Core.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Org.BouncyCastle.Crypto.Generators;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;


namespace EduTrack.Core.Infrastructure.Services
{
    public class Authservice : IAuthservice
    {
        private readonly EduTrackDbContext _context;
        private readonly IConfiguration _configuration;

        public Authservice(EduTrackDbContext context,IConfiguration configuration)
        {
                _context = context;
            _configuration = configuration;
        }
        
        public async Task<LoginResponseDto?> LoginAsync(LoginRequestDto request)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Username == request.Username);
            if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
                return null;

            if (!AppRoles.All.Contains(user.Role))
                return null;
            var Claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role,user.Role)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: Claims,
            expires: DateTime.UtcNow.AddHours(1),
            signingCredentials: creds);

            return new LoginResponseDto
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token)
            };
        }

        public async Task<bool> SignUp(SignUpRequestDTO request)
        {
           if( await _context.Users.AnyAsync(x => x.Username == request.UserName || x.Email == request.Email))
            {
                return false;
            }
         
            var user = UserMapper.ToEntity(request);
            await _context.Users.AddAsync(user);

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
