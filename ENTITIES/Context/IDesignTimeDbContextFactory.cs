using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITIES.Context
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<PatientBookingContext>
    {
        public PatientBookingContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<PatientBookingContext>();
            optionsBuilder.UseSqlServer(@"Server=(LocalDb)\MSSQLLocalDB;Database=HealthCareManagementDB;Trusted_Connection=True;TrustServerCertificate=True;");

            return new PatientBookingContext(optionsBuilder.Options);
        }
    }
}
