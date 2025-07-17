
namespace EduTrack.Core.Domain.Entities
{
    public class Department
    {
       
        public int Id { get; set; }

        public string DeptName { get; set; } = null!;
        public DateTime crd { get; set; }
        public DateTime Lmd { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
