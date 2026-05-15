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
            if (article.ArticlesTags != null)
            {
                for (int i = 0; i < article.ArticlesTags.Count; i++)
                {
                    article.ArticlesTags[i].Order = i + 1;
                }
            }

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

        public async Task<List<Article>> GetLastArticlesAsync(int limit)
        {
            return await _db.Articles
                .Include(a => a.Topic)
                .ThenInclude(t => t.Menu)
                .Include(a => a.ArticlesTags)
                .ThenInclude(x => x.Tag)
                .OrderByDescending(q => q.Created)
                .Take(limit)
                .ToListAsync();
        }

        public async Task<Article?> GetArticleByIdAsync(long id) =>
            await _db.Articles
                 .Include(a => a.Topic)
                 .Include(a => a.ArticlesTags)
                 .ThenInclude(at => at.Tag)
                 .FirstOrDefaultAsync(a => a.Id == id);

        public async Task<List<Article>> SearchAsync(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                return new List<Article>();

            return await _db.Articles
                .Where(a => a.Title.Contains(query)
                         || a.Description.Contains(query)
                         || a.Content.Contains(query))
                .ToListAsync();
        }
    }
}
