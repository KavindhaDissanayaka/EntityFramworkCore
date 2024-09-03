using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramworkCore.Domain
{
    public class Student
    {
        public int Id { get; set; }
        public string StudentID { get; set; }
        public string StudentName { get; set; }
        public int SubjectID { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
