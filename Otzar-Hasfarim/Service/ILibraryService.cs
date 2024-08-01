using Otzar_Hasfarim.Models;
using Otzar_Hasfarim.ViewModel;

namespace Otzar_Hasfarim.Service
{
	public interface ILibraryService 
	{
		List<LibraryModel> GetAllLibraries();

		void CreateLibrary(LibraryVM libraryVM);
	}
}
