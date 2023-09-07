using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Pets.Models;
using Newtonsoft.Json;

namespace Pets.Controllers
{
    public class PetsController : Controller
    {
        private const string PetListCacheKey = "PetList";

        private PetsDBContext BD;

        public PetsController(PetsDBContext context)
        {
            BD = context;
        }

       // private readonly IDistributedCache? _distributedCache;

        //public PetsController(IDistributedCache distributedCache)
        //{
        //    _distributedCache = distributedCache;
        //}

        public IActionResult Index()
        {
            var list = BD.Pet.ToList();
            return View(list);
        }

        [HttpGet]
        public IActionResult NewDate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NewDate(Pet pet)
        {
            BD.Pet.Add(pet);
            BD.SaveChanges();

            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Update(int Id)
        {

            var pet = BD.Pet.FirstOrDefault(x => x.ID == Id);

            return View(pet);

        }

        [HttpPost]
        public ActionResult Update(Pet pet)
        {
            var petUpdate = BD.Pet.FirstOrDefault(x => x.ID == pet.ID);

            // Modifyh field to update
            petUpdate.Names = pet.Names;
            petUpdate.Raza = pet.Raza;
            petUpdate.NameOwn = pet.NameOwn;
            petUpdate.Edad = pet.Edad;

            BD.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id) 
        {

            var petDelete = BD.Pet.FirstOrDefault(x => x.ID == id);
            BD.Pet.Remove(petDelete);
            BD.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}

