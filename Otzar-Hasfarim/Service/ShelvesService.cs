﻿using Microsoft.EntityFrameworkCore;
using Otzar_Hasfarim.Data;
using Otzar_Hasfarim.Models;
using Otzar_Hasfarim.ViewModel;

namespace Otzar_Hasfarim.Service
{
    public class ShelvesService : IShelvesService
    {
        private readonly ApplicationDbContext _context;

        public ShelvesService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void CreateShelf(ShelfVM shelfVM)
        {
            ShelfModel model = new()
            {
                Width = shelfVM.Width,
                Height = shelfVM.Height,
                LibraryId = shelfVM.LibraryId
            };

            _context.Shelves.Add(model);
            _context.SaveChanges();
        }

        public List<ShelfModel> GetAllShelves(long Id) =>
            _context.Shelves
            .Where(s => s.LibraryId == Id)
            .Include(s => s.Sets)
            .ToList();
    }
}
