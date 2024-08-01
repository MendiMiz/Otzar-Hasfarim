using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Otzar_Hasfarim.Models;
using Otzar_Hasfarim.Service;
using Otzar_Hasfarim.ViewModel;

namespace Otzar_Hasfarim.Controllers
{
    public class LibrariesController : Controller
    {
        private readonly ILibraryService _libraryService;
        private readonly IShelvesService _shelvesService;
        private readonly ISetService _setService;

        public LibrariesController(ILibraryService libraryService, IShelvesService shelvesService, ISetService setService)
        {
            _libraryService = libraryService;
            _shelvesService = shelvesService;
            _setService = setService;
        }

        public IActionResult Index()
        {
            var libraries = _libraryService.GetAllLibraries();
            return View(libraries);
        }

        public IActionResult Create()
        {
            return View(new LibraryVM());
        }

        [HttpPost]
        public IActionResult Create(LibraryVM libraryVM)
        {
            if (ModelState.IsValid)
            {
                _libraryService.CreateLibrary(libraryVM);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Shelves(long id)
        {
            var shelves = _shelvesService.GetAllShelves(id);
            if (shelves.Any())
            {
                return View(shelves);
            }
            return RedirectToAction("Index");

        }

        public IActionResult CreateShelf(long id)
        {
            ShelfVM shelfVM = new()
            {
                LibraryId = id
            };
            return View(shelfVM);
        }

        [HttpPost]
        public IActionResult CreateShelf(ShelfVM shelfVM)
        {
            if (!ModelState.IsValid)
            {
                shelfVM.ErrorMessage = "Failed to add!";
            }
            _shelvesService.CreateShelf(shelfVM);
            return RedirectToAction("Index");
        }

        public IActionResult AddSet(long libraryId)
        {
            SetVM setVM = new()
            {
                LibraryId = libraryId
            };
            return View(setVM);
        }
        [HttpPost]
        public IActionResult AddSet(SetVM setVM)
        {
            var Genre = _libraryService.GetAllLibraries()
                .Where(l => l.Id == setVM.LibraryId)
                .Select(l => l.Genre)
                .FirstOrDefault();
            if (Genre == null)
            {
                throw new Exception("Error");
            }

            BookModel bookModel = new()
            {
                Name = setVM.Book.Name,
                Width = setVM.Book.Width,
                Height = setVM.Book.Height,
                Genre = Genre
            };
            setVM.SetModel.Books.Add(bookModel);
            _setService.CreateSet(setVM);
            return RedirectToAction("Index");

        }

        public IActionResult AddMoreToSet(SetVM setVM)
        {
            SetVM newSetVM = new()
            {
                SetModel = setVM.SetModel,
                LibraryId = setVM.LibraryId
            };
            
            var Genre = _libraryService.GetAllLibraries()
                .Where(l => l.Id == setVM.LibraryId)
                .Select(l => l.Genre)
                .FirstOrDefault();
            if (Genre == null)
            {
                throw new Exception("Error");
            }
            
            BookModel bookModel = new()
            {
                Name = setVM.Book.Name,
                Width = setVM.Book.Width,
                Height = setVM.Book.Height,
                Genre = Genre
            };
            newSetVM.SetModel.Books.Add(bookModel);
            List<BookModel> actualBooks = newSetVM.SetModel.Books;
            ViewBag.BooksList = actualBooks;
            return RedirectToAction("AddSet2", new {setVM=newSetVM, setModel=newSetVM.SetModel} );
        }

		public IActionResult AddSet2(SetVM setVM, SetModel setModel)
        {
            setVM.SetModel = setModel;

            return View(setVM);
		}

	}
}
