using BTickets.Interfaces;
using BTickets.Models;
using BTickets.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BTickets.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> userManager;
        public MoviesController(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager)
        {

            this._unitOfWork = unitOfWork;
            this.userManager = userManager;
        }
        public async Task<IActionResult> Index(int page = 1, int pageSize = 12)
        {
            if (page < 1) page = 1;
            if (pageSize < 1) pageSize = 12;
            if (pageSize > 50) pageSize = 50;

            var movies = await _unitOfWork.MovieRepository.GetAllWithCinemaAsync(page, pageSize);

            return View(movies);
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create()
        {
            ViewBag.Cinemas = await _unitOfWork.CinemaRepository.GetAllAsync();
            ViewBag.Producers = await _unitOfWork.ProducerRepository.GetAllAsync();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Movie Movie)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWork.MovieRepository.AddAsync(Movie);
                await _unitOfWork.MovieRepository.SaveAsync();
                return RedirectToAction("Index");

            }
            ViewBag.Cinemas = await _unitOfWork.CinemaRepository.GetAllAsync();
            ViewBag.Producers = await _unitOfWork.ProducerRepository.GetAllAsync();
            return View("Create", Movie);
        }
        [Authorize]
        public async Task<IActionResult> Details(int id)
        {
            var movie = await _unitOfWork.MovieRepository.GetAllWithMovieAsync(id);

            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }
        [Authorize(Roles = "Admin")]

        public async Task<ActionResult> Edit(int id)
        {
            var Movie = await _unitOfWork.MovieRepository.GetByIdAsync(id);
            if (Movie == null)
            {
                return View("NotFound");
            }
            return View(Movie);
        }

        [HttpPost]
        public async Task<ActionResult> EditAsync(int id, Movie Movie)
        {
            if (ModelState.IsValid)
            {
                Movie.Id = id;
                _unitOfWork.MovieRepository.Update(Movie);
                await _unitOfWork.MovieRepository.SaveAsync();
                return RedirectToAction("Index");
            }
            return View(nameof(Edit), Movie);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var Movie = await _unitOfWork.MovieRepository.GetByIdAsync(id);
            if (Movie == null)
            {
                return View("NotFound");
            }
            return View(Movie);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            if (ModelState.IsValid)
            {
                var Movie = await _unitOfWork.MovieRepository.GetByIdAsync(id);
                if (Movie == null)
                {
                    return View("NotFound");
                }

                _unitOfWork.MovieRepository.Remove(Movie);
                await _unitOfWork.MovieRepository.SaveAsync();
                return RedirectToAction("Index");
            }
            return View(nameof(Delete));
        }
        public async Task<IActionResult> Filter(string searchString)
        {
            var moive = await _unitOfWork.MovieRepository.GetAllWithCinemaAsync();
            if (!string.IsNullOrEmpty(searchString))
            {
                moive = moive.Where(m => m.Name.ToLower().Contains(searchString.ToLower()) || m.Description.ToLower().Contains(searchString.ToLower())).ToList();
            }
            var movieList = moive.ToList();

            var paginatedResult = new PaginatedResult<Movie>(
                items: movieList,
                totalItems: moive.Count(),
                currentPage: 1,
                pageSize: moive.Count()
                );
            ViewBag.CurrentFilter = searchString;
            return View("Index", paginatedResult);
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            var user = await userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var registerVM = new RegisterVM
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Username = user.UserName,
                Email = user.Email
            };

            return View(registerVM);
        }
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Profile(RegisterVM registerVM)
        {

            if (!ModelState.IsValid)
            {
                return View(registerVM);
            }

            var user = await userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }

            user.FirstName = registerVM.FirstName;
            user.LastName = registerVM.LastName;
            user.UserName = registerVM.Username;
            user.Email = registerVM.Email;

            var result = await userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                TempData["Success"] = "Profile updated successfully!";

                return RedirectToAction("Profile");
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View(registerVM);
        }

    }
}
