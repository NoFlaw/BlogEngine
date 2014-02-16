using System.Collections.Generic;
using BlogEntities.Models;

namespace BlogEngine.Models.ViewModels
{
    public class ViewBlogsViewModel
    {
        public List<Blog> Blogs { get; set; }

        public List<Post> Posts { get; set; }


        public int PostsCount
        {
            get { return Posts.Count; }
        }

        public ViewBlogsViewModel()
        {
            
        }

        public ViewBlogsViewModel(List<Blog> blogs, List<Post> posts)
        {
            Blogs = blogs;
            Posts = posts;
        }

    }
}