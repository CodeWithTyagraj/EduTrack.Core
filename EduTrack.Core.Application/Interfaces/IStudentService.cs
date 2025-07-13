using EduTrack.Core.Application.DTOs;
using EduTrack.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.Core.Application.Interfaces
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentSendDto>> GetAllAsync();
        Task<StudentSendDto?> GetByIdAsync(int id);
        Task AddAsync(StudentCreateDto student);
        Task UpdateAsync(StudentCreateDto student);
        Task DeleteAsync(int id);
    }
}
