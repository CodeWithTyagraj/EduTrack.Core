using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.Core.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Username {  get; set; }   =string.Empty;
        public string Password { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;

        public DateTime crd { get; set; }  = DateTime.UtcNow;

        public DateTime Lmd { get; set; } = DateTime.UtcNow;

        public bool IsActive { get; set; } = true;
    }
}
