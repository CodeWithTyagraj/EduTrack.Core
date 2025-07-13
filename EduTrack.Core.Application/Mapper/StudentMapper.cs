using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EduTrack.Core.Application.DTOs;
using EduTrack.Core.Domain.Entities;

namespace EduTrack.Core.Application.Mapper
{
    public static class StudentMapper
    {
        public static StudentSendDto ToDto(Student student)
        {
            return new StudentSendDto
            {
                Id = student.Id,
                FullName = student.FullName,
                Email = student.Email
                //  DepartmentName = student.Department?.Name ?? "N/A"
            };
        }
        public static Student ToEntity(StudentCreateDto student)
        {
            return new Student
            {
                FullName = student.FullName,
                Email = student.Email,
                DateOfBirth = student.DateOfBirth,
                Gender = student.Gender,
                DepartmentId = student.DepartmentId
            };
        }
    }
}
   