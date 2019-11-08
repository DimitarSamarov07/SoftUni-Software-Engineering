namespace P01_HospitalDatabase
{
    using Data;
    using Data.Models;
    using Microsoft.EntityFrameworkCore;

    class StartUp
    {
        static void Main(string[] args)
        {
            var db = new HospitalContext();

            db.Doctors.Add(new Doctor
            {
                Name = "Ivan",
                Specialty = "Sleeper",
            });

            db.SaveChanges();
        }
    }
}
