using BlazorMaga.Shared.Entities;

namespace BlazorMaga.Helpers
{
    public interface IRepository
    {
        List<Article> GetALLArticles();
        List<Article> GetArticles();
    }
}
