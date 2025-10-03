using Practice2.Models;

namespace Practice2.ViewModels
{
    public class ContentViewModel
    {
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Publication> Publications { get; set; }
    }
}
