using BlazorMaga.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorMaga.Repository
{
    public class MenuRepository : IMenuRepository
    {
        private readonly ApplicationDbContext _db;

        public MenuRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<List<Menu>> GetAllAsync() => await _db.Menus.Include(t => t.Topics).ToListAsync();

        public async Task<Menu> GetMenuByIdAsync(int id) => await _db.Menus.Include(t => t.Topics).FirstOrDefaultAsync(m => m.Id == id);
    }
}
