namespace P01_StudentSystem
{
    using System;
    using Data;
    using Microsoft.EntityFrameworkCore;

    class StartUp
    {
        static void Main(string[] args)
        {
            StudentSystemContext db = new StudentSystemContext();
            db.Database.EnsureCreated();
        }
    }
}
