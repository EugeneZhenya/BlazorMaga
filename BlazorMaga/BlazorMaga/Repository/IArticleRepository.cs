using BlazorMaga.Shared.Entities;

namespace BlazorMaga.Repository
{
    public interface IArticleRepository
    {
        Task<Article> CreateArticleAsync(Article article);
        Task<Article?> GetArticleByIdAsync(long id);
        Task<List<Article>> GetAllArticlesAsync();
        Task<List<Article>> GetLastArticlesAsync(int limit);
        Task<List<Article>> SearchAsync(string query);
    }
}
