using Backend.DbModel;
using Backend.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options)
        { }

        public DbSet<Appointment> appointments { get; set; }
        public DbSet<DbCredentials> credentials { get; set; }
        public DbSet<DbPatient> patients { get; set; }
        public DbSet<DbDoctor> doctors { get; set; }
        public DbSet<DbDoctorAppointmentTimes> doctorAppointmentTimes { get; set; }
        public DbSet<Specialization> specializations{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DbDoctorAppointmentTimes>()
                .HasKey(t => new { t.doctorId, t.appointmentTime });
        }
    }
}
