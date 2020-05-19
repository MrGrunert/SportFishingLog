using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FishApp.Models;
using FishApp.Interfaces;
using FishApp.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace FishApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IUserRepository _userRepository;
        private IFishRepository _fishRepository;
        private IParishRepository _parishRepository;
        private ICatchRepository _catchRepository;
        private IFishingGroundRepository _fishingGroundRepository;
      

        public HomeController(
            ILogger<HomeController> logger, 
            IUserRepository userRepository, 
            IFishRepository fishRepository, 
            IParishRepository parishRepository, 
            ICatchRepository catchRepository,
            IFishingGroundRepository fishingGroundRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
            _fishRepository = fishRepository;
            _parishRepository = parishRepository;
            _catchRepository = catchRepository;
            _fishingGroundRepository = fishingGroundRepository;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            var model = new HomePageViewModel();
            model.Catches = _catchRepository.GetAllCatches().OrderByDescending(c => c.Date).Take(3);

            return View(model);
        }

        [HttpGet]
        //[ValidateAntiForgeryToken]
        public IActionResult Create()
        {
            var viewModel = new CatchViewModel();
            viewModel.FishesSelectListItems = GetFishesListItem();
            viewModel.ParishesSelectListItems = GetParischesListItem();

            return View(viewModel);
        }
     
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Create(CatchViewModel model)
        {
            var userByUserName = _userRepository.GetUserByUserName(User.Identity.Name);
            var userId = userByUserName.Id;

            //int userId = int.Parse(uId);

            if (ModelState.IsValid)
            {
                var fishingGround = new FishingGround();

                fishingGround.Name = model.FishingGroundName;
                fishingGround.Type = model.FishingGroundType;
                fishingGround.ParishId = model.ParishId;

                var newCatch = new Catch();
                newCatch.Date = model.Date;
                newCatch.Length = model.Length;
                newCatch.Weight = model.Weight;
                newCatch.Notes = model.Notes;
                newCatch.FishId = model.FishId;
                newCatch.UserId = userId;
                newCatch.FishingGround = fishingGround;
                newCatch = _catchRepository.Add(newCatch);
                _catchRepository.Commit();

                return RedirectToAction("Details", "Home", new { id = newCatch.Id });
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult MyPage()
        {
            var userByUserName = _userRepository.GetUserByUserName(User.Identity.Name);
            var userId = userByUserName.Id;

            var model = _userRepository.GetUserByUserId(userId);
            if (model == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(new MyPageViewModel(model));
        }


        [HttpGet]
        public IActionResult Details(int id)
        {
            var model = _catchRepository.Get(id);
            if (model == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult EditCatch(int id)
        {
            var model = _catchRepository.Get(id);
            if (model == null)
            {
                return RedirectToAction(nameof(Index));
            }

            CatchViewModel catchView = new CatchViewModel
            {
                Id = model.Id,
                FishingGroundId = model.FishingGroundId,
                Date = model.Date,
                FishingGroundType = model.FishingGround.Type,
                FishId = model.FishId,
                FishingGroundName = model.FishingGround.Name,
                Length = model.Length,
                Weight = model.Weight,
                ParishId = model.FishingGround.ParishId,
                Notes = model.Notes,
                ParishesSelectListItems = GetParischesListItem(),
                FishesSelectListItems = GetFishesListItem()
            };

            return View(catchView);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditCatch(CatchViewModel fCatch)
        {
            var catchToEdit = _catchRepository.Get(fCatch.Id);
            var fishingGround = _fishingGroundRepository.GetFishingGroundById(fCatch.FishingGroundId);

            if (ModelState.IsValid)
            {
                fishingGround.Id = fCatch.FishingGroundId;
                fishingGround.Name = fCatch.FishingGroundName;
                fishingGround.Type = fCatch.FishingGroundType;
                fishingGround.ParishId = fCatch.ParishId;
                catchToEdit.Date = fCatch.Date;
                catchToEdit.Length = fCatch.Length;
                catchToEdit.Weight = fCatch.Weight;
                catchToEdit.Notes = fCatch.Notes;
                catchToEdit.FishId = fCatch.FishId;


                catchToEdit.FishingGround = fishingGround;
                _catchRepository.UpdateCatch(catchToEdit);

                return RedirectToAction("Details", "Home", new { id = catchToEdit.Id });
            }

            fCatch.FishesSelectListItems = GetFishesListItem();
            fCatch.ParishesSelectListItems = GetParischesListItem();

            return View(fCatch);

        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            var model = _catchRepository.Get(id);
            if (model == null)
            {
                return RedirectToAction(nameof(Index));
            }
            DeleteCatchViewModel delViewModel = new DeleteCatchViewModel
            {
                FishingGround = model.FishingGround.Name,
                FishName = model.Fish.Name,
                Date = model.Date.ToString("d"),
                Id = model.Id
            };
            return View(delViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(DeleteCatchViewModel deleteCatch)
        {

            var fishToDelete = _catchRepository.Get(deleteCatch.Id);
            _catchRepository.DeleteCatch(fishToDelete);
            _catchRepository.Commit();

            return RedirectToAction("MyPage", "Home");
        }


        private List<SelectListItem> GetParischesListItem()
        {
            var parishCategory = _parishRepository.Parishes;
            var parisListItems = new List<SelectListItem>();
            foreach (var parish in parishCategory)
            {
                string temp = "";
                if (parish.Name != null)
                {
                    if (temp != parish.Name)
                    {
                        parisListItems.Add(new SelectListItem
                        {
                            Text = parish.Name,
                            Value = parish.Id.ToString()
                        });
                    }
                }
            }

            return parisListItems;
        }

        private List<SelectListItem> GetFishesListItem()
        {
            var fishCategory = _fishRepository.Fishes;

            var fishListItem = new List<SelectListItem>();

            foreach (var fish in fishCategory)
            {
                string temp = "";
                if (fish.Name != null)
                {
                    if (temp != fish.Name)
                    {
                        fishListItem.Add(new SelectListItem
                        {
                            Text = fish.Name,
                            Value = fish.Id.ToString()
                        });
                    }
                }
            }

            return fishListItem;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
