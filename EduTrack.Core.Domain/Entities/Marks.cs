using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrack.Core.Domain.Entities
{
    public class Marks
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public decimal Score { get; set; }
        public DateTime ExamDate { get; set; }
    }
}
