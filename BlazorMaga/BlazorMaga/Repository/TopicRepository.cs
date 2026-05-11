using BlazorMaga.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace BlazorMaga.Repository
{
    public class TopicRepository : ITopicRepository
    {
        private readonly ApplicationDbContext _db;

        public TopicRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Topic> CreateTopicAsync(Topic topic)
        {
            _db.Topics.Add(topic);
            await _db.SaveChangesAsync();
            return topic;
        }

        public async Task<Topic?> GetTopicByIdAsync(long id) => await _db.Topics.Include(t => t.Menu).Include(a => a.Articles).FirstOrDefaultAsync(t => t.Id == id);

        public async Task<List<Topic>> GetAllTopicsAsync() => await _db.Topics.Include(t => t.Menu).ToListAsync();
    }
}
