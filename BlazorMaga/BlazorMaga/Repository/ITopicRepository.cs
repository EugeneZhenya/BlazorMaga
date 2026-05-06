using BlazorMaga.Shared.Entities;

namespace BlazorMaga.Repository
{
    public interface ITopicRepository
    {
        Task<Topic> CreateTopicAsync(Topic topic);
        Task<Topic?> GetTopicByIdAsync(long id);
        Task<List<Topic>> GetAllTopicsAsync();
    }
}
