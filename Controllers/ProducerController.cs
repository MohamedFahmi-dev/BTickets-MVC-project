using BTickets.Interfaces;
using BTickets.Models;
using Microsoft.AspNetCore.Mvc;

namespace BTickets.Controllers
{
    public class ProducerController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProducerController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> Index()
        {
            var Data = await _unitOfWork.ProducerRepository.GetAllAsync();
            return View(Data);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Producer producer)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWork.ProducerRepository.AddAsync(producer);
                await _unitOfWork.ProducerRepository.SaveAsync();
                return RedirectToAction("Index");

            }
            return View("Create", producer);
        }
        public async Task<IActionResult> Details(int id)
        {
            var producer = await _unitOfWork.ProducerRepository.GetByIdAsync(id);
            if (producer == null)
            {
                return View("NotFound");
            }
            return View(producer);
        }

        public async Task<ActionResult> Edit(int id)
        {
            var producer = await _unitOfWork.ProducerRepository.GetByIdAsync(id);
            if (producer == null)
            {
                return View("NotFound");
            }
            return View(producer);
        }

        [HttpPost]
        public async Task<ActionResult> EditAsync(int id, Producer producer)
        {
            if (ModelState.IsValid)
            {
                producer.Id = id;
                _unitOfWork.ProducerRepository.Update(producer);
                await _unitOfWork.ProducerRepository.SaveAsync();
                return RedirectToAction("Index");
            }
            return View(nameof(Edit), producer);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var producer = await _unitOfWork.ProducerRepository.GetByIdAsync(id);
            if (producer == null)
            {
                return View("NotFound");
            }
            return View(producer);
        }

        [HttpPost]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            if (ModelState.IsValid)
            {
                var producer = await _unitOfWork.ProducerRepository.GetByIdAsync(id);
                if (producer == null)
                {
                    return View("NotFound");
                }

                _unitOfWork.ProducerRepository.Remove(producer);
                await _unitOfWork.ProducerRepository.SaveAsync();
                return RedirectToAction("Index");
            }
            return View(nameof(Delete));
        }

    }
}


