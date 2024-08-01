using Otzar_Hasfarim.Models;
using Otzar_Hasfarim.ViewModel;

namespace Otzar_Hasfarim.Service
{
	public interface IShelvesService
	{
		List<ShelfModel> GetAllShelves(long Id);

		void CreateShelf(ShelfVM shelfVM);
	}
}
