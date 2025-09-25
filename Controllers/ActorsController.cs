using BTickets.Interfaces;
using BTickets.Models;
using Microsoft.AspNetCore.Mvc;

namespace BTickets.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        public ActorsController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> Index()
        {
            var Data = await unitOfWork.ActorRepository.GetAllAsync();
            return View(Data);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Actor Actor)
        {
            if (ModelState.IsValid)
            {
                await unitOfWork.ActorRepository.AddAsync(Actor);
                await unitOfWork.ActorRepository.SaveAsync();
                return RedirectToAction("Index");

            }
            return View("Create", Actor);
        }
        public async Task<IActionResult> Details(int id)
        {
            var actor = await unitOfWork.ActorRepository.GetByIdAsync(id);
            if (actor == null)
            {
                return View("NotFound");
            }
            return View(actor);
        }

        public async Task<ActionResult> Edit(int id)
        {
            var actor = await unitOfWork.ActorRepository.GetByIdAsync(id);
            if (actor == null)
            {
                return View("NotFound");
            }
            return View(actor);
        }

        [HttpPost]
        public async Task<ActionResult> EditAsync(int id, Actor Actor)
        {
            if (ModelState.IsValid)
            {
                Actor.Id = id;
                unitOfWork.ActorRepository.Update(Actor);
                await unitOfWork.ActorRepository.SaveAsync();
                return RedirectToAction("Index");
            }
            return View(nameof(Edit), Actor);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var actor = await unitOfWork.ActorRepository.GetByIdAsync(id);
            if (actor == null)
            {
                return View("NotFound");
            }
            return View(actor);
        }

        [HttpPost]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            if (ModelState.IsValid)
            {
                var actor = await unitOfWork.ActorRepository.GetByIdAsync(id);
                if (actor == null)
                {
                    return View("NotFound");
                }

                unitOfWork.ActorRepository.Remove(actor);
                await unitOfWork.ActorRepository.SaveAsync();
                return RedirectToAction("Index");
            }
            return View(nameof(Delete));
        }

    }
}
