namespace Solving_Select_Everything_Problem
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Employee
    {
        public Employee()
        {
            this.ManagedEmployees = new HashSet<Employee>();
        }

        public int EmployeeID { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(50)]
        public string MiddleName { get; set; }

        [Required]
        [StringLength(50)]
        public string JobTitle { get; set; }

        public int DepartmentID { get; set; }

        public int? ManagerID { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime HireDate { get; set; }

        [Column(TypeName = "money")]
        public decimal Salary { get; set; }

        public int? AddressID { get; set; }

        public virtual ICollection<Employee> ManagedEmployees { get; set; }

        public virtual Employee Manager { get; set; }
    }
}
