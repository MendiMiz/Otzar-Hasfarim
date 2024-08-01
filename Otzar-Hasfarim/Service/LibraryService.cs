
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Otzar_Hasfarim.Data;
using Otzar_Hasfarim.Models;
using Otzar_Hasfarim.ViewModel;

namespace Otzar_Hasfarim.Service
{
	public class LibraryService : ILibraryService
	{
		private readonly ApplicationDbContext _context;

		public LibraryService(ApplicationDbContext context)
		{
			_context = context;
		}

		public void CreateLibrary(LibraryVM libraryVM)
		{
			LibraryModel newLibrary = new()
			{
				Genre = libraryVM.Genre
			};

			_context.Libraries.Add(newLibrary);
			_context.SaveChanges();
		}

		public List<LibraryModel> GetAllLibraries() =>
			_context.Libraries
			.Include(l => l.Shelves)
			.ToList();
	}
}
