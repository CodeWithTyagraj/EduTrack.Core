using EduTrack.Core.Application.DTOs;
using EduTrack.Core.Application.Interfaces;
using EduTrack.Core.Domain.Entities;
using EduTrack.Core.Domain.Interfaces;
using EduTrack.Core.Application.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.Core.Application.Services
{
    public class StudentService:IStudentService
    {
        private readonly IStudentRepository _repository;
        public StudentService( IStudentRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<StudentSendDto>> GetAllAsync()
        {
            var students = await _repository.GetAllAsync();
            return students.Select(StudentMapper.ToDto).ToList();
        }

        public async Task<StudentSendDto?> GetByIdAsync(int id)
        {

            var student = await _repository.GetByidAsync(id);
            return student != null ? StudentMapper.ToDto(student) : null;

        }
        public async Task AddAsync(StudentCreateDto student)
        {
            var students = StudentMapper.ToEntity(student);   
            await _repository.AddAsync(students);        
        }


        public async Task UpdateAsync(StudentCreateDto student)
        {
            var students = StudentMapper.ToEntity(student);
            await _repository.UpdateAsync(students);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
      
    }
}