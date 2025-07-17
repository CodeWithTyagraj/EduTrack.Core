using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.Core.Domain.Entities
{
    public class Admin
    {
        public int Id { get; set; }
        public string FullName { get; set; } = null!;

        public string EmailId { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public int DeptId { get; set; } = 0;
    }   
}
