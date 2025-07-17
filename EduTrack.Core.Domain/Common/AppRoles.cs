using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.Core.Domain.Common
{
    public class AppRoles
    {
        public static string Admin = "Admin";
        public static string Teacher = "Teacher";
        public static string Student = "Student";


        public static readonly string[] All =  {Admin, Teacher, Student };
    }
}
