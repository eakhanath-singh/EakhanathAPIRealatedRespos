using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;
using System.Net;
using System.Numerics;
using System.Reflection;
using System.Security.Principal;

namespace Program01.Model
{
    public class StudentRecords
    {
        public int StudentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        [DataType(DataType.Date)]
        public DateOnly?  DateOfBirth { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        [DataType(DataType.Date)]
        public DateOnly? AdmissionDate { get; set; }
        public string Course { get; set; }
        public string Department { get; set; }
        public int YearOfStudy { get; set; }
        public decimal GPA { get; set; }
        [DataType(DataType.Date)]
        public DateOnly? CreatedDate { get; set; }

    }
}