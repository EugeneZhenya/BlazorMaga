using BlazorMaga.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorMaga.Repository
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly ApplicationDbContext _db;

        public ArticleRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<Article> CreateArticleAsync(Article article)
        {
            _db.Articles.Add(article);
            await _db.SaveChangesAsync();
            return article;
        }

        public async Task<List<Article>> GetAllArticlesAsync() =>
        await _db.Articles
                 .Include(a => a.Topic)
                 .Include(a => a.ArticlesTags)
                 .ThenInclude(x => x.Tag)
                 .OrderByDescending(q => q.Created)
                 .ToListAsync();

        public async Task<Article?> GetArticleByIdAsync(long id) =>
            await _db.Articles
                 .Include(a => a.Topic)
                 .Include(a => a.ArticlesTags)
                 .ThenInclude(at => at.Tag)
                 .FirstOrDefaultAsync(a => a.Id == id);
    }
}
