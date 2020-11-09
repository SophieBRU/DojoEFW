using System;
using System.Collections.Generic;
using System.Text;

namespace Atelier_09112020
{
    class Employee
    {
        public Int32 EmployeeId { get; set; }
        public String EmployeeName { get; set; }

        public ICollection<Appointment> Appointments { get; set; }
    }
}
