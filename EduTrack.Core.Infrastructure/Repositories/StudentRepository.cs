using EduTrack.Core.Domain.Entities;
using EduTrack.Core.Domain.Interfaces;
using EduTrack.Core.Infrastructure;
using EduTrack.Core.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.Core.Infrastructure.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly EduTrackDbContext _context;

        public StudentRepository(EduTrackDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Student student)
        {
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student != null)
            {
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<Student?> GetByidAsync(int id)
        {
            return await _context.Students.FindAsync(id);
        }
      

        public async Task UpdateAsync(Student student)
        {
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
        }
    }
}
