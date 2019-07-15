using RescueRegister.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace RescueRegister.Controllers
{
    public class MountaineerController : Controller
    {
        private readonly RescueRegisterDbContext context;

        public MountaineerController(RescueRegisterDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            using (var db = new RescueRegisterDbContext())
            {
                var tasks = db.Mountaineers.ToList();
                return this.View(tasks);

            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(Mountaineer mountaineer, string Name, string Gender, int age, string LastSeenDate)
        {
            if (string.IsNullOrEmpty(Name))
            {
                return RedirectToAction("Index");
            }

            using (var db = new RescueRegisterDbContext())
            {
                Mountaineer mountain = new Mountaineer
                {
                    Name = Name,
                    Gender = Gender,
                    LastSeenDate = LastSeenDate,
                    Age = age
                };

                db.Mountaineers.Add(mountain);
                db.SaveChanges();

            } 
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            using (var db = new RescueRegisterDbContext())
            {
                var casesToEdit = db.Mountaineers.Find(id);

                return View(casesToEdit);
            }
        }

        [HttpPost]
        public IActionResult Edit(Mountaineer mountaineer)
        {
            using (var db = new RescueRegisterDbContext())
            {
                db.Mountaineers.Update(mountaineer);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {

            using (var db = new RescueRegisterDbContext())
            {
                var casesToDelete = db.Mountaineers.Find(id);

                return View(casesToDelete);
            }
        }

        [HttpPost]
        public IActionResult Delete(Mountaineer mountaineer)
        {
            using (var db = new RescueRegisterDbContext())
            {
                db.Mountaineers.Remove(mountaineer);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}