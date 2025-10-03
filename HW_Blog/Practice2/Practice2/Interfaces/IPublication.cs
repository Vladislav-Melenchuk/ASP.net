using Practice2.Models;

namespace Practice2.Interfaces
{
    public interface IPublication
    {
        Task<IEnumerable<Publication>> GetAllPublicationsAsync();
        Task<IEnumerable<Publication>> GetAllPublicationsWithCategoriesAsync();
        Task<Publication> GetPublicationAsync(string id);
        Task<Publication> GetPublicationWithCategoriesAsync(string id);

        Task UpdateViewsAsync(string id);

        Task AddPublicationAsync(Publication publication);
        Task UpdatePublicationAsync(Publication publication);
        Task DeletePublicationAsync(Publication publication);

        Task<PagedList<Publication>> GetAllPublicationsByCategoryWithCategories(QueryOptions options, string id);
    }
}
