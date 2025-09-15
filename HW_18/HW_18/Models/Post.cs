    namespace HW_18.Models
    {
        public class Post
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Content { get; set; }

            public string UserId { get; set; }
            public User User { get; set; }

            public PostVisibility Visibility { get; set; }
        }

        public enum PostVisibility
        {
            Public,     
            Private,    
            Friends     
        }
    }
