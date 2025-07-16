using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EduTrack.Core.Application.DTOs;

namespace EduTrack.Core.Application.Interfaces
{
    public interface IAuthservice
    {
        Task<LoginResponseDto?> LoginAsync(LoginRequestDto request);

        Task<bool> SignUp(SignUpRequestDTO request);

    }
}
