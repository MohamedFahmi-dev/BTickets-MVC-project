using BTickets.Interfaces;
using BTickets.Models;
using Microsoft.AspNetCore.Mvc;

namespace BTickets.Controllers
{
    public class CinemaController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        public CinemaController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> Index()
        {
            var Data = await unitOfWork.CinemaRepository.GetAllAsync();
            return View(Data);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Cinema cinema)
        {
            if (ModelState.IsValid)
            {
                await unitOfWork.CinemaRepository.AddAsync(cinema);
                await unitOfWork.CinemaRepository.SaveAsync();
                return RedirectToAction("Index");

            }
            return View("Create", cinema);
        }
        public async Task<ActionResult> Edit(int id)
        {
            var cinema = await unitOfWork.CinemaRepository.GetByIdAsync(id);
            if (cinema == null)
            {
                return View("NotFound");
            }
            return View(cinema);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(int id, Cinema cinema)
        {
            if (ModelState.IsValid)
            {
                cinema.Id = id;
                unitOfWork.CinemaRepository.Update(cinema);
                await unitOfWork.CinemaRepository.SaveAsync();
                return RedirectToAction("Index");
            }
            return View(nameof(Edit), cinema);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var cinema = await unitOfWork.CinemaRepository.GetByIdAsync(id);
            if (cinema == null)
            {
                return View("NotFound");
            }
            return View(cinema);
        }

        [HttpPost]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            if (ModelState.IsValid)
            {
                var cinema = await unitOfWork.CinemaRepository.GetByIdAsync(id);
                if (cinema == null)
                {
                    return View("NotFound");
                }

                unitOfWork.CinemaRepository.Remove(cinema);
                await unitOfWork.CinemaRepository.SaveAsync();
                return RedirectToAction("Index");
            }
            return View(nameof(Delete));
        }

    }
}
