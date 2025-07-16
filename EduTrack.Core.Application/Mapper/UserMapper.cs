using BCrypt.Net;
using EduTrack.Core.Application.DTOs;
using EduTrack.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.Core.Application.Mapper
{
    public static class UserMapper
    {
        public static User ToEntity(SignUpRequestDTO user)
        {
            return new User
            {
                Username = user.UserName,
                Password = BCrypt.Net.BCrypt.HashPassword(user.Password),
                Email = user.Email,
                Role = user.Role  ,
                IsActive = true ,
            };


        }
    }
}
