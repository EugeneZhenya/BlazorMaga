using BlazorMaga.Shared.Entities;

namespace BlazorMaga.Repository
{
    public interface IMenuRepository
    {
        Task<List<Menu>> GetAllAsync();
        Task<Menu> GetMenuByIdAsync(int id);
    }
}
