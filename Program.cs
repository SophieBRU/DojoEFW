using System;
using System.Collections.Generic;
using System.Linq;

namespace Atelier_09112020
{
    class Program
    {
        static void Main()
        {
            using (var context = new DojoEFW())
            {
                // I wipe out my database at each execution
                context.Database.EnsureDeleted();
                // Then I recreate it
                context.Database.EnsureCreated();

                var employee = new Employee
                {
                    EmployeeName = "Toto"
                };

                employee.Appointments = new List<Appointment>
                {
                new Appointment { AppointmentName = "Client1", AppointmentPostPoned = true },
                new Appointment { AppointmentName = "Client2", AppointmentPostPoned = false },
                };

                context.Add(employee);
                // After the shop is added, his relatonships will too
                // if they are defined          


                var employee2 = new Employee
                {
                    EmployeeName = "Tata"
                };

                employee2.Appointments = new List<Appointment>
                {
                new Appointment { AppointmentName = "Fournisseur1", AppointmentPostPoned = false },
                new Appointment { AppointmentName = "Fournisseur2", AppointmentPostPoned = false },
                };

                context.Add(employee2);
                // After the shop is added, his relatonships will too
                // if they are defined          
                context.SaveChanges();
                // Once changes are added, they must be saved to the database
                // unless you will have an unexisting one   
                

                foreach (Employee emp in context.Employees)
                {
                    IEnumerable<Appointment> rate = from M in employee.Appointments
                                                    select M;

                    IEnumerable<Appointment> rate2 = from M in employee.Appointments
                                                     where M.AppointmentPostPoned == true
                                                     select M;

                    Int32 result = rate2.Count() / rate.Count();

                    Console.WriteLine(result);

                    //MessageBox.Show(result, "Useless message box",
                    //MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
    }
}
