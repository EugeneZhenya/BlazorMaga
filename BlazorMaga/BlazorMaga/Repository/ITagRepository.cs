using BlazorMaga.Shared.Entities;

namespace BlazorMaga.Repository
{
    public interface ITagRepository
    {
        Task<Tag> CreateTagAsync(Tag tag);
        Task<Tag?> GetTagByIdAsync(long id);
        Task<List<Tag>> GetAllTagsAsync();
    }
}
