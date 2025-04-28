using System.Collections.Generic;

namespace EFCoreModelApp
{
    public class Department
    {
        public int DepartmentID { get; set; } // Primary Key
        public required string Name { get; set; }
        public required List<Employee> Employees { get; set; } // Navigation Property
    }
}