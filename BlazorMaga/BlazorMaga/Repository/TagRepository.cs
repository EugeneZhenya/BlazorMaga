using BlazorMaga.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorMaga.Repository
{
    public class TagRepository : ITagRepository
    {
        private readonly ApplicationDbContext _db;

        public TagRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Tag> CreateTagAsync(Tag tag)
        {
            _db.Tags.Add(tag);
            await _db.SaveChangesAsync();
            return tag;
        }

        public async Task<Tag?> GetTagByIdAsync(long id) => await _db.Tags.FirstOrDefaultAsync(t => t.Id == id);

        public async Task<List<Tag>> GetAllTagsAsync() => await _db.Tags.OrderBy(t => t.Mark).ToListAsync();
    }
}
