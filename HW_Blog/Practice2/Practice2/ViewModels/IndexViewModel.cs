using Practice2.Models;

namespace Practice2.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<Publication> Publications { get; set; }
        public List<Category> Categories { get; set; }
    }

}
