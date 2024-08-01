using System.ComponentModel.DataAnnotations;

namespace Otzar_Hasfarim.ViewModel
{
	public class LibraryVM
	{
		public long Id { get; set; }
		[StringLength(100, MinimumLength = 3, ErrorMessage ="The Genre must be between 3 and 100 letters")]
		public  string Genre { get; set; } = string.Empty;
	}
}
